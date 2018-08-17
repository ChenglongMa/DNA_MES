using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

namespace DnaMesUi.BasicInfo
{
    public partial class ProcessMgtForm : BaseForm
    {
        private readonly ProcessMgtBll _bll = new ProcessMgtBll();
        private const string FieldName2 = "BasicInfo\\Step.xml";

        public ProcessMgtForm()
        {
            InitializeComponent();
            dteStartTime.Enabled = ckStartTime.Checked;
            dteEndTime.Enabled = ckEndTime.Checked;
            _bll.BuildTree(ref uTree, imageList1.Images);
            FieldName = "BasicInfo\\Process.xml";
            GridBindingBll<Process>.BindingStyleAndData(ug1, null, FieldName);
            GridBindingBll<Step>.BindingStyleAndData(ug2, null, FieldName2);
        }


        #region 其他

        private void RefreshData()
        {
            _bll.BuildTree(ref uTree, imageList1.Images);
            GridBindingBll<Process>.BindingData(ug1, null, FieldName);
            GridBindingBll<Step>.BindingData(ug2, null, FieldName2);
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
            var proj = _bll.GetDataSource(exp).FirstOrDefault(); //只能查询单个项目
            var node = _bll.FindNode(uTree, proj);
            if (node != null)
            {
                node.Override.NodeAppearance.BackColor = Color.DarkTurquoise;
                NodesWithColor.Enqueue(node);
            }
            else
            {
                MsgBoxLib.ShowWarning("无查询结果");
            }
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

        private UltraGridRow SelectedProcRow => ug1.Selected.Rows.IsNullOrEmpty() ? null : ug1.Selected.Rows[0];
        private UltraGridRow SelectedStepRow => ug2.Selected.Rows.IsNullOrEmpty() ? null : ug2.Selected.Rows[0];

        private void uTree_AfterExpand(object sender, NodeEventArgs e)
        {
            _bll.AfterExpand(e.TreeNode, imageList1.Images);
        }

        private void uTree_AfterSelect(object sender, SelectEventArgs e)
        {
            SetToolsEnable(SelectedNode?.Tag is Project, "Add");
            foreach (var node in uTree.SelectedNodes)
            {
                node.Expanded = true;
            }

            if (SelectedNode?.Tag == null)
            {
                return;
            }

            var dataSource = _bll.GetProcesses(SelectedNode.Tag as Project);
            GridBindingBll<Process>.BindingData(ug1, dataSource, FieldName);
        }

        #endregion

        #region 工具栏区

        private void toolBarManager_ToolClick(object sender, ToolClickEventArgs e)
        {
            var pProj = SelectedNode?.Parent?.Tag as Project;
            ProcessMgtAddEdit form;
            switch (e.Tool.Key)
            {
                case "Refresh":
                default:
                    RefreshData();
                    break;
                case "Add":

                    form = new ProcessMgtAddEdit("新增工艺");
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        if (_bll.AddModel(form.TransModel, pProj))
                        {
                            MsgBoxLib.ShowInformationOk("操作成功！");
                            //将父类加入List，表示需要从数据库中更新子类数据
                            if (pProj != null) _bll.ParentsToBeUpdated.AddFirst(pProj.Code);
                        }
                        else
                        {
                            MsgBoxLib.ShowStop("操作失败");
                        }
                    }

                    goto default;

                case "Edit":
                    form = new ProcessMgtAddEdit("编辑工艺", SelectedNode?.Tag as Project);
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        if (_bll.UpdateProcess(form.TransModel, pProj))
                        {
                            MsgBoxLib.ShowInformationOk("操作成功！");
                            //将父类加入List，表示需要从数据库中更新子类数据
                            if (pProj != null) _bll.ParentsToBeUpdated.AddFirst(pProj.Code);
                        }
                        else
                        {
                            MsgBoxLib.ShowStop("操作失败");
                        }
                    }

                    goto default;

                case "Delete":
                    if (SelectedNode?.Tag is Process proc)
                    {
                        if (_bll.DeleteProcess(proc, pProj))
                        {
                            MsgBoxLib.ShowInformationOk("操作成功");
                            //TODO: 将父类加入List，表示需要从数据库中更新子类数据
                            //if (pProj != null) _projectsNeedRefresh.AddFirst(pProj.Code);
                        }
                        else
                        {
                            MsgBoxLib.ShowStop("操作失败");
                        }
                    }
                    else
                    {
                        MsgBoxLib.ShowWarning("请先选择要删除的工艺");
                    }

                    goto default;

                case "AddChild":
                    //TODO：还未想出解决方案
                    goto default;
            }
        }

        //TODO:修改逻辑
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
            ResetNodeBackColor();
            if (!(e.Row.ListObject is Process proj)) return;
            var node = new UltraTreeNode(); //TODO: _bll.FindNode(uTree, proj);
            if (node == null)
            {
                MsgBoxLib.ShowWarning("未找到该项目结构");
            }
            else
            {
                node.Override.NodeAppearance.BackColor = Color.DarkTurquoise;
                NodesWithColor.Enqueue(node);
            }
        }

        #endregion

        #region 右键菜单

        private void cmsProc_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var proc = SelectedProcRow?.ListObject as Process;
            编辑工艺ToolStripMenuItem.Enabled = proc != null;
            激活工艺ToolStripMenuItem.Enabled = proc != null && !proc.IsValid;
            删除工艺ToolStripMenuItem.Enabled = proc != null;
        }

        private void cmsStep_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            新增工序ToolStripMenuItem.Enabled = SelectedProcRow?.ListObject is Process;
            var step = SelectedStepRow?.ListObject as Step;
            编辑工序ToolStripMenuItem.Enabled = step != null;
            删除工序ToolStripMenuItem.Enabled = step != null;
        }

        #endregion

        private void 激活工艺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var row in ug1.Rows)
            {
                if (row == SelectedProcRow || !(row?.ListObject is Process proc))
                {
                    continue;
                }

                if (proc.IsValid)
                {
                    if (!MsgBoxLib.ShowQuestion("发现已激活工艺，确定要更改吗？"))
                    {
                        return;
                    }

                    proc.IsValid = false;
                    _bll.UpdateProcess(proc);
                }
            }

            if (SelectedProcRow?.ListObject is Process p)
            {
                p.IsValid = true;
                _bll.UpdateProcess(p);
                MsgBoxLib.ShowInformationOk("激活工艺设置成功");
            }
        }
    }
}