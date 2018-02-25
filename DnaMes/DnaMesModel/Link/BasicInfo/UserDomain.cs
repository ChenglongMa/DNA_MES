// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/12 0:12
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using DnaMesModel.Model.BasicInfo;
using SqlSugar;

namespace DnaMesModel.Link.BasicInfo
{
    /// <inheritdoc />
    /// <summary>
    /// 用户与权限关系类
    /// </summary>
    [SugarTable("L_" + nameof(User) + nameof(Domain))]
    public class UserDomain : BaseLink
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