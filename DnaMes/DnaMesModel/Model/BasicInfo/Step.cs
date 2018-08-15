// ****************************************************
//  Author: Charles Ma
//  Date: 2018/08/08 9:51
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using DnaLib.Config;
using SqlSugar;

namespace DnaMesModel.Model.BasicInfo
{
    /// <summary>
    /// 工序类
    /// </summary>
    [SugarTable("BasicInfo_Step")]
    public class Step : BaseModel
    {
        #region Private Property

        #endregion

        #region Public Property

        /// <summary>
        /// 工序编码
        /// </summary>
        [DnaColumn(IsKey = true, IsNullable = false, Length = 25)]
        public string Code { get; set; }

        /// <summary>
        /// 工序号
        /// </summary>
        [DnaColumn(IsNullable = false)]
        public double Index { get; set; }

        /// <summary>
        /// 工序名称
        /// </summary>
        [DnaColumn(IsNullable = false, Length = 45)]
        public string Name { get; set; }

        #endregion

        #region Private Method

        #endregion

        #region Public Method

        #endregion
    }
}