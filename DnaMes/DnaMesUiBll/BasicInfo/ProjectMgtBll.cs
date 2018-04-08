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
        /// <param name="needUpdateProjects"></param>
        private void BuildSubTree(UltraTreeNode pNode, IEnumerable<Project> children, ImageList.ImageCollection images,LinkedList<string> needUpdateProjects)
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
                var needUpdate = needUpdateProjects.Find(model.Code) != null;
                if (needUpdate)
                {
                    needUpdateProjects.Remove(model.Code);
                    grandChildern = _dal.GetChildren<Project>(model);
                    //更新内存中对象集合
                    if (_nodes.ContainsKey(model.Code))
                    {
                        _nodes[model.Code] = grandChildern;
                    }

                }
                else if (!_nodes.ContainsKey(model.Code))
                {
                    grandChildern = _dal.GetChildren<Project>(model);
                    _nodes.Add(model.Code, grandChildern);
                }
                else
                {
                    grandChildern = _nodes[model.Code];
                }

                if (!grandChildern.IsNullOrEmpty())
                {
                    mainNode.Nodes.Add(); //增加空子树以显示剪头标志
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
        /// <param name="needUpdate">是否需要从数据库更新数据</param>
        /// <param name="exp"></param>
        public void BuildTree(ref UltraTree uTree, ImageList.ImageCollection images,LinkedList<string> needUpdate,
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
            BuildSubTree(root, children, images, needUpdate);
            root.Expanded = true;
        }

        /// <summary>
        /// 获取子类集合
        /// </summary>
        /// <param name="selectedNodes"></param>
        /// 
        public List<Project> GetChildren(SelectedNodesCollection selectedNodes)
        {
            var children = new List<Project>();

            foreach (var node in selectedNodes)
            {
                foreach (var p in node.Nodes)
                {
                    if (p.Tag is Project project)
                    {
                        children.Add(project);
                    }
                }
            }

            return children;
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

        public void AfterExpand(UltraTreeNode node, ImageList.ImageCollection images,LinkedList<string> needUpdate)
        {
            if (!_nodes.ContainsKey(node.Key) || _nodes[node.Key].IsNullOrEmpty()) return;
            node.Nodes.Clear();
            BuildSubTree(node, _nodes[node.Key], images, needUpdate);
        }

        /// <summary>
        /// 添加项目
        /// </summary>
        /// <param name="proj"></param>
        /// <param name="parentProj">指定父节点</param>
        /// <returns></returns>
        public bool AddProject(Project proj, Project parentProj = null)
        {
            var res = _dal.Insert(proj);
            return parentProj == null ? res : _dal.SetLinkWith(parentProj, proj);
        }

        /// <summary>
        /// 验证Project是否存在
        /// </summary>
        /// <param name="proj"></param>
        /// <returns></returns>
        public bool IsExist(Project proj)
        {
            return _dal.IsExist(proj);
        }

        /// <summary>
        /// Grid绑定查询结果
        /// </summary>
        /// <param name="exp"></param>
        /// 
        public List<Project> GetDataSource(Expression<Func<Project, bool>> exp)
        {
            return _dal.Get(exp);
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
                    var pProj = _dal.GetParent(tmpProj);
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
        public bool UpdateProject(Project project,Project parent=null)
        {
            var res = true;
            //修改为主项目后将原来与父级关系删除
            if (project.IsMain&&parent!=null)
            {
                res=_dal.DeleteLinkWith<Project,Project,ProjectProject>(parent, project);
            }

            return res && _dal.Update(project);
        }
        /// <summary>
        /// 先删除依赖关系，再删除实体
        /// </summary>
        /// <param name="proj"></param>
        /// <param name="pProj"></param>
        /// <returns></returns>
        public bool DeleteProject(Project proj, Project pProj=null)
        {
            var res = true;
            if (pProj != null)
            {
                res=_dal.DeleteLinkWith<Project, Project, ProjectProject>(pProj, proj);
            }

            return res && _dal.Delete(proj);
        }
    }
}