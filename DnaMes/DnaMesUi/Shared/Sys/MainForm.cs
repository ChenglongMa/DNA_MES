using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DnaMesModel.Shared;
using Infragistics.Win.IGControls;
using Infragistics.Win.UltraWinTabbedMdi;

namespace DnaMesUi.Shared.Sys
{
    public partial class MainForm : Form
    {
        private int childFormNumber = 0;

        public MainForm()
        {
            InitializeComponent();
        }

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

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
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
        /// <typeparam name="T">窗体类型</typeparam>
        /// <returns></returns>
        private T AddMidForm<T>() where T : Form, new()
        {
            var frm = new T {MdiParent = this};
            frm.Show();
            tabbedMdiManager.TabFromForm(frm).Activate();
            return frm;
        }

        private void tabbedMdiManager_InitializeTab(object sender, MdiTabEventArgs e)
        {
            //AddMidForm<HomeForm>();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AddMidForm<HomeForm>();

        }
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
                if (mi.Tag is MdiTab tab) tab.Close();
            }
        }
    }
}