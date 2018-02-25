using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infragistics.Win.UltraWinExplorerBar;
using Menu = DnaMesUiConfig.Model.Menu;

namespace DnaMesUi.Shared.Sys
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        public HomeForm(int p1, int p2) : this()
        {
            MessageBox.Show("这是带参数的构造函数");
        }
    }
}