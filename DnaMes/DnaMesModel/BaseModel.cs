// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/09 14:05
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using SqlSugar;

namespace DnaMesModel
{
    public abstract class BaseModel
    {
        [SugarColumn(IsNullable = false)] public int ClassId { get; set; }

        [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
        public int ObjId { get; set; }

        [SugarColumn(IsNullable = false, Length = 45)]
        public string Creator { get; set; } = "admin";

        [SugarColumn(IsNullable = false)] public DateTime CreationTime { get; set; } = DateTime.Now;

        [SugarColumn(IsNullable = false, Length = 45)]
        public string Modifier { get; set; } = "admin";

        [SugarColumn(IsNullable = false)] public DateTime ModifiedTime { get; set; } = DateTime.Now;

        [SugarColumn(Length = 250)] public string Description { get; set; }
    }
}