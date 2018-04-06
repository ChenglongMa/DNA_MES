using System;
using System.Drawing;
using System.Windows.Forms;
using DnaLib.Control;
using DnaLib.Helper;
using DnaMesModel.Model.BasicInfo;
using DnaMesModel.Shared;
using DnaMesUi.Shared.Dialog;
using DnaMesUiBll.BasicInfo;
using DnaMesUiBll.Shared;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
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
            GridBindingBll<Project>.BindingStyleAndData(ug1, null, FieldName);
        }

        private readonly ProjectMgtBll _bll = new ProjectMgtBll();
        private const string FieldName = "BasicInfo\\Project.xml";
        #region 其他

        private void RefreshData()
        {
            _bll.BuildTree(ref uTree, imageList1.Images, p => p.IsMain);
            GridBindingBll<Project>.BindingData(ug1, null, FieldName);
        }

        #endregion
        #region 查询区

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var code = txtCode.Text.Trim();
            var name = txtName.Text.Trim();
            var startTime = dteStartTime.Enabled ? dteStartTime.DateTime : SysInfo.IllegalDateTime;
            var endTime = dteEndTime.Enabled ? dteEndTime.DateTime : SysInfo.IllegalDateTime;
            var exp = _bll.BuildExp(code, name, startTime, endTime);
            var projs = _bll.GetDataSource(exp);
            GridBindingBll<Project>.BindingData(ug1, projs, FieldName);
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

        private UltraTreeNode SelectedNode => uTree.SelectedNodes.IsNullOrEmpty() ? null : uTree.SelectedNodes[0];

        private void uTree_AfterExpand(object sender, NodeEventArgs e)
        {
            _bll.AfterExpand(e.TreeNode, imageList1.Images);
        }

        private void uTree_AfterSelect(object sender, SelectEventArgs e)
        {
            ResetNodeAppearance();
            SetToolsEnable(SelectedNode?.Tag is Project, "Add", "Delete", "Edit", "AddChild");

            foreach (var node in uTree.SelectedNodes)
            {
                node.Expanded = true;
            }

            var children = _bll.GetChildren(uTree.SelectedNodes);
            GridBindingBll<Project>.BindingData(ug1, children, FieldName);
        }

        private void ResetNodeAppearance()
        {
            uTree.Override.NodeAppearance.ResetBackColor();
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
                        if (form.ShowDialog(this) == DialogResult.OK)
                        {
                            if (_bll.AddProject(form.Project, pProj))
                            {
                                MsgBoxLib.ShowInformationOk("操作成功！");
                            }
                        }
                    }
                    RefreshData();
                    break;

                case "Edit":
                    break;

                case "Delete":
                    break;

                case "Refresh":
                    RefreshData();
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

        #region Grid区

        private void ug1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            ResetNodeAppearance();
            if (!(e.Row.ListObject is Project proj)) return;
            var node=_bll.FindNode(uTree, proj);
            if (node==null)
            {
                MsgBoxLib.ShowStop("未找到该项目结构");
            }
            else
            {
                node.Override.NodeAppearance.BackColor=Color.DarkTurquoise;
            }
        }

        #endregion
    }
}