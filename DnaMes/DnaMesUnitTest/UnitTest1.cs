using System;
using DnaLib;
using DnaMesModel.BasicInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlSugar;

namespace DnaMesUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //BuildUserTable();
        }
        [TestMethod]
        public void BuildUserTable()
        {
            var dbInfo = DbConfigLib.GetDbInfo();
            using (var db = new SqlSugarClient(new ConnectionConfig
            {
                ConnectionString = dbInfo.ToString(),
                DbType = dbInfo.DbType,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute,
            }))
            {
                var isAvailable = db.DbMaintenance.IsAnyTable("BasicInfo_User");
                if (isAvailable) return;
                Console.WriteLine("可以建表，要继续吗？（y/n）");
                if (Console.ReadLine()?.ToLower() == "y")
                {
                    db.CodeFirst.InitTables(typeof(User));
                }
            }
        }
    }
}
