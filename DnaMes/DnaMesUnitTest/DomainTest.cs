using System;
using System.Collections.Generic;
using DnaMesModel.Model.BasicInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DnaMesUnitTest
{
    [TestClass]
    public class DomainTest:BaseTest<Domain>
    {
        private readonly List<Domain> _domains = new List<Domain>();
        [TestInitialize]
        public new void Init()
        {
            _domains.Add(new Domain
            {
                FunctionCode = -1,
                Name = "基础权限",
                Description = "如登录、注销、退出等功能",
            });
            _domains.Add(new Domain
            {
                FunctionCode = 10001,
                Name = "项目管理",
            });
            _domains.Add(new Domain
            {
                FunctionCode = 10002,
                Name = "工艺管理",
            });
        }
        [TestMethod]
        public override void CreateTable()
        {
            base.CreateTable();
        }
        [TestMethod]
        public override void CreateLinkTable()
        {
            //throw new NotImplementedException();
        }
        [TestMethod]
        public override void Insert()
        {
            foreach (var domain in _domains)
            {
                Dal.InsertOrUpdate(domain);
            }
        }
    }
}
