// ****************************************************
//  Author: Charles Ma
//  Date: 2018/03/02 14:12
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Windows.Forms;
using DnaLib.Helper;
using DnaMesDal;
using DnaMesModel;
using DnaMesModel.Model.BasicInfo;
using DnaMesUiBll.Shared;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinTree;
using SqlSugar;

namespace DnaMesUiBll.BasicInfo
{
    /// <summary>
    /// 项目管理窗体操作
    /// </summary>
    public class ProjectMgtBll //: ITree<Project>
    {
        #region 私有字段

        private readonly BaseDal<Project> _dal = new BaseDal<Project>();
        private readonly Dictionary<string, List<Project>> _nodes = new Dictionary<string, List<Project>>();

        #endregion

        #region 公有属性

        #endregion

        #region 私有方法

        /// <summary>
        /// 构建子树
        /// </summary>
        /// <param name="pNode"></param>
        /// <param name="children"></param>
        /// <param name="images"></param>
        private void BuildSubTree(UltraTreeNode pNode, IEnumerable<Project> children, ImageList.ImageCollection images)
        {
            if (children == null)
            {
                return;
            }

            foreach (var model in children)
            {
                if (pNode.Control.GetNodeByKey(model.Code) != null)
                {
                    continue;
                }

                var mainNode = pNode.Nodes.Add(model.Code, model.Name + " [" + model.Code + "]");
                mainNode.Tag = model;
                //设置图片
                if (!images.IsNullOrEmpty() && images.Count > mainNode.Level + 2)
                {
                    mainNode.LeftImages.Clear();
                    mainNode.LeftImages.Add(images[mainNode.Level + 2]);
                }

                List<Project> grandChildern;

                if (!_nodes.ContainsKey(model.Code))
                {
                    grandChildern = _dal.GetLinkWith<Project>(model);
                    _nodes.Add(model.Code, grandChildern);
                }
                else
                {
                    grandChildern = _nodes[model.Code];
                }

                if (!grandChildern.IsNullOrEmpty())
                {
                    mainNode.Nodes.Add("null"); //增加空子树以显示剪头标志
                }
            }
        }

        #endregion

        #region 公有方法

        #endregion

        /// <summary>
        /// 构建树
        /// </summary>
        /// <param name="uTree"></param>
        /// <param name="images"></param>
        /// <param name="exp"></param>
        public void BuildTree(ref UltraTree uTree, ImageList.ImageCollection images,
            Expression<Func<Project, bool>> exp = null)
        {
            var children = _dal.Get(exp);
            var root = uTree.TopNode;
            if (root == null)
            {
                root = new UltraTreeNode("root", "项目");
                if (!images.IsNullOrEmpty() && images.Count > 2)
                {
                    root.LeftImages.Clear();
                    root.LeftImages.Add(images[2]);
                }

                uTree.Nodes.Clear();
                uTree.Nodes.Add(root);
            }

            root.Nodes.Clear();
            BuildSubTree(root, children, images);
            root.Expanded = true;
        }

        /// <summary>
        /// AfterSelect事件方法
        /// </summary>
        /// <param name="ug1"></param>
        /// <param name="e"></param>
        public void AfterSelect(ref UltraGrid ug1, SelectEventArgs e)
        {
            var children = new List<Project>();
            if (!e.NewSelections.IsNullOrEmpty())
            {
                foreach (var node in e.NewSelections)
                {
                    foreach (var p in node.Nodes)
                    {
                        if (p.Tag is Project project)
                        {
                            children.Add(project);
                        }
                    }
                }
            }

            GridBindingBll<Project>.BindingData(ug1, children, "BasicInfo\\Project.xml");
        }

        /// <summary>
        /// 根据条件构造表达式
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public Expression<Func<Project, bool>> BuildExp(string code, string name, DateTime startTime, DateTime endTime)
        {
            var expTemp = new Expressionable<Project>();
            expTemp.AndIF(!code.IsNullOrEmpty(), p => p.Code == code);
            expTemp.AndIF(!name.IsNullOrEmpty(), p => p.Name == name);
            expTemp.AndIF(startTime.IsLegalDate(), p => p.StartingTime >= startTime);
            expTemp.AndIF(endTime.IsLegalDate(), p => p.EndingTime <= endTime);
            return expTemp.ToExpression();
        }

        public void AfterExpand(UltraTreeNode node, ImageList.ImageCollection images)
        {
            if (!_nodes.ContainsKey(node.Key) || _nodes[node.Key].IsNullOrEmpty()) return;
            node.Nodes.Clear();
            BuildSubTree(node, _nodes[node.Key], images);
        }
        /// <summary>
        /// 添加项目
        /// </summary>
        /// <param name="proj"></param>
        /// <param name="parentProj"></param>
        /// <returns></returns>
        public bool AddProject(Project proj,Project parentProj=null)
        {
            var res=_dal.Insert(proj);
            return parentProj == null ? res : _dal.SetLinkWith(parentProj, proj);
        }
    }
}