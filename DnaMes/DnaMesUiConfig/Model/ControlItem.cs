// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/20 9:33
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System.Xml.Serialization;

namespace DnaMesUiConfig.Model
{
    /// <summary>
    /// 控件项基类
    /// 包含 菜单 按钮及其他控件默认格式
    /// </summary>
    [XmlType]
    public abstract class ControlItem
    {
        /// <summary>
        /// 名字
        /// </summary>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// 显示名
        /// </summary>
        [XmlAttribute]
        public string Text { get; set; }
    }
}