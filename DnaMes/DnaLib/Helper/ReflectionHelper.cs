// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/23 1:59
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using System.Reflection;
using System.Windows.Forms;

namespace DnaLib.Helper
{
    /// <summary>
    /// 反射帮助类
    /// </summary>
    public static class ReflectionHelper
    {
        #region 私有字段


        #endregion

        #region 公有属性

        

        #endregion

        #region 私有方法

        private static object CreateInstance(string nameSpace, string path, params object[] paras)
        {
            var type = Assembly.Load(nameSpace).GetType(nameSpace + "." + path);
            return Activator.CreateInstance(type, paras);
        }

        #endregion

        #region 公有方法

        /// <summary>
        /// 创建T类型实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nameSpace"></param>
        /// <param name="path"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static T CreateInstance<T>(string nameSpace,string path,params object[] paras) where T : class
        {
            var fullPath = nameSpace + "." + path;
            var type = Assembly.Load(nameSpace).GetType(fullPath);
            if (type != null)
            {
                if (typeof(T).IsAssignableFrom(type))
                {
                    return Activator.CreateInstance(type, paras) as T;
                }
            }

            return null;
        }

        /// <summary>
        /// 创建窗体
        /// </summary>
        /// <param name="nameSpace"></param>
        /// <param name="path"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static Form CreateForm(string nameSpace, string path, params object[] paras)
        {
            var fullPath = nameSpace + "." + path;
            var type = Assembly.Load(nameSpace).GetType(fullPath);
            if (type != null)
            {
                if (typeof(Form).IsAssignableFrom(type))
                {
                    return Activator.CreateInstance(type, paras) as Form;
                }
            }

            return null;
        }

        #endregion
    }
}

