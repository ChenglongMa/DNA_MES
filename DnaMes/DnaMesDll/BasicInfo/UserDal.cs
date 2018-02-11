// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/12 0:48
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System.Collections.Generic;
using DnaLib.Global;
using DnaMesModel.Model;
using DnaMesModel.Model.BasicInfo;

namespace DnaMesDal.BasicInfo
{
    /// <summary>
    /// 用户表操作类
    /// </summary>
    public static class UserDal
    {

        #region 私有字段


        #endregion

        #region 公有属性

        public static List<Domain> GetDomain(this User user)
        {
            var dal = new BaseDal<User>();
            dal.DbSimpleClient.GetById(user.EmpId);

        }

        #endregion

        #region 私有方法


        #endregion

        #region 公有方法


        #endregion
    }
}

