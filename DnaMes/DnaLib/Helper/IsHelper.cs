// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/12 15:53
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DnaLib.Helper
{
    /// <summary>
    /// Is?判断是否为某类值 帮助类
    /// </summary>
    public static class IsHelper
    {
        #region 私有字段

        #endregion

        #region 公有属性

        #endregion

        #region 私有方法

        #endregion

        #region 公有方法

        /// <summary>
        /// 值在的范围？
        /// </summary>
        /// <param name="thisValue"></param>
        /// <param name="begin">大于等于begin</param>
        /// <param name="end">小于等于end</param>
        /// <returns></returns>
        public static bool IsInRange<T>(this T thisValue, T begin, T end) where T : IComparable
        {
            return thisValue.CompareTo(begin) >= 0 && thisValue.CompareTo(end) <= 0;
        }

        ///// <summary>
        ///// 值在的范围？
        ///// </summary>
        ///// <param name="thisValue"></param>
        ///// <param name="begin">大于等于begin</param>
        ///// <param name="end">小于等于end</param>
        ///// <returns></returns>
        //public static bool IsInRange(this DateTime thisValue, DateTime begin, DateTime end)
        //{
        //    return thisValue >= begin && thisValue <= end;
        //}

        /// <summary>
        /// 在里面吗?
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="thisValue"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool IsIn<T>(this T thisValue, params T[] values)
        {
            return values.Contains(thisValue);
        }

        /// <summary>
        /// 在里面吗?
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="thisValue"></param>
        /// <param name="inValues"></param>
        /// <returns></returns>
        public static bool IsContainsIn<T>(this IEnumerable<T> thisValue, params T[] inValues)
        {
            return inValues.Any(thisValue.Contains);
        }


        /// <summary>
        ///     判断值是否为null或string.Empty或空白或不含有任何元素
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this IEnumerable data)
        {
            return data == null || !data.GetEnumerator().MoveNext();
        }

        /// <summary>
        /// 是null或""?
        /// </summary>
        /// <returns></returns>
        [Obsolete("不确定该方法是否可用",true)]
        public static bool IsNullOrEmpty(this object thisValue)
        {
            if (thisValue == null || thisValue == DBNull.Value) return true;
            return thisValue.ToString() == "";
        }

        /// <summary>
        /// 是null或""?
        /// </summary>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this Guid? thisValue)
        {
            if (thisValue == null) return true;
            return thisValue == Guid.Empty;
        }

        /// <summary>
        /// 是null或""?
        /// </summary>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this Guid thisValue)
        {
            return thisValue == Guid.Empty;
        }

        ///// <summary>
        ///// 有值?(与IsNullOrEmpty相反)
        ///// </summary>
        ///// <returns></returns>
        //public static bool IsValuable(this object thisValue)
        //{
        //    if (thisValue == null) return false;
        //    return thisValue.ToString() != "";
        //}

        ///// <summary>
        ///// 有值?(与IsNullOrEmpty相反)
        ///// </summary>
        ///// <returns></returns>
        //public static bool IsValuable(this IEnumerable<object> thisValue)
        //{
        //    if (thisValue == null || !thisValue.Any()) return false;
        //    return true;
        //}

        ///// <summary>
        ///// 是零?
        ///// </summary>
        ///// <param name="thisValue"></param>
        ///// <returns></returns>
        //public static bool IsZero(this object thisValue)
        //{
        //    return thisValue == null || thisValue.ToString() == "0";
        //}

        /// <summary>
        /// 是INT?
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static bool IsInt(this object thisValue)
        {
            return thisValue != null && Regex.IsMatch(thisValue.ToString(), @"^\d+$");
        }

        /// <summary>
        /// 不是INT?
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static bool IsNoInt(this object thisValue)
        {
            if (thisValue == null) return true;
            return !Regex.IsMatch(thisValue.ToString(), @"^\d+$");
        }
        /// <summary>
        /// 是 正数、负数、和小数？
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static bool IsNum(this object thisValue)
        {
            return thisValue != null && Regex.IsMatch(thisValue.ToString(), @"^(\-|\+)?\d+(\.\d+)?$");
        }

        /// <summary>
        /// 是时间?
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static bool IsDate(this object thisValue)
        {
            return thisValue != null && DateTime.TryParse(thisValue.ToString(), out _);
        }

        /// <summary>
        /// 是邮箱?
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static bool IsEamil(this string thisValue)
        {
            return thisValue != null && Regex.IsMatch(thisValue, @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$");
        }

        /// <summary>
        /// 是手机?
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static bool IsMobile(this string thisValue)
        {
            return thisValue != null && Regex.IsMatch(thisValue, @"^\d{11}$");
        }

        /// <summary>
        /// 是座机?
        /// </summary>
        public static bool IsTelephone(this string thisValue)
        {
            if (thisValue == null) return false;
            return Regex.IsMatch(thisValue,
                @"^(\(\d{3,4}\)|\d{3,4}-|\s)?\d{8}$");
        }

        /// <summary>
        /// 是身份证?
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static bool IsIDcard(this string thisValue)
        {
            if (thisValue == null) return false;
            return Regex.IsMatch(thisValue,
                @"^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$");
        }

        /// <summary>
        /// 是传真?
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static bool IsFax(this string thisValue)
        {
            if (thisValue == null) return false;
            return Regex.IsMatch(thisValue,
                @"^[+]{0,1}(\d){1,3}[ ]?([-]?((\d)|[ ]){1,12})+$");
        }

        /// <summary>
        /// 是适合正则匹配?
        /// </summary>
        /// <param name="thisValue"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static bool IsMatch(this object thisValue, string pattern)
        {
            if (thisValue == null) return false;
            var reg = new Regex(pattern);
            return reg.IsMatch(thisValue.ToString());
        }

        /// <summary>
        /// 如果obj不是null，则执行action方法
        /// </summary>
        /// <typeparam name="T">obj类型</typeparam>
        /// <param name="obj">检测对象</param>
        /// <param name="action">执行方法</param>
        public static void IfNotNull<T>(this T obj, Action<T> action)
        {
            if (obj != null)
            {
                action(obj);
            }
        }

        /// <summary>
        /// 如果obj不是null，则执行action方法
        /// </summary>
        /// <typeparam name="T">obj类型</typeparam>
        /// <param name="obj">检测对象</param>
        /// <param name="action">执行方法</param>
        public static void IfNotNull<T>(this T obj, Action action)
        {
            if (obj != null)
            {
                action();
            }
        }
        /// <summary>
        /// 检查日期是否合法
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsLegalDate(this DateTime dt)
        {
            return DateTime.Compare(dt, new DateTime(1949, 1, 1)) > 0 &&
                   DateTime.Compare(dt, new DateTime(9999, 1, 1)) < 0;
        }
        #endregion
    }
}