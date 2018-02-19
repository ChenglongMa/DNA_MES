using System;
using System.Linq;
using Castle.Core.Internal;
using DnaLib;
using DnaMesDal;
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
                ObjId = 133,
                EmpId = "100002",
                Name = "周杰伦",
                Password = "jaychou",
            };

            var dal = new BaseDal<User>();
            var dalDomain = new BaseDal<Domain>();
            var domain = dalDomain.Get(d => d.FunctionCode > 10002);
            foreach (var dom in domain)
            {
                Assert.ThrowsException<ArgumentException>(() => dal.SetLinkWith(user, dom));
            }

            var links = dal.GetLinkWith<Domain>(user);
            Assert.AreEqual(3, links.Count);

            //Assert.IsTrue(dal.Insert(user));
            //Assert.IsTrue(dal.Update(user));
            //Assert.IsTrue(dal.Delete(user));
        }

    }
}