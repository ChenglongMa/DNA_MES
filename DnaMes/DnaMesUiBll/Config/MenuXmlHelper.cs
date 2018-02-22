// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/21 16:04
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using System.Configuration;
using System.IO;
using DnaLib.Helper;
using DnaMesModel.Shared;
using DnaMesUiBll.Config.Model;

namespace DnaMesUiBll.Config
{
    /// <summary>
    /// 构建菜单栏类
    /// </summary>
    public static class MenuXmlHelper
    {
        #region 私有字段

        private static readonly string Path = SysInfo.BinPath;
        private static readonly string FileName = ConfigurationManager.AppSettings["MainFormMenu"];

        #endregion

        #region 公有属性



        #endregion

        #region 私有方法


        #endregion

        #region 公有方法

        /// <summary>
        /// 通过XML文件构建菜单模型
        /// </summary>
        /// <returns></returns>
        public static Menu GetMenu()
        {
            var path = System.IO.Path.Combine(Path, FileName);
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            return XmlHelper.XmlDeserializeFromFile<Menu>(path);
        }

        #endregion
    }
}

