// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/24 15:41
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using DnaLib.Helper;
using Infragistics.Win.UltraWinGrid;

namespace DnaMesUiConfig.Model
{
    /// <inheritdoc />
    /// <summary>
    /// Grid控件模型
    /// </summary>
    [XmlType("Grid")]
    public class GridConfig : ControlItem
    {
        [XmlArrayItem(typeof(Column))] public List<Column> Columns { get; set; }=new List<Column>();
    }

    /// <inheritdoc />
    /// <summary>
    /// 列属性
    /// </summary>
    [XmlType]
    public class Column : ControlItem
    {
        /// <summary>
        /// 可见性
        /// </summary>
        [XmlAttribute]
        public bool Visible { get; set; } = true;

        /// <summary>
        /// 是否只读
        /// </summary>
        [XmlAttribute]
        public bool IsReadOnly { get; set; } = true;

        /// <summary>
        /// 宽度，默认120
        /// </summary>
        [XmlAttribute]
        public int Width { get; set; } = 120;

        /// <summary>
        /// 列格式
        /// </summary>
        [XmlAttribute]
        public ColumnStyle ColumnStyle { get; set; } = ColumnStyle.Default;

        /// <summary>
        /// 数据类型
        /// </summary>
        [XmlAttribute]
        public string DataType { get; set; } = typeof(string).FullName;

        /// <summary>
        /// 显示格式
        /// 只在<see cref="DataType"/>为<see cref="DateTime"/>,<see cref="int"/>相关时有效
        /// </summary>
        [XmlAttribute]
        public string Format { get; set; }

        /// <summary>
        /// 根据格式 <see cref="Format"/> 转换为相应字符串
        /// </summary>
        /// <param name="o">待转换对象</param>
        /// <returns>转换后的字符串</returns>
        public string Convert(dynamic o)
        {
            if (o == null)
                return "";
            if (Format.IsNullOrEmpty())
            {
                return o.ToString();
            }
            string result = o.ToString();
            if (result.IsNum())
            {
                if (Format.ToLower() == "p") // 如果是百分数
                {
                    return System.Convert.ToDouble(result).ToString("P");
                }
                result = System.Convert.ToDouble(result).ToString(Format);
            }
            else if (result.IsDate())
            {
                var dt = System.Convert.ToDateTime(result);
                if (dt < new DateTime(1949)) //默认时间返回空字符串
                    return "";
                result = dt.ToString(Format);
            }

            return result;
        }
    }
}