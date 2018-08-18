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
    public partial class ProcessMgtAddEdit : BaseDialog<Process>
    {
        public ProcessMgtAddEdit()
        {
            InitializeComponent();
            txtCode.NullText = "必填项";
            txtName.NullText = "必填项";
            txtDescription.NullText = "工艺描述、步骤等(选填项)";
        }
        /// <summary>
        /// <see cref="ProjectMgtAddEdit"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="proc"></param>
        public ProcessMgtAddEdit(string text, Process proc = null) : this()
        {
            Text = text;
            if (proc!= null)
            {
                txtCode.ReadOnly = true;
                tipForIsValid.SetError(txtCode, "该值不可修改");
                BindingModel(proc);
            }

            _isEditable = proc != null;
        }


        protected override BaseBll<Process> Bll => new ProcessMgtBll();
        private readonly bool _isEditable; //true为“编辑”状态，false为“新增”状态

        protected sealed override void BindingModel(Process proc)
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

        /// <inheritdoc />
        /// <summary>
        /// 界面间传递值
        /// </summary>
        public override Process TransModel => new Process
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
                MsgBoxLib.ShowError("该工艺已存在");
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Close();
            DialogResult = DialogResult.Cancel;
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            errorProvider.SetError(txtCode, txtCode.Text.IsNullOrEmpty() ? "工艺编号不允许为空" : null);
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            errorProvider.SetError(txtName, txtName.Text.IsNullOrEmpty() ? "工艺名称不允许为空" : null);
        }
    }
}