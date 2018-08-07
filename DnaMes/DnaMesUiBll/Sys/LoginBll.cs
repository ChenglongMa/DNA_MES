// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/19 13:49
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using DnaLib.Helper;
using DnaMesDal;
using DnaMesModel.Model.BasicInfo;
using DnaMesModel.Shared;

namespace DnaMesUiBll.Sys
{
    /// <summary>
    /// 登录相关操作
    /// </summary>
    public static class LoginBll
    {
        #region 私有字段

        private static readonly BaseDal<User> Dal = new BaseDal<User>();

        #endregion

        #region 公有属性

        #endregion

        #region 私有方法

        #endregion

        #region 公有方法

        /// <summary>
        /// Check if the user can login
        /// Initialise the system default setting
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool CanLogin(User user)
        {
            var res = Dal.Get(u => u.EmpId == user.EmpId && u.Password == user.Password);
            var logUser = res.Single();
            SysInfo.EmpId = logUser.EmpId;
            SysInfo.UserName = logUser.Name;
            SysInfo.LoginTime = DateTime.Now;
            var domains = Dal.GetChildren<Domain>(logUser) ?? new List<Domain>();
            foreach (var domain in domains)
            {
                SysInfo.Domains.Add(domain.FunctionCode);
            }

            return res.IsNotNullorEmpty();
        }

        #endregion
    }
}