using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DnaLib.Control;
using DnaLib.Helper;
using DnaMesModel.Shared;
using DnaMesUiConfig.Helper;
using DnaMesUiConfig.Model;
using Infragistics.Win;
using Infragistics.Win.IGControls;
using Infragistics.Win.UltraWinExplorerBar;
using Infragistics.Win.UltraWinTabbedMdi;
using Infragistics.Win.UltraWinToolbars;
using CommandType = DnaMesUiConfig.Model.CommandType;
using Menu = DnaMesUiConfig.Model.Menu;
using MenuItem = DnaMesUiConfig.Model.MenuItem;

namespace DnaMesUi.Shared.Sys
{
    public partial class MainForm : Form
    {
        private int _childFormNumber;

        public MainForm()
        {
            InitializeComponent();
            BuildMenuBar();
        }


        #region 自动生成代码

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "窗口 " + _childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        #endregion

        #region 添加子窗体

        private readonly List<Form> _childForms = new List<Form>();

        /// <summary>
        /// 实例化一个新窗口到系统中
        /// </summary>
        /// <param name="formType">窗体类型</param>
        /// <param name="paras">构造函数的参数</param>
        private void AddMidForm(Type formType, params object[] paras)
        {
            if (!(Activator.CreateInstance(formType, paras) is Form frm)) return;
            frm.MdiParent = this;
            frm.Show();
            tabbedMdiManager.TabFromForm(frm).Activate();
        }

        /// <summary>
        /// 激活或添加新窗体
        /// </summary>
        /// <param name="formType"></param>
        /// <param name="paras"></param>
        private void ActivateChildForm(Type formType, params object[] paras)
        {
            var form = _childForms.FirstOrDefault(f => f.GetType() == formType);
            if (form == null)
            {
                AddMidForm(formType, paras);
            }
            else
            {
                tabbedMdiManager.TabFromForm(form).Activate();
            }
        }

        #endregion

        #region 菜单构建

        /// <summary>
        /// 从menu.xml中读取的菜单项
        /// </summary>
        private readonly Menu _menu = UiConfigHelper.GetMenu();

        /// <summary>
        /// 构建菜单栏
        /// </summary>
        private void BuildMenuBar()
        {
            foreach (var toolbar in toolBarManager.Toolbars)
            {
                toolbar.DockedRow++;
            }

            //设置菜单栏
            var mainMenuBar = toolBarManager.Toolbars.AddToolbar(_menu.Name);
            mainMenuBar.IsMainMenuBar = true;
            mainMenuBar.Settings.ShowToolTips = DefaultableBoolean.True;
            mainMenuBar.Text = _menu.Text;

            if (_menu.IsLarge)
            {
                mainMenuBar.Settings.ToolDisplayStyle = ToolDisplayStyle.ImageAndText;
                mainMenuBar.Settings.UseLargeImages = DefaultableBoolean.True;
                toolBarManager.MenuSettings.ToolDisplayStyle = ToolDisplayStyle.ImageAndText;
                toolBarManager.MenuSettings.UseLargeImages = DefaultableBoolean.True;
            }
            else
            {
                mainMenuBar.Settings.ToolDisplayStyle = ToolDisplayStyle.DefaultForToolType;
                mainMenuBar.Settings.UseLargeImages = DefaultableBoolean.False;
                toolBarManager.MenuSettings.ToolDisplayStyle = ToolDisplayStyle.DefaultForToolType;
                toolBarManager.MenuSettings.UseLargeImages = DefaultableBoolean.False;
            }

            mainMenuBar.Tag = _menu;
            mainMenuBar.DockedRow = 0;
            var menus = mainMenuBar.Tools;
            var pops = _menu.PopMenus;
            foreach (var pop in pops)
            {
                //设置菜单
                var menuTool = new PopupMenuTool(pop.Name);
                if (!pop.ShortCut.IsNullOrEmpty())
                {
                    pop.Text += "(&" + pop.ShortCut + ")";
                }

                menuTool.SharedProps.Caption = pop.Text;
                menuTool.Tag = pop;
                foreach (var item in pop.MenuItems)
                {
                    //设置菜单项
                    ToolBase menuItem = new ButtonTool(item.Name);
                    if (toolBarManager.Tools.Exists(item.Name))
                    {
                        menuItem = toolBarManager.Tools[item.Name];
                    }
                    if (!item.ShortCut.IsNullOrEmpty())
                    {
                        item.Text += "(&" + item.ShortCut + ")";
                    }

                    menuItem.SharedProps.Caption = item.Text;
                    menuItem.SharedProps.Enabled = SysInfo.Domains.Contains(item.DomainId);
                    if (!menuItem.SharedProps.Enabled)
                    {
                        menuItem.SharedProps.ToolTipText = @"您没有该权限";
                    }

                    menuItem.Tag = item;
                    menuItem.SharedProps.Tag = item;
                    menuTool.Tools.Add(menuItem);
                }

                toolBarManager.Tools.Add(menuTool);
                menus.Add(menuTool);
            }
        }

