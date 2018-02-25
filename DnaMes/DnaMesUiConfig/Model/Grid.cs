// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/24 15:41
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System.Collections.Generic;
using System.Xml.Serialization;
using Infragistics.Win.UltraWinGrid;

namespace DnaMesUiConfig.Model
{
    /// <inheritdoc />
    /// <summary>
    /// Grid控件模型
    /// </summary>
    [XmlType]
    public class Grid : ControlItem
    {
        [XmlArrayItem(typeof(Column))] public List<Column> Columns { get; set; }
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
        public ColumnStyle ColumnStyle { get; set; }

        /// <summary>
        /// 显示格式
        /// 只在<see cref="ColumnStyle"/>为Date相关时有效
        /// </summary>
        [XmlAttribute]
        public string Format { get; set; }
    }
}