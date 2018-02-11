// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/11 23:39
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using DnaMesModel.Model;
using SqlSugar;

namespace DnaMesModel.Link
{
    /// <summary>
    /// 基础关系模型
    /// </summary>
    /// <typeparam name="TA">角色A</typeparam>
    /// <typeparam name="TB">角色B</typeparam>
    public abstract class BaseLink<TA, TB> : BaseModel where TA : BaseModel where TB : BaseModel
    {
        protected BaseLink(TA roleA, TB roleB)
        {
            _roleA = roleA;
            _roleB = roleB;
        }

        #region 私有字段

        private readonly TA _roleA;
        private readonly TB _roleB;

        #endregion

        #region 公有属性

        /// <summary>
        /// 角色A的Obj ID
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public int RoleAId => _roleA.ObjId;

        /// <summary>
        /// 角色B的Obj ID
        /// </summary>
        [SugarColumn(IsNullable = false)]
        public int RoleBId => _roleB.ObjId;

        #endregion

        #region 私有方法

        #endregion

        #region 公有方法

        #endregion
    }
}