﻿// ****************************************************
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
    public class DnaColumnAttribute : SugarColumn
    {
        #region 私有字段

        #endregion

        #region 公有属性

        /// <summary>
        /// 是否为关键属性
        /// 用于识别唯一数据（非主键）
        /// </summary>
        public bool IsKey { get; set; } = false;

        #endregion

        #region 私有方法

        #endregion

        #region 公有方法

        #endregion
    }
}