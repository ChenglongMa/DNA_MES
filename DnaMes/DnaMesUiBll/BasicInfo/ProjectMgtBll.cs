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
using Infragistics.Win.UltraWinTree;

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
        public void BuildTree(ref UltraTree uTree, ImagesCollection images, Expression<Func<Project, bool>> exp = null)
        {
            var children = _dal.Get(exp);
            var root = uTree.TopNode;
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
        private void BuildSubTree(UltraTreeNode pNode, IEnumerable<Project> children, ImagesCollection images)
        {
            foreach (var model in children)
            {
                var cNode = pNode.Nodes.Add(model.Code, model.Name);
                //设置图片
                if (!images.IsNullOrEmpty() && images.Count >= cNode.Level + 2)
                {
                    cNode.LeftImages.Clear();
                    cNode.LeftImages.Add(images[cNode.Level + 2]);
                }

                var grandChildren = _dal.GetLinkWith<Project>(model);
                BuildSubTree(cNode, grandChildren, images);
            }
        }
    }
}