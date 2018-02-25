// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/09 14:05
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using System.Collections.Generic;
using System.Reflection;
using DnaLib.Config;
using DnaMesModel.Shared;

namespace DnaMesModel
{
    public abstract class BaseModel
    {
        //[DbColumn(IsNullable = false)] public abstract int ClassId { get;}
        //[Obsolete("不建议主动修改")]
        /// <summary>
        /// 对象ID
        /// </summary>
        [DnaColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true, IsOnlyIgnoreInsert = true)]
        public int ObjId { get; set; } = -1;

        /// <summary>
        /// 创建者
        /// </summary>
        [DnaColumn(IsNullable = false, Length = 45)]
        public string Creator { get; set; } //= SysInfo.EmpId + "@" + SysInfo.UserName;

        /// <summary>
        /// 创建时间
        /// </summary>
        [DnaColumn(IsNullable = false)]
        public DateTime CreationTime { get; set; } //= DateTime.Now;

        /// <summary>
        /// 修改者
        /// </summary>
        [DnaColumn(IsNullable = false, Length = 45)]
        public string Modifier { get; set; } = SysInfo.EmpId + "@" + SysInfo.UserName;

        /// <summary>
        /// 修改时间
        /// </summary>
        [DnaColumn(IsNullable = false)]
        public DateTime ModifiedTime { get; set; } //= DateTime.Now;

        /// <summary>
        /// 描述
        /// </summary>
        [DnaColumn(IsNullable = true, Length = 250)]
        public string Description { get; set; }

        /// <summary>
        /// 扩展属性记录
        /// </summary>
        [DnaColumn(IsIgnore = true)]
        public Dictionary<string, object> ValueDict { get; set; } = new Dictionary<string, object>();

        #region 公有方法

        #endregion
    }
}