// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/12 0:05
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using SqlSugar;

namespace DnaMesModel.BasicInfo
{
    /// <summary>
    /// 权限类
    /// </summary>
    [SugarTable("BasicInfo_Domain")]
    public class Domain:BaseModel
    {
        #region 私有字段


        #endregion

        #region 公有属性
        public int FunctionCode { get; set; }
        public string Name { get; set; }
        
        

        #endregion

        #region 私有方法


        #endregion

        #region 公有方法


        #endregion
    }
}

