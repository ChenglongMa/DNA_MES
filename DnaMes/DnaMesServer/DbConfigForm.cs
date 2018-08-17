using DnaLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DnaLib.Config;
using DnaLib.Control;
using DnaLib.Helper;

namespace DnaMesServer
{
    public partial class DbConfigForm : Form
    {
        public DbConfigForm()
        {
            InitializeComponent();
            InitialTabPage(pageMES);
        }

        #region 私有属性

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化选项卡内控件内容
        /// </summary>
        /// <param name="page"></param>
        private void InitialTabPage(TabPage page)
        {
            if (page == pageMES)
            {
                var info = DbConfigHelper.GetDbInfo();
                var list = Enum.GetNames(typeof(SqlSugar.DbType));
                cmbMES.DataSource = list;
                cmbMES.SelectedIndex = list.ToList().IndexOf(info.DbType.ToString());
                txtMESServer.Text = info.DataSource;
                txtMESDbName.Text = info.DbName;
                txtMESUser.Text = info.UserId;
                txtMESPswd.Text = info.Password;
            }
        }

        private void btnTestMes_Click(object sender, EventArgs e)
        {
            var dbInfo = new DbInfo
            {
                Name = DbInfoName.MainDb,
                DbType = (SqlSugar.DbType) Enum.Parse(typeof(SqlSugar.DbType),
                    cmbMES.SelectedItem as string ?? throw new InvalidOperationException()),
                DataSource = txtMESServer.Text,
                DbName = txtMESDbName.Text,
                UserId = txtMESUser.Text,
                Password = txtMESPswd.Text
            };
            if (DbConfigHelper.TestConnection(dbInfo, out var errorMessage))
            {
                MsgBoxLib.ShowInformationOk("连接成功");
            }
            else
            {
                MsgBoxLib.ShowError($"连接失败\n错误信息：\n{errorMessage}");
            }
        }

        #endregion

        private void btnSaveMes_Click(object sender, EventArgs e)
        {
            var dbInfo = new DbInfo
            {
                Name = DbInfoName.MainDb,
                DbType = (SqlSugar.DbType) Enum.Parse(typeof(SqlSugar.DbType),
                    cmbMES.SelectedItem as string ?? throw new InvalidOperationException()),
                DataSource = txtMESServer.Text,
                DbName = txtMESDbName.Text,
                UserId = txtMESUser.Text,
                Password = txtMESPswd.Text
            };
            try
            {
                dbInfo.Update();
                MsgBoxLib.ShowInformationOk("保存成功，重启后生效");
            }
            catch (Exception ex)
            {
                MsgBoxLib.ShowError($"保存失败\n错误信息：{ex.Message}");
            }
        }
    }
}