using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DnaMesUiBll.Config;
using DnaMesUiBll.Config.Model;
using Infragistics.Win.UltraWinExplorerBar;
using Menu = DnaMesUiBll.Config.Model.Menu;

namespace DnaMesUi.Shared.Sys
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
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
            var pops = _menu.PopMenus;
            foreach (var pop in pops)
            {
                var grp = new UltraExplorerBarGroup(pop.Name) {Text = pop.Text};
                MenuExplorerBar.Groups.Add(grp);

            }
        }
    }
}
