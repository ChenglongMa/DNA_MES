// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/09 15:11
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using DnaMesModel.Config;

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

        private readonly DbConfig _dataConfig =(DbConfig)ConfigurationManager.GetSection("DataConfig");

        private List<DbInfo> GetDbInfos()
        {
            return _dataConfig.DbCollection.Cast<DbInfo>().ToList();
        }

        /// <summary>
        /// 获取数据库配置
        /// </summary>
        /// <param name="name">模块名称</param>
        /// <returns></returns>
        public DbInfo GetDbInfo(string name)
        {
            return GetDbInfos().Find(db => db.Name == name) ?? new DbInfo();
        }

        /// <summary>
        /// 保存数据库配置
        /// </summary>
        /// <param name="dbInfo"></param>
        public void SetDbInfo(DbInfo dbInfo)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var integrationDbConfig = (DbConfig)config.GetSection("DataConfig");
            integrationDbConfig.DbCollection.Remove(dbInfo.Name);
            integrationDbConfig.DbCollection.Add(dbInfo);
            config.Save();
        }

        #endregion
        #endregion
    }
}