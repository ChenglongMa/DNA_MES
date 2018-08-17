using System;
using DnaMesDal;
using DnaMesModel.Link.BasicInfo;
using DnaMesModel.Model.BasicInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DnaMesUnitTest
{
    [TestClass]
    public class UserTest : BaseTest<User>
    {
        private readonly User _admin = new User
        {
            EmpId = "100001",
            Name = "admin",
            Password = "admin",
        };
        [TestInitialize]
        public new void Init()
        {

        }

        [TestMethod]
        public override void CreateTable()
        {
            base.CreateTable();
        }

        [TestMethod]
        public override void CreateLinkTable()
        {
            Dal.CreateTable<UserDomain>();
        }

        [TestMethod]
        public override void Insert()
        {
            Dal.Insert(_admin);
            Assert.IsTrue(_admin.ObjId>0);
        }

        [TestMethod]
        public void SetLink()
        {
            var dal = new BaseDal<Domain>();
            var domains = dal.Get();
            foreach (var domain in domains)
            {
                Dal.SetLinkWith(_admin, domain);
            }
        }
    }
}