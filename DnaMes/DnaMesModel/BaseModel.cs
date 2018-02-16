// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/09 14:05
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using System.Reflection;
using DnaLib.Config;
using DnaLib.Global;
using DnaMesModel.BasicInfo;

namespace DnaMesModel
{
    public abstract class BaseModel
    {
        protected BaseModel()
        {
        }

        //[DbColumn(IsNullable = false)] public abstract int ClassId { get;}

        [DnaColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true, IsOnlyIgnoreInsert = true)]
        public int ObjId { get; set; } = -1;

        [DnaColumn(IsNullable = false, Length = 45)]
        public string Creator { get; set; } //= SysInfo.EmpId + "@" + SysInfo.UserName;

        [DnaColumn(IsNullable = false)] public DateTime CreationTime { get; set; } //= DateTime.Now;

        [DnaColumn(IsNullable = false, Length = 45)]
        public string Modifier { get; set; }= SysInfo.EmpId + "@" + SysInfo.UserName;

        [DnaColumn(IsNullable = false)] public DateTime ModifiedTime { get; set; } //= DateTime.Now;

        [DnaColumn(IsNullable = true,Length = 250)] public string Description { get; set; }

        #region 公有方法

        public virtual dynamic GetLinkWith<T>(T roleB) where T : BaseModel, new()
        {
            var tA = GetType();
            var tB = typeof(T);
            var linkFullName = tA.FullName + tB.Name;
            var linkName = tA.Name + tB.Name;
            var linkType = Assembly.Load(nameof(DnaMesModel)).GetType(linkFullName) 
                           ?? throw new Exception($"映射关系类失败，请检查：\n1. 是否存在关系类{linkName}\n2. {linkName}是否与{tA.Name}在同一文件夹下");
            var linkInstance = Activator.CreateInstance(linkType, this, roleB);
            return linkInstance;
        }

        #endregion
    }
}