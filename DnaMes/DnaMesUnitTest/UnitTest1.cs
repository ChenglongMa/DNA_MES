using System;
using Castle.Core.Internal;
using DnaLib;
using DnaMesDal;
using DnaMesDal.Model;
using DnaMesModel.BasicInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SqlSugar;

namespace DnaMesUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        public void TestMethod1()
        {
            var user = new User
            {
                ObjId = 13,
                EmpId = "100002",
                Name = "周杰伦",
                Password = "jaychou",
            };

            var dal = new BaseDal<User>();
            //Assert.IsTrue(dal.Insert(user));
            Assert.IsTrue(dal.Update(user));
            //Assert.IsTrue(dal.Delete(user));

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