// ****************************************************
//  Author: Charles Ma
//  Date: 2018/02/20 9:33
// ****************************************************
//  Copyright © DNA Studio 2018. All rights reserved.
// ****************************************************

using System.Collections.Generic;

namespace DnaMesUi.Config.Model
{
    /// <summary>
    /// 控件配置类
    /// </summary>
    public class Control
    {
        /// <summary>
        /// 控件集合
        /// </summary>
        public List<ControlItem> Items { get; set; }
    }
    /// <summary>
    /// 控件项基类
    /// 包含 菜单 按钮及其他控件默认格式
    /// </summary>
    public abstract class ControlItem
    {
        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 显示名
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 停靠处
        /// </summary>
        public string Dock { get; set; }
    }
    /// <inheritdoc />
    /// <summary>
    /// 菜单控件
    /// </summary>
    public class Menu:ControlItem
    {
        public List<PopMenu> PopMenus { get; set; }
    }
    /// <summary>
    /// 弹出菜单页
    /// </summary>
    public class PopMenu
    {
        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 显示名
        /// </summary>
        public string Text { get; set; }
        public string ShortCut { get; set; }
        public List<MenuItem> MenuItems { get; set; }
    }

    public class MenuItem
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string FormPath { get; set; }
        public string Type { get; set; }
        public int DomainId { get; set; }

    }
}

