// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/24 15:41
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [XmlArrayItem(typeof(Column))] public List<Column> Columns { get; set; } = new List<Column>();
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
        public bool IsReadOnly { get; set; }

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
        /// 根据格式 <see cref="Format"/> 转换为相应格式数据
        /// </summary>
        /// <param name="value">待转换对象</param>
        /// <returns>转换后的值</returns>
        public dynamic ToUiValue(object value)
        {
            if (value == null)
                return "";
            var resStr = value.ToString();
            if (resStr.IsNum())
            {
                return Convert.ToDouble(Format?.ToLower() == "p"
                    ? Convert.ToDouble(resStr).ToString("P")
                    : Convert.ToDouble(resStr).ToString(Format));
            }

            if (DataType == typeof(string).FullName && Format == BoolFormat.BoolCHN.ToString() &&
                bool.TryParse(value.ToString(), out var resBool))
            {
                return resBool ? "是" : "否"; //将True或False转换为“是”“否”，使之支持中文布尔值
            }

            if (!resStr.IsDate()) return resStr;
            var dt = Convert.ToDateTime(resStr);
            return dt.IsLegalDate() ? dt.ToString(Format) : null;
        }

        /// <summary>
        /// 将UI显示内容转化为Model数据
        /// </summary>
        /// <param name="value">从UI获取的值</param>
        /// <returns>转换后的值</returns>
        public dynamic ToModelValue(object value)
        {
            if (value == null)
            {
                return null;
            }

            var res = value.ToString().Trim().ToLower();
            var type = Type.GetType(DataType ?? throw new InvalidOperationException($"{nameof(DataType)}未赋值"));
            if (type == typeof(string) && Format == BoolFormat.BoolCHN.ToString())
            {
                if (res.IsIn("是", "true"))
                {
                    return true;
                }

                if (res.IsIn("否", "false"))
                {
                    return false;
                }
            }

            if (type == value.GetType())
                return value;

            return type == null ? value : TypeDescriptor.GetConverter(type).ConvertFrom(value);
        }

        /// <summary>
        /// 布尔值格式
        /// 英文，中文
        /// </summary>
        public enum BoolFormat
        {
            /// <summary>
            /// 英文
            /// </summary>
            BoolENG,

            /// <summary>
            /// 中文
            /// </summary>
            BoolCHN,
        }
    }
}