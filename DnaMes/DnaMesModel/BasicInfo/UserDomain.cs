// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/12 0:12
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using SqlSugar;

namespace DnaMesModel.BasicInfo
{
    /// <inheritdoc />
    /// <summary>
    /// 用户与权限关系类
    /// </summary>
    [SugarTable("Link_BasicInfo_UserDomain")]
    public class UserDomain : BaseLink<User, Domain>
    {
        public UserDomain(User roleA, Domain roleB) : base(roleA, roleB)
        {
        }

        //[Obsolete]
        public UserDomain()
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