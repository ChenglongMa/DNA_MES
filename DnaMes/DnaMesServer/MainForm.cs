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
            dataProcessLabel.Text = @"就绪";
            statusLabel.Text = @"就绪";
        }
        private string _strExit;
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_strExit != "exit")
            {
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
                //ShowInTaskbar = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Visible = true;
            WindowState = FormWindowState.Normal;
            //ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        private void openTSMI_Click(object sender, EventArgs e)
        {
            Visible = true;
            WindowState = FormWindowState.Normal;
            //ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        private void exitTSMI_Click(object sender, EventArgs e)
        {
            _strExit = "exit";
            Close();
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            _strExit = "exit";
            Close();
        }

        private void miInitial_Click(object sender, EventArgs e)
        {
            ServorInitilizeForm frm = new ServorInitilizeForm();
            frm.ShowDialog();
        }
    }
}
