// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/12 9:39
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using DnaMesDal.Model;
using DnaMesModel;

namespace DnaMesDal.Link
{

    /// <summary>
    /// 关系类数据基础操作
    /// </summary>
    //internal class BaseLinkDal<TA, TB> : BaseDal<BaseLink<TA, TB> where TA: BaseModel,new() where TB: BaseModel,new() 
    internal class BaseLinkDal<TA> : BaseDal<TA> where TA : BaseLink<BaseModel, BaseModel>, new()
    {
        #region 私有字段


        #endregion

        #region 公有属性



        #endregion

        #region 私有方法


        #endregion

        #region 公有方法


        #endregion


    }
}

