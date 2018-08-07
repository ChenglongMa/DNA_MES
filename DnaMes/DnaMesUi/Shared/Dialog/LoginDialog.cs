using System.Windows.Forms;
using DnaLib.Control;
using DnaMesModel.Model.BasicInfo;
using DnaMesUiBll.Sys;

namespace DnaMesUi.Shared.Dialog
{
    public partial class LoginDialog : Form
    {
        public LoginDialog()
        {
            InitializeComponent();
            btnScan.Enabled = false; //TODO:用于扫码登录，待完善后开启
            _user = new User();
#if DEBUG
            txtId.Text = "100001";
            txtPwd.Text = "admin";

#endif
        }

        private readonly User _user;

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            _user.EmpId = txtId.Text.Trim();
            _user.Password = txtPwd.Text;
            if (LoginBll.CanLogin(_user))
            {

                DialogResult = DialogResult.OK;
            }
            else
            {
                MsgBoxLib.ShowError("用户名/密码错误，请重试");
            }
        }
    }
}