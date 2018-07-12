using System.Windows.Forms;

namespace DnaMesUi.Shared.Dialog
{
    public partial class LoginDialog : Form
    {
        public LoginDialog()
        {
            InitializeComponent();
            btnScan.Enabled = false;
#if DEBUG
            txtName.Text = "admin";
            txtPwd.Text = "admin";

#endif
        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
        }
    }
}