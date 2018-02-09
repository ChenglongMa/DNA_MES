// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/09 14:41
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using System.Configuration;
using DnaLib;
using DnaMesModel.Global;

namespace DnaMesModel.Config
{
    /// <inheritdoc />
    /// <summary>
    /// 数据库配置类
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
            return ((DbInfo) element).Name;
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

        public void Remove(string name)
        {
            BaseRemove(name);
        }
    }

    public class DbInfo : ConfigurationElement // 集合中的每个元素
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public DbInfoName Name
        {
            get => DbInfoName.this["name"];//bug:将字符串转换为枚举
            set => this["name"] = value.ToString();
        }

        [ConfigurationProperty("DBType", IsRequired = true)]
        public string DbType
        {
            get => this["DBType"].ToString();
            set => this["DBType"] = value;
        }

        [ConfigurationProperty("Server", IsRequired = true)]
        public string Server
        {
            get => this["Server"].ToString();
            set => this["Server"] = value;
        }

        [ConfigurationProperty("Port", IsRequired = false)]
        public int Port
        {
            get => (int) this["Port"];
            set => this["Port"] = value;
        }

        [ConfigurationProperty("DBName", IsRequired = false)]
        public string DbName
        {
            get => this["DBName"].ToString();
            set => this["DBName"] = value;
        }

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
    }
}