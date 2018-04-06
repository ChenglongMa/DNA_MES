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
            //if (txtCode.Text.IsNullOrEmpty())
            //{
            //    errorProvider.SetError(txtCode, "项目编号不允许为空");
            //    return null;
            //}
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
        /// <summary>
        /// 验证控制值
        /// </summary>
        /// <param name="control"></param>
        /// <param name="fun"></param>
        /// <param name="errorMsg"></param>
        private void ValidateControl(Control control,Func<Control, bool> fun, string errorMsg)
        {
            errorProvider.SetError(control, fun(control) ? null : errorMsg);
        }
        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            if (txtCode.Text.IsNullOrEmpty())
            {
                errorProvider.SetError(txtCode, "项目编号不允许为空");
            }
            else
            {
                errorProvider.SetError(txtCode, "");
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (txtName.Text.IsNullOrEmpty())
            {
                errorProvider.SetError(txtName, "项目编号不允许为空");
            }
            else
            {
                errorProvider.SetError(txtName, null);
            }
        }

        private void dteStartTime_Validating(object sender, CancelEventArgs e)
        {
            if (!dteStartTime.DateTime.IsLegalDate())
            {
                errorProvider.SetError(dteStartTime, "指定日期不合法");
            }
            else
            {
                errorProvider.SetError(dteStartTime, string.Empty);
            }
        }

        private void dteEndTime_Validating(object sender, CancelEventArgs e)
        {
            if (!dteEndTime.DateTime.IsLegalDate())
            {
                errorProvider.SetError(dteEndTime, "指定日期不合法");
            }
            else
            {
                errorProvider.SetError(dteEndTime, string.Empty);
            }
        }
    }
}