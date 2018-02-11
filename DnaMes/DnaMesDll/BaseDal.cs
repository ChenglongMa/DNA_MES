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
    /// </summary>
    public class BaseDal<T> where T:BaseModel, new()
    {
        public BaseDal()
        {
            var dbInfo = DbConfigLib.GetDbInfo();
            DbClient=new SqlSugarClient(new ConnectionConfig
            {
                ConnectionString = dbInfo.ToString(),
                DbType = dbInfo.DbType,
                InitKeyType = InitKeyType.SystemTable
            });
        }

        #region 私有字段

        #endregion

        #region 公有属性
        /// <summary>
        /// 数据库实体
        /// 用来处理事务多表查询和复杂的操作
        /// </summary>
        public SqlSugarClient DbClient { get; }
        /// <summary>
        /// 数据库实体
        /// 用来处理单表常用操作
        /// </summary>
        public SimpleClient<T> DbSimpleClient=>new SimpleClient<T>(DbClient);
        #endregion

        #region 私有方法


        #endregion

        #region 公有方法


        #endregion

    }
}

