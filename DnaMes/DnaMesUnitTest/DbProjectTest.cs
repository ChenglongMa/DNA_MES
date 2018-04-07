using System;
using System.Collections.Generic;
using DnaMesDal;
using DnaMesModel.Link.BasicInfo;
using DnaMesModel.Model.BasicInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlSugar;

namespace DnaMesUnitTest
{
    [TestClass]
    public class DbProjectTest
    {
        private readonly BaseDal<Project> _dal = new BaseDal<Project>();
        private readonly List<Project> _dataList = new List<Project>();

        [TestInitialize]
        public void Init()
        {
            for (int i = 0; i < 10; i++)
            {
                var p = new Project
                {
                    Code = "P0001" + i,
                    Name = "项目 " + i,
                    StartingTime = DateTime.Today,
                    EndingTime = DateTime.Today.AddDays(30),
                };
                _dataList.Add(p);
            }
        }

        [TestMethod]
        public void CreateTable()
        {
            _dal.CreateTable<Project>();
        }

        [TestMethod]
        public void CreateLinkTable()
        {
            _dal.CreateTable<ProjectProject>();
        }

        [TestMethod]
        public void InsertData()
        {
            foreach (var p in _dataList)
            {
                _dal.InsertOrUpdate(p);
            }
        }

        [TestMethod]
        public void BuildLinks()
        {
            for (var i = 0; i < _dataList.Count - 1; i++)
            {
                var p1 = _dataList[i];
                var p2 = _dataList[i + 1];
                _dal.SetLinkWith(p1, p2);
            }
        }
        [TestMethod]
        public void DeleteProject()
        {
            var proj = new Project
            {
                Code = "P00017",
            };
            Assert.IsTrue(_dal.Delete(proj));
        }
        [TestMethod]
        public void DeleteLink()
        {
            var pA = new Project
            {
                Code = "P00013"
            };
            var pB = new Project
            {
                Code = "P00014"
            };
            Assert.IsTrue(_dal.DeleteLinkWith<Project,Project,ProjectProject>(pA, pB));
        }
    }
}