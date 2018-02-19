using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnaMesServer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void miDBSet_Click(object sender, EventArgs e)
        {
            var form = new DbConfigForm();
            form.ShowDialog(this);

        }

        private void miAbout_Click(object sender, EventArgs e)
        {
            var form=new AboutBox();
            form.ShowDialog(this);

        }
    }
}
