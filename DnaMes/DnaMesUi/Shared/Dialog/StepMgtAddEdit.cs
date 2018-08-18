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
    public partial class StepMgtAddEdit : BaseDialog<Step>
    {
        public StepMgtAddEdit()
        {
            InitializeComponent();
            txtCode.NullText = "必填项";
            txtName.NullText = "必填项";
            txtDescription.NullText = "工序描述(选填项)";
            tip.SetError(numIndex, "工序号设为相同值表示“同步工序”，即完成任意其一即可");
        }

        /// <summary>
        /// <see cref="ProjectMgtAddEdit"/>
        /// </summary>
        /// <param name="text"></param>
        /// <param name="step">待编辑工序</param>
        public StepMgtAddEdit(string text, Step step = null) : this()
        {
            Text = text;
            if (step != null)
            {
                txtCode.ReadOnly = true;
                tip.SetError(txtCode, "该值不可修改");
                BindingModel(step);
            }

            _isEditable = step != null;
        }


        protected override BaseBll<Step> Bll => new StepMgtBll();
        private readonly bool _isEditable; //true为“编辑”状态，false为“新增”状态

        protected sealed override void BindingModel(Step step)
        {
            txtCode.Text = step.Code;
            txtName.Text = step.Name;
            numIndex.Value = (decimal) step.Index;
            txtDescription.Text = step.Description;
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
        public override Step TransModel => new Step
        {
            Code = txtCode.Text.Trim(),
            Name = txtName.Text.Trim(),
            Index = (double) numIndex.Value,
            Description = txtDescription.Text,
        };

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!_isEditable && Bll.IsExist(TransModel))
            {
                MsgBoxLib.ShowError("该工序已存在");
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
            errorProvider.SetError(txtCode, txtCode.Text.IsNullOrEmpty() ? "工序编码不允许为空" : null);
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            errorProvider.SetError(txtName, txtName.Text.IsNullOrEmpty() ? "工序名称不允许为空" : null);
        }

        private void numIndex_Validating(object sender, CancelEventArgs e)
        {
            errorProvider.SetError(numIndex, numIndex.Value <= 0 ? "工序号不允许小于0" : null);
        }
    }
}