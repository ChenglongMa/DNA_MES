// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/09 15:11
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using DnaMesModel.Config;
using DnaMesModel.Global;
using SqlSugar;

namespace DnaMesDll
{
    /// <summary>
    ///     DllDataConfig类
    /// </summary>
    public class DllDbConfig
    {
        #region 私有字段

        #endregion

        #region 公有属性

        #endregion

        #region 私有方法

        #endregion

        #region 公有方法
        #region DataBase.config

        private readonly DbConfig _dataConfig =(DbConfig)ConfigurationManager.GetSection("DbConfig");

        private List<DbConnection> GetDbInfos()
        {
            return _dataConfig.DbCollection.Cast<DbConnection>().ToList();
        }

        /// <summary>
        /// 获取数据库配置
        /// </summary>
        /// <param name="name">模块名称</param>
        /// <returns></returns>
        public DbConnection GetDbInfo(DbInfoName name)
        {
            return GetDbInfos().Find(db => db.Name == name) ?? new DbConnection();
        }

        /// <summary>
        /// 保存数据库配置
        /// </summary>
        /// <param name="dbConnection"></param>
        public void SetDbInfo(DbConnection dbConnection)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var integrationDbConfig = (DbConfig)config.GetSection("DbConfig");
            integrationDbConfig.DbCollection.Remove(dbConnection.Name.ToString());
            integrationDbConfig.DbCollection.Add(dbConnection);
            config.Save();
        }

        #endregion
        #endregion
    }
}