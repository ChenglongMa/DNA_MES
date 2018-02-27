// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/26 10:39
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using System.Collections.Generic;
using DnaLib.Helper;
using DnaMesUiConfig.Model;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace DnaMesUiConfig.Helper
{
    /// <summary>
    /// Grid控件帮助类
    /// </summary>
    public static class GridHelper
    {
        #region 私有字段

        #endregion

        #region 公有属性

        #endregion

        #region 私有方法

        #endregion

        #region 公有方法

        #endregion
        /// <summary>
        /// 设置Grid默认样式
        /// </summary>
        /// <param name="ug"></param>
        /// <param name="isRowSelect"></param>
        public static void SetDefaultStyle(this UltraGrid ug, bool isRowSelect)
        {
            ug.DisplayLayout.Override.CellClickAction =
                isRowSelect ? CellClickAction.RowSelect : CellClickAction.EditAndSelectText;
            
        }
        /// <summary>
        /// 根据配置文件设置Grid样式
        /// </summary>
        /// <param name="ug"></param>
        /// <param name="fields"></param>
        public static void SetColumnStyle(this UltraGrid ug, List<Column> fields)
        {
            if (ug.DisplayLayout.Bands.Count == 0)
                return;

            ug.DisplayLayout.Bands[0].Summaries.Clear();
            foreach (var field in fields)
            {
                //获取列
                if (ug.DisplayLayout.Bands[0].Columns.IndexOf(field.Name) < 0)
                    return;
                var col = ug.DisplayLayout.Bands[0].Columns[field.Name];

                col.CellAppearance.TextHAlign = field.DataType.IsIn(typeof(int).FullName, typeof(decimal).FullName,
                    typeof(double).FullName, typeof(float).FullName)
                    ? HAlign.Right
                    : HAlign.Center;

                if (field.Width > 0)
                {
                    col.Width = field.Width;
                }

                #region 汇总格式

                ////汇总
                //if (field.SumType != "")
                //{
                //    SummarySettings summarySetting = ug.DisplayLayout.Bands[0].Summaries.Add(
                //               (SummaryType)Enum.Parse(typeof(SummaryType), field.SumType),
                //               col,
                //               SummaryPosition.UseSummaryPositionColumn);
                //    //summarySetting.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed | SummaryDisplayAreas.GroupByRowsFooter | SummaryDisplayAreas.InGroupByRows;
                //    summarySetting.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed;
                //    summarySetting.Appearance.BackColor = Color.LightYellow;
                //    summarySetting.DisplayFormat = "{0}";

                //    if (field.DataType == "Decimal" || field.DataType == "Int32" || field.DataType == "Int")
                //        summarySetting.Appearance.TextHAlign = HAlign.Right;
                //}

                #endregion

                #region 是否锚定

                //if (field.IsFixed)
                //{
                //    col.Header.FixedHeaderIndicator = FixedHeaderIndicator.Button;
                //    //col.Header.Fixed = true;
                //}
                //else
                //{
                //    col.Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
                //}

                #endregion

                col.Style = field.ColumnStyle;
                col.CellActivation = field.IsReadOnly ? Activation.NoEdit : Activation.AllowEdit;
                col.Hidden = !field.Visible;

            }
        }
    }
}