// ****************************************************
//  Author: Charles Ma
//  Date: 2018/08/09 22:37
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using DnaMesDal;
using DnaMesModel;
using DnaMesModel.Model.BasicInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DnaMesUnitTest
{
    /// <summary>
    /// BaseTest
    /// </summary>
    [TestClass]
    public abstract class BaseTest<T> where T:BaseModel,new()
    {
        #region Private Property


        #endregion

        #region Public Property
        protected readonly BaseDal<T> Dal = new BaseDal<T>();

        #endregion

        #region Private Method


        #endregion

        #region Public Method
        [TestInitialize]
        public void Init()
        {
          
        }

        [TestMethod]
        public virtual void CreateTable()
        {
            Dal.CreateTable<T>();
        }

        [TestMethod]
        public abstract void CreateLinkTable();

        [TestMethod]
        public abstract void Insert();


        #endregion
    }
}

