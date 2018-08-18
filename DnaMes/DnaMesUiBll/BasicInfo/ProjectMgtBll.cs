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
using DnaMesModel.Link.BasicInfo;
using DnaMesModel.Model.BasicInfo;
using DnaMesUiBll.Shared;
using Infragistics.Win.UltraWinTree;
using SqlSugar;

namespace DnaMesUiBll.BasicInfo
{
    /// <inheritdoc />
    /// <summary>
    /// 项目管理窗体操作
    /// </summary>
    public class ProjectMgtBll : BaseBll<Project>
    {
        #region 私有字段

        #endregion

        #region 公有属性

        #endregion

        #region 私有方法

        protected override void BuildSubTree(UltraTreeNode pNode, IEnumerable<Project> children,
            ImageList.ImageCollection images)
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


                UpdateDic(model.Code, () => Dal.GetChildren<Project>(model));
                var grandChildern = ChildrenDic[model.Code];
                if (!grandChildern.IsNullOrEmpty())
                {
                    mainNode.Nodes.Add(); //增加空子树以显示剪头标志
                }
            }
        }

        #endregion

        #region 公有方法

        #endregion

        public bool AddProject(Project child, Project parent)
        {
            child.IsMain = parent == null;
            return AddModel(child, parent);
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

        /// <summary>
        /// 根据选中Project查找树中节点
        /// </summary>
        /// <param name="uTree"></param>
        /// <param name="proj"></param>
        /// <returns></returns>
        public UltraTreeNode FindNode(UltraTree uTree, Project proj)
        {
            while (true)
            {
                if (proj == null)
                {
                    return null;
                }

                var node = uTree.GetNodeByKey(proj.Code);
                if (node != null)
                {
                    return node; //Have found it!
                }

                //Continue finding.
                var sP = new Stack<Project>();
                var tmpProj = proj;
                var foundParentNode = false;
                while (!foundParentNode)
                {
                    var pProj = Dal.GetParent(tmpProj);
                    if (pProj == null)
                    {
                        return null; //待定
                    }

                    var pNode = uTree.GetNodeByKey(pProj.Code);
                    if (pNode == null)
                    {
                        sP.Push(pProj);
                        tmpProj = pProj;
                        continue;
                    }

                    foundParentNode = true;
                    pNode.Expanded = true;
                }

                //已经找到在树节点
                while (sP.Count > 0)
                {
                    var n = uTree.GetNodeByKey(sP.Pop().Code);
                    if (n == null)
                    {
                        return null; //待定
                    }

                    n.Expanded = true;
                }
            }
        }

        /// <summary>
        /// 更新项目
        /// 若更新为主项目并存在父级则将关系删除
        /// </summary>
        /// <param name="project"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public bool UpdateModel<TParent>(Project project, TParent parent = default)
        {
            var res = true;
            //修改为主项目后将原来与父级关系删除
            if (project.IsMain && parent is Project p)
            {
                res = Dal.DeleteLinkWith<Project, Project, ProjectProject>(p, project);
            }

            return res && Dal.Update(project);
        }

        public void ChangeParent(List<Project> children, Project pPorj)
        {
            if (pPorj == null)
            {
                foreach (var proj in children)
                {
                    proj.IsMain = true;
                    Dal.Update(proj);
                    var parent = Dal.GetParent(proj);
                    Dal.DeleteLinkWith<Project, Project, ProjectProject>(parent, proj);
                }
            }
            else
            {
                foreach (var child in children)
                {
                    child.IsMain = false;
                    Dal.Update(child);
                    Dal.SetLinkWith(pPorj, child);
                }
            }
        }
    }
}