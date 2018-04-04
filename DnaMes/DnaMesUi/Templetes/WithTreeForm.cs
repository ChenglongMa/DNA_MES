using System;
using DnaLib.Helper;
using DnaMesModel.Model.BasicInfo;
using DnaMesModel.Shared;
using DnaMesUiBll.BasicInfo;
using DnaMesUiBll.Shared;
using Infragistics.Win.UltraWinEditors;

namespace DnaMesUi.Templetes
{
    public partial class WithTreeForm : BaseForm
    {
        public WithTreeForm()
        {
            InitializeComponent();
            dteStartTime.Enabled = ckStartTime.Checked;
            dteEndTime.Enabled = ckEndTime.Checked;
            _bll.BuildTree(ref uTree, imageList1.Images,p=>p.IsMain);
            GridBindingBll<Project>.BindingStyleAndData(ug1, null, "BasicInfo\\Project.xml");
        }

        private readonly ProjectMgtBll _bll = new ProjectMgtBll();

        private void uTree_AfterSelect(object sender, Infragistics.Win.UltraWinTree.SelectEventArgs e)
        {
            foreach (var node in e.NewSelections)
            {
                node.Expanded = true;
            }

            _bll.AfterSelect(ref ug1, e);
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            var code = txtCode.Text.Trim();
            var name = txtName.Text.Trim();
            var startTime = dteStartTime.Enabled?dteStartTime.DateTime:SysInfo.IllegalDateTime;
            var endTime = dteEndTime.Enabled ? dteEndTime.DateTime : SysInfo.IllegalDateTime;
            var exp=_bll.BuildExp(code, name, startTime, endTime);
            _bll.BuildTree(ref uTree, imageList1.Images, exp);
        }

        private void ckStartTime_CheckedChanged(object sender, System.EventArgs e)
        {
            dteStartTime.Enabled = ((UltraCheckEditor) sender).Checked;
        }

        private void ckEndTime_CheckedChanged(object sender, System.EventArgs e)
        {
            dteEndTime.Enabled = ((UltraCheckEditor)sender).Checked;
        }

        private void btnClear_Click(object sender, System.EventArgs e)
        {
            txtCode.Clear();
            txtName.Clear();
            ckStartTime.ResetChecked();
            ckEndTime.ResetChecked();
            dteStartTime.ResetDateTime();
            dteEndTime.ResetDateTime();
        }

        private void uTree_AfterExpand(object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e)
        {
            _bll.AfterExpand(e.TreeNode,imageList1.Images);
        }
    }
}