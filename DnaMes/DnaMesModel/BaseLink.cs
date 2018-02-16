// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/11 23:39
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using DnaLib.Config;

namespace DnaMesModel
{
    /// <summary>
    /// 基础关系模型
    /// 必须将关系类放到roleA所在文件夹内
    /// 类名必须为roleA+roleB格式
    /// 例：User 和 Domain的关系类为UserDomain 路径与User相同
    /// </summary>
    /// <typeparam name="TA">角色A:1</typeparam>
    /// <typeparam name="TB">角色B:n</typeparam>
    public abstract class BaseLink<TA, TB> : BaseModel where TA : BaseModel where TB : BaseModel
    {
        [Obsolete("建议使用带参数构造函数")]
        protected BaseLink()
        {
            
        }
        protected BaseLink(TA roleA, TB roleB)
        {
            RoleA = roleA;
            RoleB = roleB;
        }

        #region 私有字段

        protected readonly TA RoleA;
        protected readonly TB RoleB;

        #endregion

        #region 公有属性

        /// <summary>
        /// 角色A的Obj ID
        /// </summary>
        [DnaColumn(IsKey = true,IsNullable = false)]
        public int RoleAId
        {
            get => RoleA.ObjId;
            set => RoleA.ObjId = value;
        }

        /// <summary>
        /// 角色B的Obj ID
        /// </summary>
        [DnaColumn(IsKey = true, IsNullable = false)]
        public int RoleBId
        {
            get => RoleB.ObjId;
            set => RoleB.ObjId = value;
        }

        #endregion

        #region 私有方法

        #endregion

        #region 公有方法

        #endregion
    }
}