        #endregion

        #region 事件

        private void MainForm_Load(object sender, EventArgs e)
        {
            ActivateChildForm(typeof(HomeForm)); //加载首页
        }

        #region 更改窗体标签右键英文显示

        /// <summary>
        /// 初始化MDI Manager右键菜单
        /// 用于将初始英文改成中文显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabbedMdiManager_InitializeContextMenu(object sender, MdiTabContextMenuEventArgs e)
        {
            if (e.ContextMenuType != MdiTabContextMenu.Default)
                return;
            e.ContextMenu.MenuItems.Clear();
            var menuItem = new IGMenuItem("关闭")
            {
                Tag = e.Tab
            };

            menuItem.Click += OnCustomMenuItemClose;

            e.ContextMenu.MenuItems.Add(menuItem);
        }

        /// <summary>
        /// 关闭标签事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnCustomMenuItemClose(object sender, EventArgs e)
        {
            if (sender is IGMenuItem mi)
            {
                if (mi.Tag is MdiTab tab)
                {
                    tab.Close();
                }
            }
        }

        #endregion

        private void toolBarManager_ToolClick(object sender, ToolClickEventArgs e)
        {
            var popMenu = e.Tool.OwningMenu;
            var toolBar = popMenu?.OwningToolbar;
            if (toolBar?.Key == _menu.Name)
            {
                if (!(e.Tool.SharedProps.Tag is MenuItem eventItem)) return;
                switch (eventItem.CommandType)
                {
                    default:
                    case CommandType.Activate:
                        var path = nameof(DnaMesUi) + "." + eventItem.FormPath;
                        var type = Assembly.Load(nameof(DnaMesUi)).GetType(path);
                        if (type != null)
                        {
                            if (typeof(Form).IsAssignableFrom(type))
                            {
                                switch (eventItem.FormType)
                                {
                                    case FormType.ChildForm:
                                        ActivateChildForm(type, eventItem.Params);
                                        break;
                                    //正常情况下不应出现该项，为保证交互流畅此处不抛出异常
                                    //而是做Dialog处理
                                    case FormType.Null:
                                    case FormType.Dialog:
                                        var form = Activator.CreateInstance(type, eventItem.Params) as Form;
                                        form?.ShowDialog(this);
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }
                            }
                        }

                        break;
                    case CommandType.Close:
                        Close();
                        break;
                    case CommandType.Logout:
                        break;
                }
            }
            else
            {
                switch (e.Tool.Key.ToLower())
                {
                    case "exit":
                        Close();
                        break;

                    case "logout":
                        break;
                }
            }
        }

        private void tabbedMdiManager_TabClosing(object sender, CancelableMdiTabEventArgs e)
        {
            var form = e.Tab.Form;
            _childForms.Remove(form);
        }

        private void tabbedMdiManager_TabDisplayed(object sender, MdiTabEventArgs e)
        {
            _childForms.Add(e.Tab.Form); //将子窗体添加到缓存中
        }

        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !MsgBoxLib.ShowQuestion("确定要退出系统吗?");
        }
    }
}