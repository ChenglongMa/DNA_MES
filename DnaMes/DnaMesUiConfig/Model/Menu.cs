// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/20 9:33
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System.Collections.Generic;
using System.Xml.Serialization;

namespace DnaMesUiConfig.Model
{
    /// <inheritdoc />
    /// <summary>
    /// 菜单控件
    /// </summary>
    [XmlType]
    public class Menu : ControlItem
    {
        /// <summary>
        /// 是否使用大图标
        /// 触摸屏适用
        /// </summary>
        [XmlAttribute]
        public bool IsLarge { get; set; } = false;

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

        /// <summary>
        /// Form构造函数的参数
        /// </summary>
        [XmlArrayItem(typeof(object))]
        public object[] Params { get; set; }
    }

    /// <summary>
    /// 窗体加载类型
    /// </summary>
    public enum FormType
    {
        /// <summary>
        /// 无Form加载
        /// </summary>
        Null = -1,

        /// <summary>
        /// 子窗体加载至MDI Form内
        /// </summary>
        ChildForm = 0,

        /// <summary>
        /// 对话框
        /// </summary>
        Dialog = 1,
    }

    /// <summary>
    /// 命令类型
    /// </summary>
    public enum CommandType
    {
        Activate,
        Close,

        //SaveAs,
        //About,
        Logout,
    }
}