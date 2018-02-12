// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/12 17:12
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using SqlSugar;

namespace DnaLib.Config
{
    /// <summary>
    /// 扩展SugarColumn特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DnaColumn: SugarColumn
    {
        #region 私有字段


        #endregion

        #region 公有属性
        public bool IsUnique { get; set; }
        

        #endregion

        #region 私有方法


        #endregion

        #region 公有方法


        #endregion
    }
}

