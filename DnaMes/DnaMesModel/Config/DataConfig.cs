using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnaLib;

namespace DnaMesModel.Config
{
    public class DataConfig : ConfigurationSection // 所有配置节点都要选择这个基类
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
        public new DbInfo this[string name] => (DbInfo) base.BaseGet(name);

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
            this.BaseAdd(setting);
        }

        public void Clear()
        {
            base.BaseClear();
        }

        public void Remove(string name)
        {
            base.BaseRemove(name);
        }
    }

    public class DbInfo : ConfigurationElement // 集合中的每个元素
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get => this["name"].ToString();
            set => this["name"] = value;
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
        /// 密码，经加密解密
        /// </summary>
        [ConfigurationProperty("Password", IsRequired = true)]
        public string Password
        {
            get => Encrypt.DesDecrypt(this["Password"].ToString(), "DnaMes", "DATABASE");
            set => this["Password"] = Encrypt.DesEncrypt(value, "DnaMes", "DATABASE");
        }

    }
}
