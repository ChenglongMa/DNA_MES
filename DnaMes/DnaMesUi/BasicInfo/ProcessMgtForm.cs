using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DnaLib.Control;
using DnaLib.Helper;
using DnaMesModel.Link.BasicInfo;
using DnaMesModel.Model.BasicInfo;
using DnaMesModel.Shared;
using DnaMesUi.Shared.Dialog;
using DnaMesUiBll.BasicInfo;
using DnaMesUiBll.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinTree;

namespace DnaMesUi.BasicInfo
{
    public partial class ProcessMgtForm : BaseForm
    {
        private readonly ProcessMgtBll _bll = new ProcessMgtBll();
        private readonly StepMgtBll _bllStep = new StepMgtBll();
        private List<Process> _procDataSrc;
        private List<Step> _stepDataSrc;
        
        private const string FieldName2 = "BasicInfo\\Step.xml";

        public ProcessMgtForm()
        {
            InitializeComponent();
            dteStartTime.Enabled = ckStartTime.Checked;
            dteEndTime.Enabled = ckEndTime.Checked;
            _bll.BuildTree(ref uTree, imageList1.Images);
            FieldName = "BasicInfo\\Process.xml";
            GridBindingBll<Process>.BindingStyleAndData(ug1, _procDataSrc, FieldName);
            GridBindingBll<Step>.BindingStyleAndData(ug2, _stepDataSrc, FieldName2);
        }


        #region 其他

        private void RefreshProc()
        {
            GridBindingBll<Process>.BindingData(ug1, _procDataSrc, FieldName);
            _stepDataSrc = null;
        }

        private void RefreshStep()
        {
            if (_stepDataSrc.IsNotNullorEmpty())
            {
                _stepDataSrc.Sort((s1, s2) => (int)(100 * (s1.Index - s2.Index)));
            }
            GridBindingBll<Step>.BindingData(ug2, _stepDataSrc, FieldName2);
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
        private UltraGridRow _activeProcRow, _activeStepRow;

        private void uTree_AfterExpand(object sender, NodeEventArgs e)
        {
            _bll.AfterExpand(e.TreeNode, imageList1.Images);
        }

        private void uTree_AfterSelect(object sender, SelectEventArgs e)
        {
            foreach (var node in uTree.SelectedNodes)
            {
                node.Expanded = true;
            }

            if (SelectedNode?.Tag == null)
            {
                return;
            }

            _procDataSrc = _bll.GetChildren<Project, Process>(SelectedNode.Tag as Project);
            RefreshProc();

        }

        #endregion

        #region 工具栏区

        private void toolBarManager_ToolClick(object sender, ToolClickEventArgs e)
        {
            var pProj = SelectedNode?.Parent?.Tag as Project;
            switch (e.Tool.Key)
            {
                case "Refresh":
                default:
                    RefreshProc();
                    RefreshStep();
                    break;
                case "Add":

                    goto default;

                case "Edit":
                    goto default;

                case "Delete":

                    goto default;

                case "AddChild":

                    goto default;
            }
        }

        #endregion

        #region Grid区

        private void ug1_MouseDown(object sender, MouseEventArgs e)
        {
            _activeProcRow = GetActiveRow(sender, e);
            var proc = _activeProcRow?.ListObject as Process;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    _stepDataSrc = _bll.GetChildren<Process, Step>(proc);
                    RefreshStep();
                    //左击事件
                    break;
                case MouseButtons.Right:
                    //右击事件
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ug2_MouseDown(object sender, MouseEventArgs e)
        {
            _activeStepRow = GetActiveRow(sender, e);
            switch (e.Button)
            {
                case MouseButtons.Left:

                    //左击事件
                    break;
                case MouseButtons.Right:
                    //右击事件
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// 在MouseDown事件中获取激活行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private static UltraGridRow GetActiveRow(object sender, MouseEventArgs e)
        {
            var activedGrid = sender as UltraGrid;
            var point = new Point(e.X, e.Y);
            var objUiElement = activedGrid?.DisplayLayout.UIElement.ElementFromPoint(point);
            if (objUiElement == null)
                return null;
            var objRow = (UltraGridRow) objUiElement.GetContext(typeof(UltraGridRow));
            activedGrid.ActiveRow = objRow;
            return objRow;
        }

        #endregion

        #region 右键菜单

        private void cmsProc_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tipForProject.Visible = !(SelectedNode?.Tag is Project);
            新增工艺ToolStripMenuItem.Enabled = SelectedNode?.Tag is Project;
            var proc = _activeProcRow?.ListObject as Process;
            编辑工艺ToolStripMenuItem.Enabled = proc != null;
            激活工艺ToolStripMenuItem.Enabled = proc != null && !proc.IsValid;
            删除工艺ToolStripMenuItem.Enabled = proc != null;
        }

        private void cmsStep_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tipForProc.Visible = !(SelectedProcRow?.ListObject is Process);
            新增工序ToolStripMenuItem.Enabled = SelectedProcRow?.ListObject is Process;
            var step = _activeStepRow?.ListObject as Step;
            编辑工序ToolStripMenuItem.Enabled = step != null;
            删除工序ToolStripMenuItem.Enabled = step != null;
        }


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
                    _bll.UpdateModel(proc);
                }
            }

