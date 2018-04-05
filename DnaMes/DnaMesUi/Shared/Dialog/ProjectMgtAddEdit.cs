using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DnaLib.Helper;
using DnaMesModel.Model.BasicInfo;
using DnaMesModel.Shared;

namespace DnaMesUi.Shared.Dialog
{
    public partial class ProjectMgtAddEdit : BaseDialog
    {
        public ProjectMgtAddEdit()
        {
            InitializeComponent();
        }

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
            if (txtCode.Text.IsNullOrEmpty())
            {
                errorProvider.SetError(txtCode, "项目编号不允许为空");
                return null;
            }
            if (txtName.Text.IsNullOrEmpty())
            {
                errorProvider.SetError(txtName, "项目名称不允许为空");
                return null;
            }
            if (!dteStartTime.DateTime.IsLegalDate())
            {
                errorProvider.SetError(dteStartTime, "指定日期不合法");
                return null;
            }

            if (!dteEndTime.DateTime.IsLegalDate())
            {
                errorProvider.SetError(dteEndTime, "指定日期不合法");
                return null;
            }
            var code = txtCode.Text.Trim();
            var name = txtName.Text.Trim();
            var startTime = dteStartTime.DateTime;
            var endTime = dteEndTime.DateTime;
            return new Project
            {
                Code = code,
                Name = name,
                StartingTime = startTime,
                EndingTime = endTime,
            };
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Project = BuildProject();
            if (Project == null)
            {
                return;
            }
            
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Close();
        }
    }
}