// ****************************************************
//  Author: Charles Ma
//  Date: 2018/04/09 11:39
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
using Infragistics.Win.UltraWinTree;

namespace DnaMesUiBll.Shared
{
    /// <summary>
    /// 基本逻辑类
    /// </summary>
    public abstract class BaseBll<T> where T : BaseModel, new()
    {
        #region 私有字段

        /// <summary>
        /// key与value的关系字典，用于存放数据库缓存
        /// </summary>
        protected Dictionary<string, List<T>> ChildrenDic { get; set; } = new Dictionary<string, List<T>>();

        protected readonly BaseDal<T> Dal = new BaseDal<T>();

        #endregion

        #region 公有属性

        /// <summary>
        /// UI中增删改查后的条目的父类存放在此属性中
        /// </summary>
        public LinkedList<string> ParentsToBeUpdated { get; set; } = new LinkedList<string>();

        #endregion

        #region 私有方法

        protected void InitialDic()
        {
            ChildrenDic = new Dictionary<string, List<T>>();
        }

        /// <summary>
        /// 更新字典中缓存内容
        /// </summary>
        /// <param name="key"></param>
        /// <param name="getChildren"></param>
        protected void UpdateDic(string key, Func<List<T>> getChildren)
        {
            var model = ParentsToBeUpdated?.Find(key);
            if (model != null)
            {
                ParentsToBeUpdated.Remove(model);
                if (ChildrenDic.ContainsKey(key))
                {
                    ChildrenDic[key] = getChildren();
                }
            }

            if (!ChildrenDic.ContainsKey(key))
            {
                ChildrenDic.Add(key, getChildren());
            }
        }

        #endregion

        #region 公有方法

        /// <summary>
        /// 添加Model
        /// </summary>
        /// <param name="model"></param>
        /// <param name="parent">指定父节点</param>
        /// <returns></returns>
        public virtual bool AddModel<TParent>(T model, TParent parent = null) where TParent : BaseModel, new()
        {
            var res = Dal.Insert(model);
            return parent == null ? res : Dal.SetLinkWith(parent, model);
        }

        /// <summary>
        /// 更新Model
        /// </summary>
        /// <typeparam name="TParent"></typeparam>
        /// <param name="model"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public abstract bool UpdateModel<TParent>(T model, TParent parent = null) where TParent : BaseModel, new();

        /// <summary>
        /// 获取子类集合
        /// </summary>
        /// <param name="selectedNodes">选中的树节点集合</param>
        /// <param name="getChildren"></param>
        public List<T> GetChildren(SelectedNodesCollection selectedNodes, Func<List<T>> getChildren = null)
        {
            var children = new List<T>();

            foreach (var node in selectedNodes)
            {
                if (ChildrenDic.ContainsKey(node.Key) && ChildrenDic[node.Key].IsNotNullorEmpty())
                {
                    children.AddRange(ChildrenDic[node.Key]);
                }
                else if (getChildren != null && getChildren().IsNotNullorEmpty())
                {
                    ChildrenDic.Add(node.Key, getChildren());
                }
            }

            return children;
        }

        /// <summary>
        /// Grid绑定查询结果
        /// </summary>
        /// <param name="exp"></param>
        [Obsolete("待更新")]
        public List<T> GetDataSource(Expression<Func<T, bool>> exp)
        {
            return Dal.Get(exp);
        }

        /// <summary>
        /// 验证Project是否存在
        /// </summary>
        /// <param name="proj"></param>
        /// <returns></returns>
        public bool IsExist(T proj)
        {
            return Dal.IsExist(proj);
        }

        /// <summary>
        /// 先删除依赖关系，再删除实体
        /// </summary>
        /// <param name="proj"></param>
        /// <param name="pProj"></param>
        /// <returns></returns>
        public bool DeleteModel<TParent, TLink>(T proj, TParent pProj = null)
            where TParent : BaseModel, new() where TLink : BaseLink, new()
        {
            var res = true;
            if (pProj != null)
            {
                res = Dal.DeleteLinkWith<TParent, T, TLink>(pProj, proj);
            }

            return res && Dal.Delete(proj);
        }

        #region 树控件操作

        /// <summary>
        /// 构建树
        /// </summary>
        /// <param name="uTree"></param>
        /// <param name="images"></param>
        /// <param name="needUpdate">是否需要从数据库更新数据</param>
        /// <param name="exp"></param>
        public void BuildTree(ref UltraTree uTree, ImageList.ImageCollection images, LinkedList<string> needUpdate,
            Expression<Func<T, bool>> exp = null)
        {
            InitialDic();
            var children = Dal.Get(exp);
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

        public void AfterExpand(UltraTreeNode node, ImageList.ImageCollection images)
        {
            if (!ChildrenDic.ContainsKey(node.Key) || ChildrenDic[node.Key].IsNullOrEmpty()) return;
            node.Nodes.Clear();
            BuildSubTree(node, ChildrenDic[node.Key], images);
        }

        #endregion

        #region 虚方法

        /// <summary>
        /// 构建子树
        /// </summary>
        /// <param name="pNode"></param>
        /// <param name="children"></param>
        /// <param name="images"></param>
        protected virtual void BuildSubTree(UltraTreeNode pNode, IEnumerable<T> children,
            ImageList.ImageCollection images) //where TC:BaseModel,new()
        {
            throw new NotImplementedException("该方法为虚方法，调用前需重写");
        }

        #endregion

        #endregion
    }
}