            if (SelectedProcRow?.ListObject is Process p)
            {
                p.IsValid = true;
                _bll.UpdateModel(p);
                MsgBoxLib.ShowInformationOk("激活工艺设置成功");
            }

            RefreshProc();
        }

        private void 新增工艺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pProj = SelectedNode?.Tag as Project;
            var form = new ProcessMgtAddEdit("新增工艺");
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                if (_bll.AddModel(form.TransModel, pProj))
                {
                    MsgBoxLib.ShowInformationOk("操作成功！");
                    //将父类加入List，表示需要从数据库中更新子类数据
                    if (pProj != null) _bll.ParentsToBeUpdated.AddFirst(pProj.Code);
                    RefreshProc();//TODO:待验证
                }
                else
                {
                    MsgBoxLib.ShowStop("操作失败");
                }
            }
        }

        private void 编辑工艺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ProcessMgtAddEdit("编辑工艺", _activeProcRow?.ListObject as Process);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                if (_bll.UpdateModel(form.TransModel))
                {
                    MsgBoxLib.ShowInformationOk("操作成功！");
                    //将父类加入List，表示需要从数据库中更新子类数据
                    //if (pProj != null) _bll.ParentsToBeUpdated.AddFirst(pProj.Code);
                    RefreshProc();
                }
                else
                {
                    MsgBoxLib.ShowStop("操作失败");
                }
            }
        }

        private void 删除工艺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pProj = SelectedNode?.Tag as Project;
            var proc = _activeProcRow?.ListObject as Process;
            if (_bll.DeleteProcess(proc, pProj))
            {
                MsgBoxLib.ShowInformationOk("操作成功");
                RefreshProc();
            }
            else
            {
                MsgBoxLib.ShowStop("操作失败");
            }
        }

        private void 新增工序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pProc = SelectedProcRow?.ListObject as Process;
            var form = new StepMgtAddEdit("新增工序");
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                if (_bllStep.AddModel(form.TransModel, pProc))
                {
                    MsgBoxLib.ShowInformationOk("操作成功！");
                    //将父类加入List，表示需要从数据库中更新子类数据
                    if (pProc != null) _bll.ParentsToBeUpdated.AddFirst(pProc.Code);
                    RefreshStep();
                }
                else
                {
                    MsgBoxLib.ShowStop("操作失败");
                }
            }
        }

        private void 编辑工序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new StepMgtAddEdit("编辑工序", _activeStepRow?.ListObject as Step);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                if (_bllStep.UpdateModel(form.TransModel))
                {
                    MsgBoxLib.ShowInformationOk("操作成功！");
                    //将父类加入List，表示需要从数据库中更新子类数据
                    //if (pProj != null) _bll.ParentsToBeUpdated.AddFirst(pProj.Code);
                    RefreshStep();
                }
                else
                {
                    MsgBoxLib.ShowStop("操作失败");
                }
            }
        }

        private void 删除工序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pProc = SelectedProcRow?.ListObject as Process;
            var step = _activeStepRow?.ListObject as Step;
            if (_bllStep.DeleteModel<Process, ProcessStep>(step, pProc))
            {
                MsgBoxLib.ShowInformationOk("操作成功");
                RefreshStep();
            }
            else
            {
                MsgBoxLib.ShowStop("操作失败");
            }
        }

        #endregion
    }
}