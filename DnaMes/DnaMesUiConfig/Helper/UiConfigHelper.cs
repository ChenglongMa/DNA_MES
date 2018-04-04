// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/21 16:04
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Xml;
using DnaLib.Helper;
using DnaMesModel.Shared;
using DnaMesUiConfig.Model;

namespace DnaMesUiConfig.Helper
{
    /// <summary>
    /// 配置读取类
    /// </summary>
    public static class UiConfigHelper
    {
        #region 私有字段

        private static readonly string Path = SysInfo.BinPath+"Config\\";
        private static readonly string MenuFileName = ConfigurationManager.AppSettings["MainFormMenu"];

        #endregion

        #region 公有属性

        #endregion

        #region 私有方法

        /// <summary>
        /// 根据配置文件获取控件类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static T GetConfig<T>(string fileName) where T: ControlItem
        {
            var path = System.IO.Path.Combine(Path, fileName);
            if (!File.Exists(path)) throw new FileNotFoundException($"找不到指定文件：路径：{path}");

            return XmlHelper.XmlDeserializeFromFile<T>(path);
        }
        #endregion

        #region 公有方法

        #region 菜单配置

        /// <summary>
        /// 通过XML文件构建菜单模型
        /// </summary>
        /// <returns></returns>
        public static Menu GetMenu()
        {
            return GetConfig<Menu>(MenuFileName);
        }

        #endregion

        #region UI Style配置

        /// <summary>
        /// 获取ISL文件路径
        /// </summary>
        /// <param name="fileName">isl文件名</param>
        /// <returns></returns>
        public static string GetIsl(string fileName = "IG.isl")
        {
            var path = System.IO.Path.Combine(Path, "StyleLibraries");
            path = System.IO.Path.Combine(path, fileName);

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"找不到指定文件：路径：{path}");
            }

            return path;
        }

        #endregion

        #region Grid配置

        /// <summary>
        /// 加载字段信息
        /// </summary>
        /// <param name="fileName">文件路径 格式：{文件夹名}\{文件名}</param>
        /// <returns></returns>
        public static List<Column> GetColumns(string fileName)
        {
            return GetConfig<GridConfig>(fileName)?.Columns;
        }

        #endregion
        #endregion
    }
}