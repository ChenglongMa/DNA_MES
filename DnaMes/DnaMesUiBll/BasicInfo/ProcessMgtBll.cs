// ****************************************************
//  Author: Charles Ma
//  Date: 2018/04/08 23:28
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Windows.Forms;
using DnaMesModel.Model.BasicInfo;
using Infragistics.Win.UltraWinTree;

namespace DnaMesUiBll.BasicInfo
{
    /// <summary>
    /// 工艺管理业务类
    /// </summary>
    public class ProcessMgtBll
    {
        #region 私有字段
        private readonly ProjectMgtBll _projBll=new ProjectMgtBll();

        #endregion

        #region 公有属性

        

        #endregion

        #region 私有方法


        #endregion

        #region 公有方法

        public void BuildTree(ref UltraTree uTree, ImageList.ImageCollection images)
        {
            _projBll.BuildTree(ref uTree, images, null, p => p.IsMain);
        }

        #endregion

        public Expression<Func<Project, bool>> BuildExp(string code, string name, DateTime startTime, DateTime endTime)
        {
            return _projBll.BuildExp(code, name, startTime, endTime);
        }

        public List<Project> GetDataSource(Expression<Func<Project, bool>> exp)
        {
            return _projBll.GetDataSource(exp);
        }

        public void AfterExpand(UltraTreeNode node, ImageList.ImageCollection images)
        {
            _projBll.AfterExpand(node, images, null);
        }

        public List<Process> GetProcesses(SelectedNodesCollection nodes)
        {
            throw new NotImplementedException();
        }
    }
}

