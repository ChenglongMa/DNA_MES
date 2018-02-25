using System;
using System.Linq;
using Castle.Core.Internal;
using DnaLib;
using DnaLib.Helper;
using DnaMesDal;
using DnaMesModel.Model.BasicInfo;
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
            var user = ReflectionHelper.CreateInstance<User>(nameof(DnaMesModel), "Model.BasicInfo.User");
            Assert.IsNotNull(user);
        }
    }
}