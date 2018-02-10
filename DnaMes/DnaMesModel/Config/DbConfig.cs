// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/09 14:41
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using DnaLib;
using DnaMesModel.Global;
using MySql.Data.MySqlClient;
using SqlSugar;

namespace DnaMesModel.Config
{
    /// <inheritdoc />
    /// <summary>
    ///     数据库配置类
    /// </summary>
    public class DbConfig : ConfigurationSection // 所有配置节点都要选择这个基类
    {
        private static readonly ConfigurationProperty SProperty
            = new ConfigurationProperty(string.Empty, typeof(DbCollection), null,
                ConfigurationPropertyOptions.IsDefaultCollection);

        [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public DbCollection DbCollection => (DbCollection) base[SProperty];
    }

    [ConfigurationCollection(typeof(DbConnection))]
    public class DbCollection : ConfigurationElementCollection // 自定义一个集合
    {
        // 基本上，所有的方法都只要简单地调用基类的实现就可以了。
        public DbCollection()
            : base(StringComparer.OrdinalIgnoreCase) // 忽略大小写
        {
        }

        // 其实关键就是这个索引器。但它也是调用基类的实现，只是做下类型转就行了。
        public new DbConnection this[string name] => (DbConnection) BaseGet(name);

        // 下面二个方法中抽象类中必须要实现的。
        protected override ConfigurationElement CreateNewElement()
        {
            return new DbConnection();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((DbConnection) element).Name;
        }

        // 说明：如果不需要在代码中修改集合，可以不实现Add, Clear, Remove
        public void Add(DbConnection setting)
        {
            BaseAdd(setting);
        }

        public void Clear()
        {
            BaseClear();
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }
    }

    public class DbConnection : ConfigurationElement // 集合中的每个元素
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
        [ConfigurationProperty("DBType", IsRequired = true)]
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
        public uint Port
        {
            get => (uint) this["Port"];
            set => this["Port"] = value;
        }

        /// <summary>
        ///     数据库名
        /// </summary>
        [ConfigurationProperty("DBName", IsRequired = false)]
        public string DbName
        {
            get => this["DBName"].ToString();
            set => this["DBName"] = value;
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
            get => Encrypt.DesDecrypt(this["Password"].ToString(), "DnaMes", "DATABASE");
            set => this["Password"] = Encrypt.DesEncrypt(value, "DnaMes", "DATABASE");
        }

        /// <summary>
        /// 获取数据库连接字符串
        /// Info:目前只支持MSSQL和MySQL
        /// </summary>
        /// <returns>ConnectionString</returns>
        public override string ToString()
        {
            DbConnectionStringBuilder dsBuilder = null;
            switch (DbType)
            {
                case DbType.MySql:
                    dsBuilder = new MySqlConnectionStringBuilder
                    {
                        Database = DbName, // 同 ss.initialCatalog
                        Server = DataSource, //同 ss.DataSource
                        UserID = UserId,
                        Password = Password,
                        Pooling = true,
                        CharacterSet = "utf8", // 支持中文
                        Port = Port
                    };
                    break;
                case DbType.SqlServer:
                    dsBuilder = new SqlConnectionStringBuilder
                    {
                        DataSource = DataSource, //连接的数据库的实例或者网络地址
                        InitialCatalog = DbName, //连接的数据库的名称
                        IntegratedSecurity = true, //是否可以windows登录验证
                        UserID = UserId,
                        Password = Password,
                        Pooling = true //是否使用连接池
                    };
                    break;
                case DbType.Sqlite:
                    break;
                case DbType.Oracle:
                    break;
                case DbType.PostgreSQL:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return dsBuilder?.ConnectionString ?? throw new InvalidOperationException();
        }
    }
}