// ****************************************************
//  Author: Charles Ma
//  Date: 2018/03/23 23:33
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using DnaMesModel.Model.BasicInfo;
using SqlSugar;

namespace DnaMesModel.Link.BasicInfo
{
    /// <inheritdoc />
    /// <summary>
    /// 项目与项目关系类
    /// </summary>
    [SugarTable("L_" + nameof(Project) + nameof(Project))]
    public class ProjectProject : BaseLink
    {
        #region 私有字段

        #endregion

        #region 公有属性

        #endregion

        #region 私有方法

        #endregion

        #region 公有方法

        #endregion
    }
}