﻿// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/11 17:44
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using DnaLib;
using SqlSugar;

namespace DnaMesModel.BasicInfo
{
    /// <summary>
    /// 员工信息类
    /// </summary>
    [SugarTable("BasicInfo_Person")]
    public class Person : BaseModel
    {
        #region 私有字段

        private string _password;

        #endregion

        #region 公有属性

        [SugarColumn(IsNullable = false, Length = 10)]
        public string EmpId { get; set; }

        [SugarColumn(IsNullable = false, Length = 45)]
        public string Name { get; set; }

        [SugarColumn(IsNullable = false, Length = 100)]
        public string Password
        {
            get => EncryptHelper.DesDecrypt(_password, "DnaMes", "Person");
            set => _password = EncryptHelper.DesEncrypt(value, "DnaMes", "Person");
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