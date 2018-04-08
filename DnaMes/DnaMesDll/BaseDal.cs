// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/10 16:14
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using DnaLib;
using DnaLib.Config;
using DnaLib.Helper;
using DnaMesModel;
using DnaMesModel.Shared;
using SqlSugar;

namespace DnaMesDal
{
    /// <summary>
    /// 数据库操作底层
    /// 用于重写或扩展SimpleClient类
    /// 该类需要每次new 一个新的实例
    /// </summary>
    public class BaseDal<T> : BaseDal where T : BaseModel, new()
    {
        #region 私有字段

        #endregion

        #region 公有属性

        #endregion

        #region 私有方法

        #endregion

        #region 公有方法

        #region 增

        #endregion

        #region 删

        /// <summary>
        /// 根据关键属性删除Model
        /// TODO:如何删除依赖关系
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(T model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (!IsExist(model))
            {
                throw new ArgumentException($"删：{typeof(T).Name}[{model.ObjId}],该数据不存在");
            }

            Refresh(ref model);
            return DbClient.Deleteable<T>().Where(BuildWhereString(model)).ExecuteCommandHasChange();
        }

        #endregion

        #region 改

        #endregion

        #region 查

        /// <summary>
        /// 根据条件获取相应Model集合
        /// </summary>
        /// <param name="exp">Lambda表达式</param>
        /// <returns></returns>
        public List<T> Get(Expression<Func<T, bool>> exp)
        {
            return exp == null ? DbClient.Queryable<T>().ToList() : DbClient.Queryable<T>().Where(exp).ToList();
        }

        /// <summary>
        /// 根据SQL Where字符串获取相应Model集合
        /// </summary>
        /// <param name="whereString">where 字符串</param>
        /// <returns></returns>
        public List<T> Get(string whereString = null)
        {
            return DbClient.Queryable<T>().Where(whereString).ToList();
        }

        /// <summary>
        /// 根据condition List获取相应Model集合
        /// </summary>
        /// <param name="cons"></param>
        /// <returns></returns>
        public List<T> Get(List<IConditionalModel> cons)
        {
            return DbClient.Queryable<T>().Where(cons).ToList();
        }

        #endregion

        #region 其他

        #endregion

        #region 关系操作

        /// <summary>
        /// 通过关系获取另一实体类
        /// </summary>
        /// <typeparam name="TB">要获得的对象</typeparam>
        /// <typeparam name="TLink">特殊的关系类</typeparam>
        /// <param name="roleA">已知对象</param>
        /// <param name="exp">额外条件表达式</param>
        /// <returns>所求对象集合</returns>
        protected virtual List<TB> GetChildren<TB, TLink>(T roleA, Expression<Func<TB, bool>> exp = null)
            where TB : BaseModel, new() where TLink : BaseLink, new()
        {
            if (!IsExist(roleA))
            {
                throw new ArgumentException($"{typeof(T).Name}[{roleA.ObjId}]不存在", nameof(roleA));
            }

            Refresh(ref roleA);
            var children = DbClient.Queryable<TLink>().AS("L_" + typeof(T).Name + typeof(TB).Name)
                .Where(l => l.RoleAId == roleA.ObjId).ToList();
            if (children.IsNullOrEmpty())
            {
                return null;
            }

            var expTemp = new Expressionable<TB>();
            foreach (var link in children)
            {
                expTemp.Or(b => b.ObjId == link.RoleBId);
            }

            return DbClient.Queryable<TB>().Where(expTemp.AndIF(exp != null, exp).ToExpression()).ToList();
        }

        /// <summary>
        /// 通过关系获取子类
        /// </summary>
        /// <typeparam name="TB">要获得的对象</typeparam>
        /// <param name="roleA">已知对象</param>
        /// <param name="exp">额外条件表达式</param>
        /// <returns>所求对象集合</returns>
        public List<TB> GetChildren<TB>(T roleA, Expression<Func<TB, bool>> exp = null)
            where TB : BaseModel, new()
        {
            return GetChildren<TB, BaseLink>(roleA, exp);
        }

        protected T GetParent<TB, TLink>(TB roleB, Expression<Func<TB, bool>> exp = null)
            where TB : BaseModel, new() where TLink : BaseLink, new()
        {
            if (!IsExist(roleB))
            {
                throw new ArgumentException($"{typeof(T).Name}[{roleB.ObjId}]不存在", nameof(roleB));
            }

            Refresh(ref roleB);
            var parent = DbClient.Queryable<TLink>().AS("L_" + typeof(T).Name + typeof(TB).Name)
                .Where(l => l.RoleBId == roleB.ObjId).First();
            return parent == null ? null : DbClient.Queryable<T>().Where(p => p.ObjId == parent.RoleAId).First();
        }

