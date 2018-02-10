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
    public static class DllDbConfig
    {
        #region 私有字段

        #endregion

        #region 公有属性

        #endregion

        #region 私有方法

        #endregion

        #region 公有方法
        #region DataBase.config

        private static readonly Configuration Config =
            ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        private static List<DbInfo> GetDbInfos()
        {
            return (Config.GetSection("DbConfig") as DbConfig)?.DbCollection.Cast<DbInfo>().ToList();
        }

        /// <summary>
        /// 获取数据库配置
        /// </summary>
        /// <param name="name">模块名称</param>
        /// <returns></returns>
        public static DbInfo GetDbInfo(DbInfoName name)
        {
            return GetDbInfos().Find(db => db.Name == name) ?? new DbInfo();
        }

        /// <summary>
        /// 保存数据库配置
        /// </summary>
        /// <param name="dbInfo"></param>
        public static void SetDbInfo(this DbInfo dbInfo)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var dbConfig = (DbConfig)config.GetSection("DbConfig");
            dbConfig.DbCollection.Remove(dbInfo.Name);
            dbConfig.DbCollection.Add(dbInfo);
            config.Save();
        }

        #endregion
        #endregion
    }
}