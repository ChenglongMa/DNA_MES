// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/12 0:12
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using DnaMesModel.Model.BasicInfo;

namespace DnaMesModel.Link.BasicInfo
{
    /// <inheritdoc />
    /// <summary>
    /// 用户与权限关系类
    /// </summary>
    public class UserDomain : BaseLink<User, Domain>
    {
        public UserDomain(User roleA, Domain roleB) : base(roleA, roleB)
        {
        }

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