        /// <summary>
        /// 通过关系获取父类
        /// </summary>
        /// <typeparam name="TB"></typeparam>
        /// <param name="roleB"></param>
        /// <param name="exp"></param>
        /// <returns></returns>
        public T GetParent<TB>(TB roleB, Expression<Func<TB, bool>> exp = null)
            where TB : BaseModel, new()
        {
            return GetParent<TB, BaseLink>(roleB, exp);
        }

        #endregion

        #endregion
    }

    public class BaseDal //:SimpleClient<T>
    {
        #region 私有及继承方法

        /// <summary>
        /// 数据库实体
        /// 用来处理事务多表查询和复杂的操作
        /// 需要每次new 一个新的实例
        /// </summary>
        protected static SqlSugarClient DbClient
        {
            get
            {
                var dbInfo = DbConfigHelper.GetDbInfo();
                return new SqlSugarClient(new ConnectionConfig
                {
                    ConnectionString = dbInfo.ToString(),
                    DbType = dbInfo.DbType,
                    InitKeyType = InitKeyType.SystemTable //从数据库读取主键
                });
            }
        }

        private static SqlSugarClient DbSysClient
        {
            get
            {
                var dbInfo = DbConfigHelper.GetDbInfo();
                return new SqlSugarClient(new ConnectionConfig
                {
                    ConnectionString = dbInfo.ToString(),
                    DbType = dbInfo.DbType,
                    InitKeyType = InitKeyType.Attribute //从特性中读取主键
                });
            }
        }

        /// <summary>
        /// 获取某属性是否为关键属性
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        protected static bool IsKey<T>(string property) where T : BaseModel
        {
            var type = typeof(T);
            return (type.GetProperty(property) ?? throw new InvalidOperationException()).GetCustomAttribute(
                       typeof(DnaColumnAttribute)) is DnaColumnAttribute attr && attr.IsKey;
        }

        protected static IEnumerable<PropertyInfo> GetKeyProperties<TB>() where TB : BaseModel
        {
            var type = typeof(TB);
            var keys = type.GetProperties().Where(ppt => ppt.CanRead && ppt.CanWrite && IsKey<TB>(ppt.Name)).ToList();
            TB t;
            var objIds = new List<PropertyInfo> {type.GetProperty(nameof(t.ObjId))};
            return keys.IsNullOrEmpty() ? objIds : keys;
        }

        /// <summary>
        /// 根据关键属性构建Where语句
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        protected static string BuildWhereString<T>(T model) where T : BaseModel
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            var ppts = GetKeyProperties<T>();
            var whereStr = "1=1 ";
            foreach (var ppt in ppts)
            {
                var value = ppt.GetValue(model, null);
                whereStr += " AND " + ppt.Name + " = '" + value + "'";
            }

            return whereStr;
        }

        protected static List<ConditionalModel> BuildWhereConditions<T>(T model) where T : BaseModel
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            var ppts = GetKeyProperties<T>();

