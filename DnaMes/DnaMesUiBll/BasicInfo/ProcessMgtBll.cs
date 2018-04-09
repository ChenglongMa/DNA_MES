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
using DnaMesUiBll.Shared;
using Infragistics.Win.UltraWinTree;

namespace DnaMesUiBll.BasicInfo
{
    /// <inheritdoc />
    /// <summary>
    /// 工艺管理业务类
    /// </summary>
    public class ProcessMgtBll:BaseBll<Process>
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

        public override bool UpdateModel<TParent>(Process model, TParent parent =null)
        {
            throw new NotImplementedException();
        }

        public new void AfterExpand(UltraTreeNode node, ImageList.ImageCollection images)
        {
            _projBll.AfterExpand(node, images);
        }

        public UltraTreeNode FindNode(UltraTree uTree, Project proj)
        {
            return _projBll.FindNode(uTree, proj);
        }
        public List<Project> GetDataSource(Expression<Func<Project, bool>> exp)
        {
            return _projBll.GetDataSource(exp);
        }

        public bool UpdateProcess(Process process, Project pProj)
        {
            throw new NotImplementedException();
        }
    }
}

