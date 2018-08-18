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
using DnaMesUiBll.BasicInfo;
using DnaMesUiBll.Shared;

namespace DnaMesUi.Shared.Dialog
{
    public partial class ProcessMgtAddEdit : Form//BaseDialog<Process> //Form //
    {
        public ProcessMgtAddEdit()
        {
            InitializeComponent();
            txtCode.NullText = "必填项";
            txtName.NullText = "必填项";
            txtDescription.NullText = "项目描述(选填项)";
        }

        public ProcessMgtAddEdit(string text, Process proc = null) : this()
        {
            Text = text;
            if (proc == null)
            {
                _isEditable = false;
                //项目无父节点时只能为主项目
                ckIsMain.Checked = true;
                ckIsMain.Enabled = false;
                tipForIsValid.SetError(ckIsMain, "该节点下只能添加主项目");
            }
            else
            {
                _isEditable = true;
//                BindingModel(proj);
                //txtCode.Enabled = false;
                txtCode.ReadOnly = true;
                tipForIsValid.SetError(txtCode, "该值不可修改");
            }
        }


        private BaseBll<Process> Bll => new ProcessMgtBll();
        private readonly bool _isEditable; //true为“编辑”状态，false为“新增”状态
        public Process TransModel { get; } //TODO:通过控件构建该属性

        private void BindingModel(Process proc)
        {
            txtCode.Text = proc.Code;
            txtName.Text = proc.Name;
            ckIsMain.Checked = proc.IsValid;
            txtDescription.Text = proc.Description;

        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        /// <summary>
        /// 界面间传递值
        /// </summary>
        public Process Process => new Process
        {
            Code = txtCode.Text.Trim(),
            Name = txtName.Text.Trim(),
            IsValid = ckIsMain.Checked,
            Description = txtDescription.Text,
        };

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