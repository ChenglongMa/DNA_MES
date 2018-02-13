// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/10 16:14
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DnaLib;
using DnaLib.Config;
using DnaLib.Global;
using DnaLib.Helper;
using DnaMesModel.Model;
using SqlSugar;

namespace DnaMesDal
{
    /// <summary>
    /// 数据库操作底层
    /// 用于重写或扩展SimpleClient类
    /// 该类只可继承不能实例化，子类需要每次new 一个新的实例
    /// </summary>
    public abstract class BaseDal<T> : SimpleClient<T> where T : BaseModel, new()
    {
        protected BaseDal() : base(DbClient)
        {
        }

        #region 私有字段

        /// <summary>
        /// 数据库实体
        /// 用来处理事务多表查询和复杂的操作
        /// 需要每次new 一个新的实例
        /// </summary>
        //TODO:修改访问符
        public static SqlSugarClient DbClient
        {
            get
            {
                var dbInfo = DbConfigLib.GetDbInfo();
                return new SqlSugarClient(new ConnectionConfig
                {
                    ConnectionString = dbInfo.ToString(),
                    DbType = dbInfo.DbType,
                    InitKeyType = InitKeyType.SystemTable //从数据库读取主键
                });
            }
        }

        #endregion

        #region 公有属性

        #endregion

        #region 私有方法

        /// <summary>
        /// 获取某属性是否为关键属性
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        protected static bool IsKey(string property)
        {
            var type = typeof(T);
            return (type.GetProperty(property) ?? throw new InvalidOperationException()).GetCustomAttribute(
                       typeof(DbColumnAttribute)) is DbColumnAttribute attr && attr.IsKey;
        }

        protected static IEnumerable<PropertyInfo> GetKeyProperties()
        {
            var type = typeof(T);
            var keys = type.GetProperties().Where(ppt => ppt.CanRead && ppt.CanWrite && IsKey(ppt.Name)).ToList();
            T t;
            var objIds = new List<PropertyInfo> {type.GetProperty(nameof(t.ObjId))};
            return keys.IsNullOrEmpty() ? objIds : keys;
        }

        /// <summary>
        /// 根据关键属性构建Where语句
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private static string BuildWhereString(T model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            var ppts = GetKeyProperties();
            var whereStr = "1=1 ";
            foreach (var ppt in ppts)
            {
                var value = ppt.GetValue(model, null);
                whereStr += " ANDs " + ppt.Name + "=" + value;
            }

            return whereStr;
        }

        #endregion

        #region 公有方法

        #region 增

        /// <summary>
        /// 插入并返回bool, 并将identity赋值到实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public new bool Insert(T model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (IsExist(model))
            {
                throw new Exception($"增：{nameof(model)}.Obj ID:{model.ObjId},该数据已存在");
            }

            if (model.Creator.IsNullOrEmpty())
            {
                model.Creator = SysInfo.EmpId + "@" + SysInfo.UserName;
                model.CreationTime = DateTime.Now;
            }

            //model.Modifier = SysInfo.EmpId + "@" + SysInfo.UserName;//Modifier有默认值
            model.ModifiedTime = DateTime.Now;
            return DbClient.Insertable(model).ExecuteCommandIdentityIntoEntity();
        }

        #endregion

        #region 删

        /// <summary>
        /// 从数据库中删除Model
        /// 根据关键属性而非主键
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public new bool Delete(T model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (!IsExist(model))
            {
                throw new Exception($"删：{nameof(model)}.Obj ID:{model.ObjId},该数据不存在");
            }

            return DbClient.Deleteable(model).Where(BuildWhereString(model)).ExecuteCommandHasChange();
        }

        #endregion

        #region 改

        public new bool Update(T model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (!IsExist(model))
            {
                throw new Exception($"改：{nameof(model)}.Obj ID:{model.ObjId},该数据不存在");
            }

            //TODO:待完善
            DbClient.Updateable(model).ToSql();

            return DbClient.Ado.ExecuteCommand(BuildWhereString(model)) > 0;
        }

        #endregion

        #region 查

        /// <summary>
        /// 根据Unique列查询是否已在数据库中存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool IsExist(T model)
        {
            return DbClient.Queryable<T>().Where(BuildWhereString(model)).Any();
        }

        #endregion

        #region 其他

        /// <summary>
        /// 代码自动判断插入或更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertOrUpdate(T model)
        {
            return IsExist(model) ? Update(model) : Insert(model);
        }

        #endregion

        #endregion
    }
}