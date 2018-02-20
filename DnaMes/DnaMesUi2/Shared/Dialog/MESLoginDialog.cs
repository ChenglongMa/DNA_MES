using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using DnaLib.Global;
using DnaLib.Helper;
using DnaMesUiBll.Shared;

namespace DnaMesUi.Shared.Dialog
{
    public partial class MESLoginDialog : Form
    {
        public MESLoginDialog()
        {
            InitializeComponent();
            InitLoginUi();
        }

        private void InitLoginUi()
        {
            try
            {
                Dictionary<string, string> loginDict = LoginBll.GetLoginInfo();
                if (loginDict != null && loginDict.ContainsKey("LoginName"))
                    txtBoxUserName.Text = loginDict["LoginName"];
#if DEBUG
                txtBoxUserName.Text = "sy";
                txtBoxPassword.Text = "";
#endif
                if (loginDict != null && loginDict.ContainsKey("LoginIP"))
                    txtMESServerIP.Text = loginDict["LoginIP"];
                SetDefaultStatus();

                if (loginDict != null && loginDict.ContainsKey("LoginWay"))
                {
                    if (loginDict["LoginWay"] == "staffnologin")
                    {
                        SetUserNameLogin(false);
                        checkBoxStaffnoLogin.Checked = true;
                        txtStaffno.Text = loginDict["staffno"];
                    }
                    else
                    {
                        SetUserNameLogin();
                        checkBoxStaffnoLogin.Checked = false;
                    }
                }
                else //默认用户名登入
                {
                    SetUserNameLogin();
                    checkBoxStaffnoLogin.Checked = false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog(ex, "Login");
                MessageBoxHelper.ShowWarning("登入系统失败！");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string strUserName;
                string strPassword;
                string staffno = null;
                string serverIp = txtMESServerIP.Text;
                if (serverIp.IsNullOrEmpty())
                    serverIp = LoginBll.GetIPFromLocalFile();
                SysInfo.ServerIp = IPAddress.Parse(serverIp);
                txtMESServerIP.Text = serverIp;
                try
                {
                    //todo:对比本机与服务器配置的异同
                    if (LoginBll.ExistDifferLocalAndServerFile())
                    {
                        MessageBoxHelper.ShowWarning("检测到服务器文件与本地文件存在差异，系统将更新本地文件...");
                        LoginBll.UpdateLocalFile();
                        MessageBoxHelper.ShowInformationOK("更新成功！");
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLog(ex, "Login");
                    MessageBoxHelper.ShowWarning("更新失败，系统自动从本地获取登入信息！");
                }


                if (checkBoxStaffnoLogin.Checked == false) //员工姓名登入
                {
                    SetUserNameLogin();
                    strUserName = txtBoxUserName.Text;
                    strPassword = txtBoxPassword.Text;
                    bool rtnrslt = LoginBll.CheckUser(strUserName, strPassword, txtMESServerIP.Text);
                    if (rtnrslt)
                        LoginBll.RegisterUser();
                    else
                    {
                        Cursor = Cursors.Default;
                        var strSecurity = $"用户{strUserName}登录授权失败！";
                        LogHelper.WriteWarningLog(strSecurity, "Login");
                        return;
                    }

                    //SysInfo.AllAuthIDDict = LoginBll.GetAllOperationAuthDict();
                    SysInfo.EmpId = LoginBll.GetPersonByName(strUserName).staffno;
                    SysInfo.SysUserAuthIDDict = LoginBll.GetOperationAuthDictByName(strUserName);
                }
                else
                {
                    SetUserNameLogin(false);
                    staffno = txtStaffno.Text; //获取工号
                    LoginBll.RegisterUser();
                    Person person = LoginBll.GetPersonByStaffno(staffno);

                    if (person == null)
                    {
                        Cursor = Cursors.Default;
                        MessageBoxHelper.ShowWarning("不存在此工号的人员！");
                        return;
                    }

                    bool rtnrslt2 = LoginBll.CheckUser(person.name, person.password, txtMESServerIP.Text);
                    if (rtnrslt2 == true)
                        LoginBll.RegisterUser();
                    else
                    {
                        Cursor = Cursors.Default;
                        Cursor = Cursors.Default;
                        string strSecurity = string.Format("用户{0}登录授权失败！", person.name);
                        LogHelper.WriteWarningLog(strSecurity, "Login");
                        return;
                    }

                    strUserName = person.name;
                    SysInfo.EmpId = staffno;
                }

                SysInfo.UserName = strUserName;
                SysInfo.WebService = "http://" + serverIp.Replace("http://", "").Replace("\r\n", "").Replace("/", "") +
                                     ":" + ConfigurationManager.AppSettings["WebPort"] + "/" +
                                     ConfigurationManager.AppSettings["WebServiceName"] + "/FileService.asmx"; //报表设计器
                SaveTextBoxInfo();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                LogHelper.WriteErrorLog(ex, "Login");
                MessageBoxHelper.ShowWarning(ex.Message);
            }
        }


        //取消登入
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// 更换IP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnchangeServerIP_Click(object sender, EventArgs e)
        {
            try
            {
                SetDefaultStatus();

                Height = 285;
                btnLogin.Location = new Point(btnLogin.Location.X, btnLogin.Location.Y + 40);
                btnExit.Location = new Point(btnExit.Location.X, btnExit.Location.Y + 40);


                pdcLabelIP.Visible = true;
                txtMESServerIP.Visible = true;
                btnSaveIP.Visible = true;

                txtMESServerIP.Text = LoginBll.GetIPFromLocalFile();
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog(ex, "Login");
                MessageBoxHelper.ShowWarning("登入系统失败！");
            }
        }

        private void pdcBtnSaveIP_Click(object sender, EventArgs e)
        {
            try
            {
                SetDefaultStatus();

                SaveTextBoxInfo();
                //调试环境下，需要手动修改bin目录下的exe.config。
                //打包后，app.config不进入包中，真正起作用的文件为exe.config文件。
                //MessageBoxHelper.ShowWarning("请您点击退出然后再重新启动系统！");
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog(ex, "Login");
                MessageBoxHelper.ShowWarning("登入系统失败！");
            }
        }

        private void SetDefaultStatus()
        {
            Height = 250;
            btnLogin.Location = new Point(55, 165);
            btnExit.Location = new Point(275, 165);

            pdcLabelIP.Visible = false;
            txtMESServerIP.Visible = false;
            btnSaveIP.Visible = false;
        }

        //切换为工号登入
        private void checkBoxStaffnoLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxStaffnoLogin.Checked)
            {
                SetUserNameLogin(false); //设置为工号登入，而不是用户名
            }
            else
            {
                SetDefaultStatus();
                SetUserNameLogin();
            }

            //DbInfo dbInfo = LoginBll.GetDbInfo("MESServer");
            //DbInfo dbInfo2 = new DbInfo
            //{
            //    Name = dbInfo.Name,
            //    Server = dbInfo.Server,
            //    UserId = dbInfo.UserId,
            //    DbType = checkBoxStaffnoLogin.Checked == true ? "staffnoLogin" : "usernameLogin"
            //};

            //LoginBll.SetDbInfo(dbInfo2);

            //IMessageBoxPDC.ShowWarning("请您点击退出然后再重新启动系统！");
        }

        /// <summary>
        /// 使用用户名登录
        /// </summary>
        /// <param name="userNameLogin"></param>
        private void SetUserNameLogin(bool userNameLogin = true)
        {
            lbName.Visible = userNameLogin;
            txtBoxUserName.Visible = userNameLogin;
            pdcLbPswd.Visible = userNameLogin;
            txtBoxPassword.Visible = userNameLogin;

            txtStaffno.Visible = !userNameLogin;
            lbStaffNo.Visible = !userNameLogin;
        }

        private void SaveTextBoxInfo()
        {
            string loginway = checkBoxStaffnoLogin.Checked ? "usestaffnologin" : "usenamelogin";
            Dictionary<string, string> tmpdict = new Dictionary<string, string>
            {
                {"LoginWay", loginway},
                {"LoginName", txtBoxUserName.Text},
                {"LoginIP", txtMESServerIP.Text},
                {"staffno", txtStaffno.Text}
            };
            LoginBll.SaveLoginInfo(tmpdict);
        }

        private void MESLoginDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }
    }
}