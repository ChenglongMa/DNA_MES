// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/20 9:33
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml.Serialization;
using Infragistics.Win.UltraWinToolbars;

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
        public List<Menu> Items { get; set; }

        //public List<ControlItem> Items { get; set; }
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
    }

    /// <inheritdoc />
    /// <summary>
    /// 菜单控件
    /// </summary>
    [XmlType]
    public class Menu : ControlItem
    {
        /// <summary>
        /// 停靠处
        /// </summary>
        [XmlAttribute]
        public string Dock { get; set; } = DockedPosition.Top.ToString();

        [XmlElement] public List<PopMenu> PopMenus { get; set; }
    }

    /// <inheritdoc />
    /// <summary>
    /// 弹出菜单页
    /// </summary>
    [XmlType]
    public class PopMenu : ControlItem
    {
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

        //public List<MenuItem> MenuItems { get; set; }
    }

    /// <inheritdoc />
    /// <summary>
    /// 菜单项
    /// </summary>
    [XmlType]
    public class MenuItem : ControlItem
    {
        /// <summary>
        /// 快捷键
        /// </summary>
        [XmlAttribute]
        public string ShortCut { get; set; }

        /// <summary>
        /// 命令类型
        /// </summary>
        [XmlAttribute]
        public CommandType CommandType { get; set; } = CommandType.Activate;

        /// <summary>
        /// 权限ID
        /// </summary>
        [XmlAttribute]
        public int DomainId { get; set; }

        /// <summary>
        /// Form路径
        /// 格式：采用相对路径，从Form所属文件夹开始
        /// [FolderName].[FormName]
        /// 例如："BasicInfo.UserMantForm"
        /// </summary>
        [XmlElement]
        public string FormPath { get; set; }

        /// <summary>
        /// 加载方式
        /// </summary>
        [XmlElement]
        public FormType FormType { get; set; } = FormType.ChildForm;
    }
}