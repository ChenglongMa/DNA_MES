// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/20 9:33
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System.Collections.Generic;
using System.Xml.Serialization;

namespace DnaMesUiBll.Config.Model
{
    /// <summary>
    /// 控件配置类
    /// </summary>
    [XmlType("Control")]
    public class Control
    {
        /// <summary>
        /// 控件集合
        /// </summary>
        [XmlElement]
        public List<ControlItem> Items { get; set; }
    }

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

        /// <summary>
        /// 停靠处
        /// </summary>
        [XmlAttribute]
        public string Dock { get; set; } //TODO:确定属性类型
    }

    /// <inheritdoc />
    /// <summary>
    /// 菜单控件
    /// </summary>
    [XmlType]
    public class Menu : ControlItem
    {
        [XmlElement] public List<PopMenu> PopMenus { get; set; }
    }

    /// <summary>
    /// 弹出菜单页
    /// </summary>
    [XmlType]
    public class PopMenu //TODO：以后可能会增加抽象类
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

        /// <summary>
        /// 快捷键
        /// </summary>
        [XmlAttribute]
        public string ShortCut { get; set; }

        /// <summary>
        /// 菜单项集合
        /// </summary>
        [XmlElement]
        public List<MenuItem> MenuItems { get; set; }
    }

    /// <summary>
    /// 菜单项抽象类
    /// </summary>
    [XmlType]
    public abstract class MenuItem
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

        /// <summary>
        /// 快捷键
        /// </summary>
        [XmlAttribute]
        public string ShortCut { get; set; }
    }

    /// <inheritdoc />
    /// <summary>
    /// 弹出窗体菜单项
    /// </summary>
    [XmlType]
    public class FormMenuItem : MenuItem
    {
        /// <summary>
        /// Form路径
        /// </summary>
        [XmlAttribute]
        public string FormPath { get; set; }

        /// <summary>
        /// 加载方式
        /// </summary>
        [XmlAttribute]
        public FormType Type { get; set; } = FormType.ChildForm;

        /// <summary>
        /// 权限ID
        /// </summary>
        [XmlAttribute]
        public int DomainId { get; set; }
    }

    /// <inheritdoc />
    /// <summary>
    /// 执行命令菜单项
    /// </summary>
    [XmlType]
    public class CommandMenuItem : MenuItem
    {
        //TODO:增加其他字段
        /// <summary>
        /// 命令类型
        /// </summary>
        [XmlAttribute]
        public CommandType Type { get; set; }
    }
}