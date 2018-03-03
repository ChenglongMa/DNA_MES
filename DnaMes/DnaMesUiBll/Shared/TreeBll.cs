// ****************************************************
//  Author: Charles Ma
//  Date: 2018/03/02 15:17
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System.Collections.Generic;
using DnaMesModel;
using Infragistics.Win.UltraWinTree;

namespace DnaMesUiBll.Shared
{
    /// <summary>
    /// 树控件操作类
    /// </summary>
    public static class TreeBll
    {
        #region 私有字段


        #endregion

        #region 公有属性

        

        #endregion

        #region 私有方法


        #endregion

        #region 公有方法

        public static void BuildTree<T>(ref UltraTree uTree,List<T> dataSource) where T:BaseModel,new()
        {
            var root = uTree.TopNode;
            root.Nodes.Clear();
            BuildSubTree(root,dataSource);
            uTree.ExpandAll();
        }

        private static void BuildSubTree<T>(UltraTreeNode root, List<T> dataSource) where T : BaseModel, new()
        {
            foreach (var model in dataSource)
            {
                root.Nodes.Add();
            }
        }

        #endregion
    }
}

