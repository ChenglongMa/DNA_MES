// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/11 23:39
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using System.Reflection;
using DnaLib.Config;

namespace DnaMesModel
{
    /// <summary>
    /// 基础关系模型
    /// 数据库中表名格式为 "L_"+"roleA类名"+"roleB类名"
    /// 1. 必须将关系类放到roleA所在文件夹内
    /// 2. 类名必须为roleA+roleB格式
    /// 例：User 和 Domain的关系类为UserDomain 路径与User相同
    /// </summary>
    public class BaseLink : BaseModel
    {
        #region 私有字段

        #endregion

        #region 公有属性

        /// <summary>
        /// 角色A的Obj ID
        /// </summary>
        [DnaColumn(IsKey = true,IsNullable = false)]
        public int RoleAId { get; set; }

        /// <summary>
        /// 角色B的Obj ID
        /// </summary>
        [DnaColumn(IsKey = true, IsNullable = false)]
        public int RoleBId { get; set; }

        #endregion

        #region 私有方法

        #endregion

        #region 公有方法
        #endregion
    }
}