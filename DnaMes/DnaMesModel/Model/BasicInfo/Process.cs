// ****************************************************
//  Author: Charles Ma
//  Date: 2018/04/08 22:19
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using DnaLib.Config;
using SqlSugar;

namespace DnaMesModel.Model.BasicInfo
{
    /// <summary>
    /// 工艺类
    /// </summary>
    [SugarTable("BasicInfo_Process")]
    public class Process : BaseModel
    {
        #region 私有字段

        #endregion

        #region 公有属性

        /// <summary>
        /// 工艺编号
        /// </summary>
        [DnaColumn(IsKey = true, IsNullable = false, Length = 25)]
        public string Code { get; set; }

        /// <summary>
        /// 工艺名称
        /// </summary>
        [DnaColumn(IsNullable = false)]
        public string Name { get; set; }

        /// <summary>
        /// 是否为有效工艺
        /// </summary>
        [DnaColumn]
        public bool IsValid { get; set; } = false;

        #endregion

        #region 私有方法

        #endregion

        #region 公有方法

        #endregion
    }
}