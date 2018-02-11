// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/10 16:14
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using SqlSugar;

namespace DnaMesDal
{
    /// <summary>
    /// 数据库操作底层
    /// </summary>
    public class DbBaseDal<T>:SimpleClient<T> where T : class, new()
    {
        #region 私有字段



        #endregion

        #region 公有属性


        #endregion

        #region 私有方法


        #endregion

        #region 公有方法

        public DbBaseDal(SqlSugarClient context) : base(context)
        {
        }

        #endregion

    }
}

