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

        #endregion

        #region 公有属性

        #endregion

        #region 私有方法

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
            uTree.ExpandAll();
        }

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

                var cNode = pNode.Nodes.Add(model.Code, model.Name);
                cNode.Tag = model;
                //设置图片
                if (!images.IsNullOrEmpty() && images.Count > cNode.Level + 2)
                {
                    cNode.LeftImages.Clear();
                    cNode.LeftImages.Add(images[cNode.Level + 2]);
                }

                var grandChildren = _dal.GetLinkWith<Project>(model);
                BuildSubTree(cNode, grandChildren, images);
            }
        }
        /// <summary>
        /// AfterSelect事件方法
        /// </summary>
        /// <param name="ug1"></param>
        /// <param name="e"></param>
        public void AfterSelect(ref UltraGrid ug1, SelectEventArgs e)
        {
            var children=new List<Project>();
            if (e.NewSelections[0]?.Tag is Project selectedProject)
            {
                children = _dal.GetLinkWith<Project>(selectedProject);
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
            expTemp.AndIF(startTime.IsLegalDate(), p => p.StartingTime>= startTime);
            expTemp.AndIF(endTime.IsLegalDate(), p => p.EndingTime<= endTime);
            return expTemp.ToExpression();
        }
        /// <summary>
        /// 控件根据查询结果执行动作
        /// </summary>
        /// <param name="uTree"></param>
        /// <param name="ug1"></param>
        /// <param name="dataSource"></param>
        public void AfterSearch(UltraTree uTree, UltraGrid ug1, List<Project> dataSource)
        {

            foreach (var project in dataSource)
            {
                var node=uTree.GetNodeByKey(project.Code);
                //node.Selected = true;
                node.Toggle();
            }
        }
    }
}