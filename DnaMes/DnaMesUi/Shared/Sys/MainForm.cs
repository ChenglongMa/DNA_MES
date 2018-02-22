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
using DnaMesModel.Shared;
using DnaMesUiBll.Config;
using DnaMesUiBll.Config.Model;
using Infragistics.Win.IGControls;
using Infragistics.Win.UltraWinExplorerBar;
using Infragistics.Win.UltraWinTabbedMdi;
using Infragistics.Win.UltraWinToolbars;
using CommandType = DnaMesUiBll.Config.Model.CommandType;
using Menu = DnaMesUiBll.Config.Model.Menu;
using MenuItem = DnaMesUiBll.Config.Model.MenuItem;

namespace DnaMesUi.Shared.Sys
{
    public partial class MainForm : Form
    {
        private int childFormNumber = 0;

        public MainForm()
        {
            InitializeComponent();
            SysInfo.Domains.Add(10001);
            BuildMenuBar();
        }

        private readonly List<Form> _childForms = new List<Form>();

        #region 自动生成代码

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "窗口 " + childFormNumber++;
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

        /// <summary>
        /// 实例化一个新窗口到系统中
        /// </summary>
        /// <param name="formType">窗体类型</param>
        private void AddMidForm(Type formType)
        {
            if (!(Activator.CreateInstance(formType) is Form frm)) return;
            frm.MdiParent = this;
            frm.Show();
            tabbedMdiManager.TabFromForm(frm).Activate();
        }

        /// <summary>
        /// 激活或添加新窗体
        /// </summary>
        private void ActivateChildForm(Type formType)
        {
            var form = _childForms.FirstOrDefault(f => f.GetType() == formType);
            if (form == null)
            {
                AddMidForm(formType);
            }
            else
            {
                tabbedMdiManager.TabFromForm(form).Activate();
            }
        }

        /// <summary>
        /// 从menu.xml中读取的菜单项
        /// </summary>
        private readonly Menu _menu = MenuXmlHelper.GetMenu();

        /// <summary>
        /// 构建菜单栏
        /// </summary>
        private void BuildMenuBar()
        {
            //设置菜单栏
            var mainMenuBar = toolBarManager.Toolbars[_menu.Name];
            mainMenuBar.Text = _menu.Text;
            mainMenuBar.DockedPosition = (DockedPosition) Enum.Parse(typeof(DockedPosition), _menu.Dock);
            mainMenuBar.Tag = _menu;
            var menus = mainMenuBar.Tools;
            var pops = _menu.PopMenus;
            foreach (var pop in pops)
            {
                //设置菜单
                var menuTool = new PopupMenuTool(pop.Name);
                menuTool.SharedProps.Caption = pop.Text;
                menuTool.Tag = pop;
                foreach (var item in pop.MenuItems)
                {
                    //设置菜单项
                    var menuItem = new ButtonTool(item.Name);
                    menuItem.SharedProps.Caption = item.Text;
                    menuItem.SharedProps.Enabled = SysInfo.Domains.Contains(item.DomainId);
                    //if (!menuItem.SharedProps.Enabled)
                    //{
                    //    menuItem.SharedProps.ToolTipTextFormatted= @"您没有该权限";
                    //}

                    //menuItem.SharedProps.Shortcut
                    menuItem.Tag = item;
                    menuItem.SharedProps.Tag = item;
                    menuTool.Tools.Add(menuItem);
                }

                toolBarManager.Tools.Add(menuTool);
                menus.Add(menuTool);
            }
        }

        private void tabbedMdiManager_InitializeTab(object sender, MdiTabEventArgs e)
        {
            _childForms.Add(e.Tab.Form); //将子窗体添加到缓存中
        }

        private void tabbedMdiManager_TabClosed(object sender, MdiTabEventArgs e)
        {
            var form = e.Tab.Tag as Form;
            _childForms.Remove(form); //将窗体从缓存中移除
        }

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
                    tab.Tag = tab.Form;
                    tab.Close();
                }
            }
        }

        #endregion

        private void toolBarManager_ToolClick(object sender, ToolClickEventArgs e)
        {
            var popMenu = e.Tool.OwningMenu;
            var toolBar = popMenu?.OwningToolbar;
            if (toolBar?.Key==_menu.Name)
            {
                if (!(e.Tool.SharedProps.Tag is MenuItem eventItem)) return;
                switch (eventItem.CommandType)
                {
                    default:
                    case CommandType.Activate:
                        var path = nameof(DnaMesUi)+"."+eventItem.FormPath;
                        var type = Assembly.Load(nameof(DnaMesUi)).GetType(path);
                        if (type != null)
                        {
                            if (typeof(Form).IsAssignableFrom(type))
                            {
                                switch (eventItem.FormType)
                                {
                                    case FormType.ChildForm:
                                        ActivateChildForm(type);
                                        break;
                                    //正常情况下不应出现该项，为保证交互流畅此处不抛出异常
                                    //而是做Dialog处理
                                    case FormType.Null:
                                    case FormType.Dialog:
                                        var form=Activator.CreateInstance(type) as Form;
                                        form?.ShowDialog(this);
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }
                            }
                        }

                        break;
                    case CommandType.Close:
                        break;
                    case CommandType.ReLogin:
                        break;
                }
            }
        }
    }
}