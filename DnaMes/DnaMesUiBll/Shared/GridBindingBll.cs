// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/26 10:35
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using DnaLib.Helper;
using DnaMesModel;
using DnaMesUiConfig.Helper;
using DnaMesUiConfig.Model;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace DnaMesUiBll.Shared
{
    /// <summary>
    /// Grid数据绑定操作类
    /// </summary>
    public static class GridBindingBll<T> where T : BaseModel
    {
        #region 私有字段

        #endregion

        #region 公有属性

        #endregion

        #region 私有方法

        private static List<Column> GetFields(string fileName = null)
        {
            return fileName.IsNullOrEmpty() ? null : UiConfigHelper.GetColumns(fileName);
        }

        #endregion

        #region 公有方法

        /// <summary>
        /// 为Grid绑定数据及设置表格样式
        /// </summary>
        /// <param name="ug">需要绑定的Grid</param>
        /// <param name="dataSource">数据源</param>
        /// <param name="fileName">文件路径 格式：{文件夹名}\{文件名}</param>
        /// <param name="isRowSelect">单击单元格时是否选中整行</param>
        public static void BindingStyleAndData(UltraGrid ug, List<T> dataSource, string fileName = null,
            bool isRowSelect = true)
        {
            ug.SetDefaultStyle(isRowSelect);
            var fields = GetFields(fileName);
            if (fields.IsNullOrEmpty())
            {
                ug.DataSource = new BindingList<T>(dataSource);
                return;
            }

            BindingData(ug, dataSource, fileName);
            ug.SetColumnStyle(fields);
        }
        /// <summary>
        /// 仅为Grid绑定数据
        /// </summary>
        /// <param name="ug">需要绑定的Grid</param>
        /// <param name="dataSource">数据源</param>
        /// <param name="fileName">文件路径 格式：{文件夹名}\{文件名}</param>
        public static void BindingData(UltraGrid ug, List<T> dataSource, string fileName = null)
        {
            var fields = GetFields(fileName);
            if (fields.IsNullOrEmpty())
            {
                ug.DataSource = new BindingList<T>(dataSource);
                return;
            }

            if (dataSource == null)
                dataSource = new List<T>();
            //检查列配置中是否包含"Check"列，并赋默认值
            if (fields.Exists(c => c.Name == "ValueDict!Check"))
            {
                foreach (var info in dataSource.Where(info => !info.ValueDict.ContainsKey("Check")))
                {
                    info.ValueDict.Add("Check", false);
                }
            }

            ug.DataSource = new DnaBindingSource<T>(dataSource, fields);
            //将第一行着色
            foreach (var row in ug.Rows)
            {
                row.Appearance.Reset(); 
            }
            if (!ug.Rows.IsNullOrEmpty())
            {
                ug.Rows[0].Appearance.BackColor = Color.CadetBlue;
                ug.Rows[0].Appearance.FontData.Bold = DefaultableBoolean.True;
            }
        }

        #endregion
    }
}