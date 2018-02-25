// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/11 17:44
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using DnaLib.Config;
using DnaLib.Helper;
using SqlSugar;

namespace DnaMesModel.Model.BasicInfo
{
    /// <summary>
    /// 员工信息类
    /// </summary>
    [SugarTable("BasicInfo_User")]
    public class User : BaseModel
    {
        public User()
        {
            Password = "123456"; //info:默认密码
        }

        #region 私有字段

        private string _password;

        #endregion

        #region 公有属性

        //todo:目前无法指定unique列--使用代码层关键属性代替，未在数据库中设置Unique列
        [DnaColumn(IsNullable = false, Length = 10, IsKey = true)]
        public string EmpId { get; set; }

        [DnaColumn(IsNullable = false, Length = 45)]
        public string Name { get; set; }

        [DnaColumn(IsNullable = false, Length = 100)]
        public string Password
        {
            get => _password;
            set => _password = value.Md5Hash();
        }

        [DnaColumn(IsNullable = true, Length = 45)]
        public string Tel { get; set; }

        [DnaColumn(IsNullable = true, Length = 250)]
        public string Addr { get; set; }

        [DnaColumn(IsNullable = true, Length = 45)]
        public string Email { get; set; }

        #endregion

        #region 私有方法

        #endregion

        #region 公有方法

        #endregion
    }
}