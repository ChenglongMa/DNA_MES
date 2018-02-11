// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/09 14:05
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using DnaLib.Global;
using SqlSugar;

namespace DnaMesModel.Model
{
    public abstract class BaseModel
    {
        protected BaseModel()
        {
        }

        //[SugarColumn(IsNullable = false)] public abstract int ClassId { get;}

        [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
        public int ObjId { get; set; }

        [SugarColumn(IsNullable = false, Length = 45)]
        public string Creator { get; set; } = SysInfo.EmpId + "@" + SysInfo.UserName;

        [SugarColumn(IsNullable = false)] public DateTime CreationTime { get; set; } = DateTime.Now;

        [SugarColumn(IsNullable = false, Length = 45)]
        public string Modifier { get; set; }= SysInfo.EmpId + "@" + SysInfo.UserName;

        [SugarColumn(IsNullable = false)] public DateTime ModifiedTime { get; set; } = DateTime.Now;

        [SugarColumn(Length = 250)] public string Description { get; set; }
    }
}