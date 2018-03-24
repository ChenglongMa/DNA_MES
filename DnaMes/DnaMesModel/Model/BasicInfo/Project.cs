// ****************************************************
//  Author: Charles Ma
//  Date: 2018/03/02 13:41
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using DnaLib.Config;
using SqlSugar;

namespace DnaMesModel.Model.BasicInfo
{
    /// <summary>
    /// 项目管理
    /// </summary>
    [SugarTable("BasicInfo_Project")]
    public class Project : BaseModel
    {
        #region 私有字段

        #endregion

        #region 公有属性

        /// <summary>
        /// 项目编号
        /// </summary>
        [DnaColumn(IsKey = true, IsNullable = false, Length = 25)]
        public string Code { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        [DnaColumn(IsNullable = false, Length = 45)]
        public string Name { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        [DnaColumn]
        public DateTime StartingTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        [DnaColumn]
        public DateTime EndingTime { get; set; }

        #endregion

        #region 私有方法

        #endregion

        #region 公有方法

        #endregion
    }
}