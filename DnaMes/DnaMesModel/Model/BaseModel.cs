// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/09 14:05
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using DnaLib.Config;
using DnaLib.Global;
using SqlSugar;

namespace DnaMesModel.Model
{
    public abstract class BaseModel
    {
        protected BaseModel()
        {
        }

        //[DbColumn(IsNullable = false)] public abstract int ClassId { get;}

        [DbColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true, IsOnlyIgnoreInsert = true)]
        public int ObjId { get; set; } = -1;

        [DbColumn(IsNullable = false, Length = 45)]
        public string Creator { get; set; } //= SysInfo.EmpId + "@" + SysInfo.UserName;

        [DbColumn(IsNullable = false)] public DateTime CreationTime { get; set; } //= DateTime.Now;

        [DbColumn(IsNullable = false, Length = 45)]
        public string Modifier { get; set; }= SysInfo.EmpId + "@" + SysInfo.UserName;

        [DbColumn(IsNullable = false)] public DateTime ModifiedTime { get; set; } //= DateTime.Now;

        [DbColumn(IsNullable = true,Length = 250)] public string Description { get; set; }
    }
}