// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/12 11:35
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System.Collections.Generic;
using DnaMesDal.BasicInfo;
using DnaMesModel.Model.BasicInfo;

namespace DnaMesBll.BasicInfo
{
    /// <summary>
    /// 用户业务扩展类
    /// </summary>
    public static class UserBll
    {
        #region 私有字段
        private static readonly UserDal Db=new UserDal();

        #endregion

        #region 公有属性
        /// <summary>
        /// 增加新员工
        /// </summary>
        /// <param name="user"></param>
        /// <returns>返回是否插入成功，并将Obj Id赋值到参数实体</returns>
        public static bool Insert(this User user)
        {
            return Db.Insert(user);
        }
        public static User GetUserById(string empId) => Db.GetById(empId);

        public static List<User> GetUsers() => Db.GetList();

        #endregion

        #region 私有方法


        #endregion

        #region 公有方法


        #endregion
    }
}

