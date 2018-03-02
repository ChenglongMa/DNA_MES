// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/12 0:05
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System.Collections.Generic;
using DnaLib.Config;
using SqlSugar;

namespace DnaMesModel.Model.BasicInfo
{
    /// <summary>
    /// 权限类
    /// </summary>
    [SugarTable("BasicInfo_Domain")]
    public class Domain : BaseModel
    {
        #region 私有字段

        #endregion

        #region 公有属性

        [DnaColumn(IsKey = true, IsNullable = false)]
        public int FunctionCode { get; set; }

        [DnaColumn(IsNullable = true, Length = 45)]
        public string Name { get; set; }
        #endregion

        #region 私有方法

        #endregion

        #region 公有方法

        #endregion
    }
}