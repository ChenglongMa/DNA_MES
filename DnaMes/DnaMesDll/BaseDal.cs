// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/10 16:14
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using DnaLib;
using DnaMesModel.Model;
using SqlSugar;

namespace DnaMesDal
{
    /// <summary>
    /// 数据库操作底层
    /// 用于重写或扩展SimpleClient类
    /// </summary>
    internal class BaseDal<T> : SimpleClient<T> where T : BaseModel, new()
    {
        public BaseDal() : base(DbClient)
        {
        }

        #region 私有字段

        /// <summary>
        /// 数据库实体
        /// 用来处理事务多表查询和复杂的操作
        /// 需要每次new 一个新的实例
        /// </summary>
        private static SqlSugarClient DbClient
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

        /// <summary>
        /// 数据库实体
        /// 用来处理单表常用操作
        /// 需要每次new 一个新的实例
        /// </summary>
        //public static SimpleClient<T> DbSimpleClient=>new SimpleClient<T>(DbClient);

        #endregion

        #region 私有方法

        #endregion

        #region 公有方法
        public new bool Insert(T model) => DbClient.Insertable(model).ExecuteCommandIdentityIntoEntity();

        #endregion
    }
}