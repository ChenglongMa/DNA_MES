using DnaLib.Helper;
using DnaMesModel.Model.BasicInfo;
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
            _bll.BuildTree(ref uTree, imageList1.Images);
            GridBindingBll<Project>.BindingStyleAndData(ug1, null, "BasicInfo\\Project.xml");
        }

        private readonly ProjectMgtBll _bll = new ProjectMgtBll();

        private void uTree_AfterSelect(object sender, Infragistics.Win.UltraWinTree.SelectEventArgs e)
        {
            _bll.AfterSelect(ref ug1, e);
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            var code = txtCode.Text.Trim();
            var name = txtName.Text.Trim();
            var startTime = dteStartTime.DateTime;
            var endTime = dteEndTime.DateTime;
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
    }
}