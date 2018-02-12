﻿// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/11 17:44
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using DnaLib;
using SqlSugar;

namespace DnaMesModel.Model.BasicInfo
{
    /// <summary>
    /// 员工信息类
    /// </summary>
    [SugarTable("BasicInfo_User")]
    public class User : BaseModel
    {
        #region 私有字段

        private string _password = "123456";//info:默认密码

        #endregion

        #region 公有属性

        [SugarColumn(IsNullable = false, Length = 10)]
        public string EmpId { get; set; }

        [SugarColumn(IsNullable = false, Length = 45)]
        public string Name { get; set; }

        [SugarColumn(IsNullable = false, Length = 100)]
        public string Password
        {
            get => _password;
            set => _password = value.Md5Hash();
        }

        [SugarColumn(IsNullable = true, Length = 45)]
        public string Tel { get; set; }

        [SugarColumn(IsNullable = true, Length = 250)]
        public string Addr { get; set; }

        [SugarColumn(IsNullable = true, Length = 45)]
        public string Email { get; set; }

        #endregion

        #region 私有方法

        #endregion

        #region 公有方法

        #endregion
    }
}