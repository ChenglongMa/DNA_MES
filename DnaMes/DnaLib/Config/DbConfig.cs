// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/09 14:41
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using System.Configuration;
//using System.Data;
using System.Data.Common;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Data.SQLite;
using Devart.Data.PostgreSql;
using DnaLib.Helper;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using SqlSugar;

namespace DnaLib.Config
{
    /// <inheritdoc />
    /// <summary>
    ///     数据库配置类 in app.config
    /// 修改该名称及路径时需要一并修改app.config文件内容
    /// </summary>
    public class DbConfig : ConfigurationSection // 所有配置节点都要选择这个基类
    {
        private static readonly ConfigurationProperty SProperty
            = new ConfigurationProperty(string.Empty, typeof(DbCollection), null,
                ConfigurationPropertyOptions.IsDefaultCollection);

        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public DbCollection DbCollection => (DbCollection) base[SProperty];
    }

    [ConfigurationCollection(typeof(DbInfo))]
    public class DbCollection : ConfigurationElementCollection // 自定义一个集合
    {
        // 基本上，所有的方法都只要简单地调用基类的实现就可以了。
        public DbCollection()
            : base(StringComparer.OrdinalIgnoreCase) // 忽略大小写
        {
        }

        // 其实关键就是这个索引器。但它也是调用基类的实现，只是做下类型转就行了。
        public new DbInfo this[string name] => (DbInfo) BaseGet(name);

        // 下面二个方法中抽象类中必须要实现的。
        protected override ConfigurationElement CreateNewElement()
        {
            return new DbInfo();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DbInfo) element).Name.ToString();
        }

        // 说明：如果不需要在代码中修改集合，可以不实现Add, Clear, Remove
        public void Add(DbInfo setting)
        {
            BaseAdd(setting);
        }

        public void Clear()
        {
            BaseClear();
        }

        public void Remove(DbInfoName name)
        {
            BaseRemove(name.ToString());
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// 元素类
    /// 属性名称要区分大小写
    /// </summary>
    public class DbInfo : ConfigurationElement // 集合中的每个元素
    {
        /// <summary>
        ///     配置节名
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true)]
        public DbInfoName Name
        {
            get => Enum.TryParse(this["name"].ToString(), out DbInfoName name) ? name : DbInfoName.MainDb;
            set => this["name"] = value.ToString();
        }

        /// <summary>
        ///     数据库类型
        /// </summary>
        [ConfigurationProperty("DbType", IsRequired = true)]
        public DbType DbType
        {
            get => Enum.TryParse(this["DbType"].ToString(), out DbType type) ? type : DbType.SqlServer;
            set => this["DbType"] = value.ToString();
        }

        /// <summary>
        ///     数据库实例或IP地址
        /// </summary>
        [ConfigurationProperty("DataSource", IsRequired = true)]
        public string DataSource
        {
            get => this["DataSource"].ToString();
            set => this["DataSource"] = value;
        }

        /// <summary>
        ///     端口号（非必需）
        /// </summary>
        [ConfigurationProperty("Port", IsRequired = false)]
        public int Port
        {
            get => (int) this["Port"];
            set => this["Port"] = value;
        }

        /// <summary>
        ///     数据库名
        /// </summary>
        [ConfigurationProperty("DbName", IsRequired = false)]
        public string DbName
        {
            get => this["DbName"].ToString();
            set => this["DbName"] = value;
        }

        /// <summary>
        ///     用户名
        /// </summary>
        [ConfigurationProperty("UserID", IsRequired = true)]
        public string UserId
        {
            get => this["UserID"].ToString();
            set => this["UserID"] = value;
        }

        /// <summary>
        ///     密码，经加密解密
        /// </summary>
        [ConfigurationProperty("Password", IsRequired = true)]
        public string Password
        {
            get => this["Password"].ToString().DesDecrypt("DnaMes", "DATABASE");
            set => this["Password"] = value.DesEncrypt("DnaMes", "DATABASE");
        }

        /// <summary>
        ///     连接超时（非必需）
        /// </summary>
        [ConfigurationProperty("Timeout", IsRequired = false)]
        public int Timeout
        {
            get => (int) this["Timeout"];
            set => this["Timeout"] = value;
        }

        /// <summary>
        /// 获取数据库连接字符串
        /// Info:除MSSQL和MySQL外尚需完善
        /// </summary>
        /// <returns>ConnectionString</returns>
        public override string ToString()
        {
            DbConnectionStringBuilder dsBuilder;
            switch (DbType)
            {
                case DbType.MySql:
                    dsBuilder = new MySqlConnectionStringBuilder
                    {
                        Database = DbName, // initialCatalog
                        Server = DataSource, //DataSource
                        UserID = UserId,
                        Password = Password,
                        Pooling = true,
                        CharacterSet = "utf8", // 支持中文
                        Port = (uint) Port,
                        ConnectionTimeout = (uint) Timeout,
                    };
                    break;
                case DbType.SqlServer:
                    dsBuilder = new SqlConnectionStringBuilder
                    {
                        DataSource = DataSource, //连接的数据库的实例或者网络地址
                        InitialCatalog = DbName, //连接的数据库的名称
                        IntegratedSecurity = false, //是否可以windows登录验证
                        UserID = UserId,
                        Password = Password,
                        Pooling = true, //是否使用连接池
                        ConnectTimeout = Timeout,
                    };
                    break;
                case DbType.Sqlite:
                    dsBuilder = new SQLiteConnectionStringBuilder
                    {
                        DataSource = DataSource,
                        BusyTimeout = Timeout,
                        Password = Password,
                        Pooling = true,
                    };
                    break;
                case DbType.Oracle:
                    dsBuilder = new Oracle.ManagedDataAccess.Client.OracleConnectionStringBuilder
                    {
                        DataSource = DataSource,
                        UserID = UserId,
                        Password = Password,
                        Pooling = true,
                        ConnectionTimeout = Timeout,
                    };
                    break;
                case DbType.PostgreSQL:
                    dsBuilder = new PgSqlConnectionStringBuilder
                    {
                        Database = DataSource,
                        UserId = UserId,
                        Password = Password,
                        Port = Port,
                        Pooling = true,
                        ConnectionTimeout = Timeout,
                    };
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return dsBuilder.ConnectionString;
        }
    }
}