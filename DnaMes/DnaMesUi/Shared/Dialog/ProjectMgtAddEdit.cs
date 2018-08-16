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
    public partial class ProjectMgtAddEdit : BaseDialog<Project>
    {
        public ProjectMgtAddEdit()
        {
            InitializeComponent();
            txtCode.NullText = "必填项";
            txtName.NullText = "必填项";
            txtDescription.NullText = "项目描述(选填项)";
            ckIsMain.Enabled = false;
        }
        /// <summary>
        /// 项目新增或编辑窗体
        /// </summary>
        /// <param name="text">窗体显示名称</param>
        /// <param name="proj">待编辑项目，非父项目</param>
        public ProjectMgtAddEdit(string text, Project proj = null) : this()
        {
            Text = text;
            //pproj==null即为新增
            if (proj !=null)
            {
                txtCode.ReadOnly = true;
                tipForIsMain.SetError(txtCode, "该值不可修改");
                BindingModel(proj);
            }

            _isEditable = proj != null;
        }
        /// <summary>
        /// true为“编辑”状态，false为“新增”状态
        /// </summary>
        private readonly bool _isEditable; 

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        protected override BaseBll<Project> Bll => new ProjectMgtBll();

        public override Project TransModel => new Project
        {
            Code = txtCode.Text.Trim(),
            Name = txtName.Text.Trim(),
            StartingTime = dteStartTime.DateTime,
            EndingTime = dteEndTime.DateTime,
            IsMain = ckIsMain.Checked,
            Description = txtDescription.Text,
        };

        protected sealed override void BindingModel(Project proj)
        {
            txtCode.Text = proj.Code;
            txtName.Text = proj.Name;
            dteStartTime.DateTime = proj.StartingTime;
            dteEndTime.DateTime = proj.EndingTime;
            ckIsMain.Checked = proj.IsMain;
            txtDescription.Text = proj.Description;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!_isEditable && Bll.IsExist(TransModel))
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