            return (from ppt in ppts
                let value = ppt.GetValue(model, null)
                select new ConditionalModel
                {
                    ConditionalType = ConditionalType.Equal,
                    FieldName = ppt.Name,
                    FieldValue = value.ToString()
                }).ToList();
        }

        #endregion

        #region 增

        /// <summary>
        /// 在数据库中增加表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void CreateTable<T>() where T : new()
        {
            DbSysClient.CodeFirst.InitTables(typeof(T));
        }

        /// <summary>
        /// 插入并返回bool, 并将identity赋值到实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Insert<T>(T model) where T : BaseModel, new()
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (IsExist(model))
            {
                throw new ArgumentException($"增：{typeof(T).Name}[{model.ObjId}]:该数据已存在", nameof(model));
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

        #region 改

        /// <summary>
        /// 根据关键属性更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //TODO:效率较低
        public bool Update<T>(T model) where T : BaseModel, new()
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (!IsExist(model))
            {
                throw new ArgumentException($"改：{typeof(T).Name}[{model.ObjId}]:该数据不存在");
            }

            //查询库内该数据ObjId并赋值给新model
            var m = DbClient.Queryable<T>().Where(BuildWhereString(model)).Single();
            model.ObjId = m.ObjId;
            model.ModifiedTime = DateTime.Now;
            model.Creator = m.Creator;
            model.CreationTime = m.CreationTime;
            return DbClient.Updateable(model).ExecuteCommandHasChange();
        }

        #endregion

        #region 查

        /// <summary>
        /// 根据关键属性查询是否已在数据库中存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool IsExist<T>(T model) where T : BaseModel, new()
        {
            return DbClient.Queryable<T>().Where(BuildWhereString(model)).Any();
        }

        /// <summary>
        /// 根据关键属性查询库内数据并将其他属性更新
        /// </summary>
        /// <param name="model"></param>
        public void Refresh<T>(ref T model) where T : BaseModel, new()
        {
            model = DbClient.Queryable<T>().Where(BuildWhereString(model)).Single();
        }

        #endregion

        #region 其他

        /// <summary>
        /// 代码自动判断插入或更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertOrUpdate<T>(T model) where T : BaseModel, new()
        {
            return IsExist(model) ? Update(model) : Insert(model);
        }

        #endregion

        #region 关系操作

        [Obsolete]
        private dynamic GetLinkWith<T, TB>(T roleA, TB roleB) where T : BaseModel, new() where TB : BaseModel, new()
        {
            var tA = typeof(T);
            var tB = typeof(TB);
            var linkFullName = tA.FullName + tB.Name;
            var linkName = tA.Name + tB.Name;
            var linkType = Assembly.Load(nameof(DnaMesModel)).GetType(linkFullName)
                           ?? throw new Exception(
                               $"映射关系类失败，请检查：\n1. 是否存在关系类{linkName}\n2. {linkName}是否与{tA.Name}在同一文件夹下");
            var linkInstance = Activator.CreateInstance(linkType, roleA, roleB);
            return linkInstance;
        }

        /// <summary>
        /// 检查关系是否存在
        /// </summary>
        /// <typeparam name="TA"></typeparam>
        /// <typeparam name="TB"></typeparam>
        /// <param name="roleA"></param>
        /// <param name="roleB"></param>
        /// <returns></returns>
        private bool IsExistLink<TA, TB>(ref TA roleA, ref TB roleB)
            where TA : BaseModel, new() where TB : BaseModel, new()
        {
            if (!IsExist(roleA) || !IsExist(roleB))
            {
                return false;
            }

            Refresh(ref roleA);
            Refresh(ref roleB);
            var link = new BaseLink
            {
                RoleAId = roleA.ObjId,
                RoleBId = roleB.ObjId,
            };
            var tableName = "L_" + typeof(TA).Name + typeof(TB).Name;
            return DbClient.Queryable<BaseLink>().AS(tableName).Where(BuildWhereString(link)).Any();
        }

        /// <summary>
        /// 删除关系
        /// </summary>
        /// <typeparam name="TA"></typeparam>
        /// <typeparam name="TB"></typeparam>
        /// <typeparam name="TLink">roleA,roleB关系类</typeparam>
        /// <param name="roleA"></param>
        /// <param name="roleB"></param>
        /// <returns></returns>
        public bool DeleteLinkWith<TA, TB, TLink>(TA roleA, TB roleB)
            where TA : BaseModel, new()
            where TB : BaseModel, new()
            where TLink : BaseLink, new()
        {
            var tableName = "L_" + typeof(TA).Name + typeof(TB).Name;
            if (IsExistLink(ref roleA, ref roleB))
            {
                var link = new TLink
                {
                    RoleAId = roleA.ObjId,
                    RoleBId = roleB.ObjId,
                };
                Refresh(ref link);
                return DbClient.Deleteable(link).ExecuteCommandHasChange();
            }

            throw new ArgumentException($"{typeof(TA).Name}[{roleA.ObjId}]与{typeof(TB).Name}[{roleB.ObjId}]关系不存在",
                tableName);
        }

        /// <summary>
        /// 建立关系
        /// </summary>
        /// <typeparam name="TA"></typeparam>
        /// <typeparam name="TB"></typeparam>
        /// <param name="roleA"></param>
        /// <param name="roleB"></param>
        /// <returns></returns>
        public bool SetLinkWith<TA, TB>(TA roleA, TB roleB) where TA : BaseModel, new() where TB : BaseModel, new()
        {
            var tableName = "L_" + typeof(TA).Name + typeof(TB).Name;
            if (IsExistLink(ref roleA, ref roleB))
            {
                throw new ArgumentException($"{typeof(TA).Name}[{roleA.ObjId}]与{typeof(TB).Name}[{roleB.ObjId}]关系已存在",
                    tableName);
            }

            Refresh(ref roleA);
            Refresh(ref roleB);
            var link = new BaseLink
            {
                RoleAId = roleA.ObjId,
                RoleBId = roleB.ObjId,
                Creator = SysInfo.EmpId + "@" + SysInfo.UserName,
                CreationTime = DateTime.Now,
                Modifier = SysInfo.EmpId + "@" + SysInfo.UserName,
                ModifiedTime = DateTime.Now,
            };
            return DbClient.Insertable(link).AS(tableName).ExecuteCommandIdentityIntoEntity();
        }

        #endregion
    }
}