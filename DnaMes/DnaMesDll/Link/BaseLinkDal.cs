// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/12 9:39
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DnaLib.Helper;
using DnaMesDal.Model;
using DnaMesModel;
using SqlSugar;

namespace DnaMesDal.Link
{
    /// <inheritdoc />
    /// <summary>
    /// 关系类数据基础操作
    /// </summary>
    public class BaseLinkDal<T> : BaseDal<T> where T : BaseLink, new()
    {
        #region 私有字段

        #endregion

        #region 公有属性

        #endregion

        #region 私有方法

        #endregion

        #region 公有方法

        public List<TB> GetLinkWith<TA, TB>(TA roleA, Expression<Func<TB, bool>> exp = null)
            where TA : BaseModel, new() where TB : BaseModel, new()
        {
            var links = DbClient.Queryable<T>().Where(l => l.RoleAId == roleA.ObjId).ToList();
            if (links.IsNullOrEmpty())
            {
                return null;
            }

            var expTemp = new Expressionable<TB>();
            foreach (var link in links)
            {
                expTemp.Or(b => b.ObjId == link.RoleBId);
            }

            return DbClient.Queryable<TB>().Where(expTemp.And(exp).ToExpression()).ToList();
        }

        #endregion
    }
}