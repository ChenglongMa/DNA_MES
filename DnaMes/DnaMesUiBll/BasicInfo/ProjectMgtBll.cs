// ****************************************************
//  Author: Charles Ma
//  Date: 2018/03/02 14:12
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System.Collections.Generic;
using System.Windows.Forms;
using DnaLib.Helper;
using DnaMesModel;
using DnaMesModel.Model.BasicInfo;
using Infragistics.Win.UltraWinTree;

namespace DnaMesUiBll.BasicInfo
{
    /// <summary>
    /// 项目管理窗体操作
    /// </summary>
    public class ProjectMgtBll
    {
        #region 私有字段

        #endregion

        #region 公有属性

        #endregion

        #region 私有方法

        private static void BuildSubTree(UltraTreeNode root, List<Project> dataSource, ImagesCollection images)
        {
            foreach (var model in dataSource)
            {
                var node = root.Nodes.Add(model.Code, model.Name);
                if (!images.IsNullOrEmpty() && images.Count >= node.Level + 2)
                {
                    node.LeftImages.Clear();
                    node.LeftImages.Add(images[node.Level + 2]);
                }

                var children = model.Children;
                BuildSubTree(node,children,images);
            }
        }

        #endregion

        #region 公有方法

        #endregion
    }
}