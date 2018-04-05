using System;
using System.Windows.Forms;
using DnaLib.Helper;
using DnaMesModel.Model.BasicInfo;
using DnaMesModel.Shared;
using DnaMesUi.Shared.Dialog;
using DnaMesUiBll.BasicInfo;
using DnaMesUiBll.Shared;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinTree;

namespace DnaMesUi.Templetes
{
    public partial class WithTreeForm : BaseForm
    {
        public WithTreeForm()
        {
            InitializeComponent();
            dteStartTime.Enabled = ckStartTime.Checked;
            dteEndTime.Enabled = ckEndTime.Checked;
            _bll.BuildTree(ref uTree, imageList1.Images, p => p.IsMain);
            GridBindingBll<Project>.BindingStyleAndData(ug1, null, "BasicInfo\\Project.xml");
        }

        private readonly ProjectMgtBll _bll = new ProjectMgtBll();

        #region 查询区

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var code = txtCode.Text.Trim();
            var name = txtName.Text.Trim();
            var startTime = dteStartTime.Enabled ? dteStartTime.DateTime : SysInfo.IllegalDateTime;
            var endTime = dteEndTime.Enabled ? dteEndTime.DateTime : SysInfo.IllegalDateTime;
            var exp = _bll.BuildExp(code, name, startTime, endTime);
            _bll.BuildTree(ref uTree, imageList1.Images, exp);
        }

        private void ckStartTime_CheckedChanged(object sender, EventArgs e)
        {
            dteStartTime.Enabled = ((UltraCheckEditor) sender).Checked;
        }

        private void ckEndTime_CheckedChanged(object sender, EventArgs e)
        {
            dteEndTime.Enabled = ((UltraCheckEditor) sender).Checked;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCode.Clear();
            txtName.Clear();
            ckStartTime.ResetChecked();
            ckEndTime.ResetChecked();
            dteStartTime.ResetDateTime();
            dteEndTime.ResetDateTime();
        }

        #endregion

        #region 树控件区

        private UltraTreeNode SelectedNode => uTree.SelectedNodes?[0];

        private void uTree_AfterExpand(object sender, NodeEventArgs e)
        {
            _bll.AfterExpand(e.TreeNode, imageList1.Images);
        }

        private void uTree_AfterSelect(object sender, SelectEventArgs e)
        {
            SetToolsEnable(SelectedNode?.Tag is Project, "Add", "Delete", "Edit", "AddChild");

            foreach (var node in e.NewSelections)
            {
                node.Expanded = true;
            }

            _bll.AfterSelect(ref ug1, e);
        }

        #endregion

        #region 工具栏区

        private void toolBarManager_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Add":
                    if (SelectedNode?.Tag is Project)
                    {
                        var pProj = SelectedNode.Parent?.Tag as Project;
                        var form = new ProjectMgtAddEdit("新增项目");
                        if (form.ShowDialog(this)==DialogResult.OK)
                        {
                            if (_bll.AddProject(form.Project,pProj))
                            {
                                MessageBoxHelper.ShowInformationOk("操作成功！");
                            }
                        }
                    }

                    break;

                case "Edit":
                    break;

                case "Delete":
                    break;

                case "Refresh":
                    _bll.BuildTree(ref uTree, imageList1.Images, p => p.IsMain);
                    GridBindingBll<Project>.BindingData(ug1, null, "BasicInfo\\Project.xml");
                    break;

                case "AddChild":
                    break;
            }
        }

        private void SetToolsEnable(bool enable, params string[] keys)
        {
            foreach (var key in keys)
            {
                var tools = toolBarManager.Toolbars["SysToolBar"].Tools;
                if (tools.Exists(key))
                {
                    tools[key].SharedProps.Enabled = enable;
                }
            }
        }

        #endregion
    }
}