using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DnaLib.Global;
using DnaLib.Helper;
using DnaMesBll.Shared;

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
                setDefaultValue();

                if (loginDict != null && loginDict.ContainsKey("LoginWay"))
                {
                    if (loginDict["LoginWay"] == "staffnologin")
                    {
                        setUserNameLogin(false);
                        this.checkBoxStaffnoLogin.Checked = true;
                        txtStaffno.Text = loginDict["staffno"];
                    }
                    else
                    {
                        setUserNameLogin();
                        checkBoxStaffnoLogin.Checked = false;
                    }
                }
                else //默认用户名登入
                {
                    setUserNameLogin();
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
                bool rtnrslt = false;
                string strUserName;
                string strPassword;
                string staffno = null;
                string serverIp = txtMESServerIP.Text;
                if(string.IsNullOrEmpty(serverIp))
                    serverIp = LoginBll.GetIPFromLocalFile();
                SysInfo.UserIP = serverIp;
                txtMESServerIP.Text = serverIp;
                SysInfo.UserIP = serverIp;
                LoginBll bslLogin = new LoginBll(txtMESServerIP.Text);
                try
                {
                    if (bslLogin.ExistDifferLocalAndServerFile())
                    {
                        MessageBoxHelper.ShowWarning("检测到服务器文件与本地文件存在差异，系统将更新本地文件...");
                        bslLogin.UpdateLocalFile();
                        MessageBoxHelper.ShowInformationOK("更新成功！");
                    }
                }
                catch (Exception ex)
                {
                    LogService.WriteErrorLog(ex,"CAXA.MES.UI");
                    MessageBoxHelper.ShowWarning("更新失败，系统自动从本地获取登入信息！");
                }

                            
                if (checkBoxStaffnoLogin.Checked==false) //员工姓名登入
                {
                    setUserNameLogin();
                    strUserName = txtBoxUserName.Text;
                    strPassword = txtBoxPassword.Text;
                    rtnrslt = LoginBll.CheckUser(strUserName, strPassword, txtMESServerIP.Text);
                    if (rtnrslt == true)
                        LoginBll.RegisterUser();
                    else
                    {
                        Cursor = Cursors.Default;
                        string strSecurity = string.Format("用户{0}登录授权失败！",strUserName);
                        LogService.WriteErrorLog(null,strSecurity, "CAXA.MES.UI");
                        return;
                    }

                    //SysInfo.AllAuthIDDict = LoginBll.GetAllOperationAuthDict();
                    SysInfo.Staffno = LoginBll.GetPersonByName(strUserName).staffno;
                    SysInfo.SysUserAuthIDDict = LoginBll.GetOperationAuthDictByName(strUserName);
                }
                else
                {
                    setUserNameLogin(false);
                    staffno = this.txtStaffno.Text; //获取工号
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
                        LogService.WriteErrorLog(null, strSecurity, "CAXA.MES.UI");
                        return;
                    }

                    strUserName = person.name;
                    SysInfo.Staffno = staffno;
                }
                SysInfo.SysUserLoginName = strUserName;
                SysInfo.WebService = "http://" + serverIp.Replace("http://", "").Replace("\r\n", "").Replace("/", "") + ":" + ConfigurationManager.AppSettings["WebPort"] + "/" +
                       ConfigurationManager.AppSettings["WebServiceName"] +  "/FileService.asmx"; //报表设计器
                saveTextBoxInfo();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                LogService.WriteErrorLog(ex, "CAXA.MES.UI");
                MessageBoxHelper.ShowWarning(ex.Message);
            }

        }


        //取消登入
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
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
                setDefaultValue();

                Height = 285;
                btnLogin.Location = new Point(btnLogin.Location.X, this.btnLogin.Location.Y + 40);
                btnExit.Location = new Point(btnExit.Location.X, this.btnExit.Location.Y + 40);


                this.pdcLabelIP.Visible = true;
                this.txtMESServerIP.Visible = true;
                this.btnSaveIP.Visible = true;

                this.txtMESServerIP.Text = LoginBll.GetIPFromLocalFile();
            }
            catch (Exception ex)
            {

                LogService.WriteErrorLog(ex, "CAXA.MES.UI");
                MessageBoxHelper.ShowWarning("登入系统失败！");
            }

        }

        private void pdcBtnSaveIP_Click(object sender, EventArgs e)
        {
            try
            {
                setDefaultValue();

                saveTextBoxInfo();
                //调试环境下，需要手动修改bin目录下的exe.config。
                //打包后，app.config不进入包中，真正起作用的文件为exe.config文件。
                //MessageBoxHelper.ShowWarning("请您点击退出然后再重新启动系统！");
            }
            catch (Exception ex)
            {
                LogService.WriteErrorLog(ex, "CAXA.MES.UI");
                MessageBoxHelper.ShowWarning("登入系统失败！");
            }

        }

        private void setDefaultValue()
        {
            this.Height = 250;
            this.btnLogin.Location = new Point(55, 165);
            this.btnExit.Location = new Point(275, 165);

            this.pdcLabelIP.Visible = false;
            this.txtMESServerIP.Visible = false;
            this.btnSaveIP.Visible = false;
        }

        //切换为工号登入
        private void checkBoxStaffnoLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxStaffnoLogin.Checked == true)
            {
                setUserNameLogin(false); //设置为工号登入，而不是用户名
            }
            else
            {
                setDefaultValue();
                setUserNameLogin();
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

        private void setUserNameLogin(bool userNameLogin = true)
        {
            this.lbName.Visible = userNameLogin;
            this.txtBoxUserName.Visible = userNameLogin;
            this.pdcLbPswd.Visible = userNameLogin;
            this.txtBoxPassword.Visible = userNameLogin;

            this.txtStaffno.Visible = !userNameLogin;
            this.lbStaffNo.Visible = !userNameLogin;
        }

        private void saveTextBoxInfo()
        {
            string loginway = checkBoxStaffnoLogin.Checked == true ? "usestaffnologin" : "usenamelogin";
            Dictionary<string, string> tmpdict = new Dictionary<string, string>();
            tmpdict.Add("LoginWay", loginway);
            tmpdict.Add("LoginName", txtBoxUserName.Text);
            tmpdict.Add("LoginIP", txtMESServerIP.Text);
            tmpdict.Add("staffno", txtStaffno.Text);
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
