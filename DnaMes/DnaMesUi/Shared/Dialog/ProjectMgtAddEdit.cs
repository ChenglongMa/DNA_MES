using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DnaLib.Control;
using DnaLib.Helper;
using DnaMesModel.Model.BasicInfo;
using DnaMesModel.Shared;
using DnaMesUiBll.BasicInfo;
using DnaMesUiBll.Shared;

namespace DnaMesUi.Shared.Dialog
{
    public partial class ProjectMgtAddEdit : BaseDialog
    {
        public ProjectMgtAddEdit()
        {
            InitializeComponent();
            txtCode.NullText = "必填项";
            txtName.NullText = "必填项";
        }

        private readonly ProjectMgtBll _bll = new ProjectMgtBll();

        public ProjectMgtAddEdit(string text, Project proj = null) : this()
        {
            Text = text;
            Project = proj;
            if (proj == null)
            {
                //项目无父节点时只能为主项目
                ckIsMain.Checked = true;
                ckIsMain.Enabled = false;
                tipForIsMain.SetError(ckIsMain, "该节点下只能添加主项目");
            }
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        /// <summary>
        /// 界面间传递值
        /// </summary>
        public Project Project { get; set; }

        private Project BuildProject()
        {
            var code = txtCode.Text.Trim();
            var name = txtName.Text.Trim();
            var startTime = dteStartTime.DateTime;
            var endTime = dteEndTime.DateTime;
            var isMain = ckIsMain.Checked;
            return new Project
            {
                Code = code,
                Name = name,
                StartingTime = startTime,
                EndingTime = endTime,
                IsMain = isMain,
            };
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Project = BuildProject();
            if (Project == null)
            {
                return;
            }

            if (_bll.IsExist(Project))
            {
                MsgBoxLib.ShowError("该项目已存在");
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Close();
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            errorProvider.SetError(txtCode, txtCode.Text.IsNullOrEmpty() ? "项目编号不允许为空" : null);
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            errorProvider.SetError(txtName, txtName.Text.IsNullOrEmpty() ? "项目名称不允许为空" : null);
        }

        private void dteStartTime_Validating(object sender, CancelEventArgs e)
        {
            errorProvider.SetError(dteStartTime, dteStartTime.DateTime.IsLegalDate() ? null : "指定日期不合法");
        }

        private void dteEndTime_Validating(object sender, CancelEventArgs e)
        {
            errorProvider.SetError(dteEndTime, dteEndTime.DateTime.IsLegalDate() ? null : "指定日期不合法");
        }
    }
}