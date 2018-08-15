using System;
using System.Linq;
using DnaMesDal;
using DnaMesModel.Link.BasicInfo;
using DnaMesModel.Model.BasicInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DnaMesUnitTest
{
    [TestClass]
    public class StepTest : BaseTest<Step>
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
            Dal.CreateTable<ProcessStep>();
        }

        [TestMethod]
        public override void Insert()
        {
            var dal = new BaseDal<Process>();
            var proc = dal.Get(p => p.Code == "1001").FirstOrDefault();

            var step = new Step
            {
                Code = "10011",
                Name = "工序1",
                Index = 1,
            };
            Dal.Insert(step);
            Dal.SetLinkWith(proc, step);
        }
    }
}