using System;
using System.Linq;
using DnaMesDal;
using DnaMesModel.Link.BasicInfo;
using DnaMesModel.Model.BasicInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DnaMesUnitTest
{
    [TestClass]
    public class ProcessTest : BaseTest<Process>
    {
        [TestMethod]
        public void TestMethod1()
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
            Dal.CreateTable<ProjectProcess>();
        }

        [TestMethod]
        public override void Insert()
        {
            var dal = new BaseDal<Project>();
            var proj = dal.Get(p => p.Code == "P00010").FirstOrDefault();

            var proc = new Process
            {
                Code = "1001",
                Name = "工艺1",
                IsValid = true
            };
            Dal.Insert(proc);
            Dal.SetLinkWith(proj, proc);
        }
    }
}