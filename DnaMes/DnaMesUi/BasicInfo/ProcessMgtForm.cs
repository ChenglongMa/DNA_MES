using System;
using System.Collections.Generic;
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

namespace DnaMesUi.BasicInfo
{
    public partial class ProcessMgtForm : BaseForm
    {
        public ProcessMgtForm()
        {
            InitializeComponent();
            dteStartTime.Enabled = ckStartTime.Checked;
            dteEndTime.Enabled = ckEndTime.Checked;
            _bll.BuildTree(ref uTree, imageList1.Images);
            GridBindingBll<Process>.BindingStyleAndData(ug1, null, FieldName);
        }

        private readonly ProcessMgtBll _bll = new ProcessMgtBll();
        private const string FieldName = "BasicInfo\\Process.xml";
        //private readonly Queue<UltraTreeNode> _nodesWithColor = new Queue<UltraTreeNode>();
        //private readonly LinkedList<string> _projectsNeedRefresh = new LinkedList<string>();

        #region 其他

        private void RefreshData()
        {
            _bll.BuildTree(ref uTree, imageList1.Images);
            GridBindingBll<Process>.BindingData(ug1, null, FieldName);
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
            //GridBindingBll<Process>.BindingData(ug1, projs, FieldName);
            //TODO:更新逻辑
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
            SetToolsEnable(SelectedNode?.Tag is Project, "Add", "Delete", "Edit", "AddChild");

            foreach (var node in uTree.SelectedNodes)
            {
                node.Expanded = true;
            }

            var dataSource = _bll.GetProcesses(uTree.SelectedNodes);
            GridBindingBll<Process>.BindingData(ug1, dataSource, FieldName);
        }

        //private void ResetNodeBackColor()
        //{
        //    while (_nodesWithColor.Count > 0)
        //    {
        //        var node = _nodesWithColor.Dequeue();
        //        node.Override.NodeAppearance.ResetBackColor();
        //    }
        //}

        #endregion

        #region 工具栏区

        private void toolBarManager_ToolClick(object sender, ToolClickEventArgs e)
        {
            var pProj = SelectedNode?.Parent?.Tag as Process;
            ProcessMgtAddEdit form;
            switch (e.Tool.Key)
            {
                case "Refresh":
                default:
                    RefreshData();
                    break;
                case "Add":

                    form = new ProcessMgtAddEdit("新增项目");
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        if (_bll.AddProcess(form.Process, pProj))
                        {
                            MsgBoxLib.ShowInformationOk("操作成功！");
                            //将父类加入List，表示需要从数据库中更新子类数据
                            if (pProj != null) _projectsNeedRefresh.AddFirst(pProj.Code);
                        }
                        else
                        {
                            MsgBoxLib.ShowStop("操作失败");
                        }
                    }

                    goto default;

                case "Edit":
                    form = new ProcessMgtAddEdit("编辑项目", SelectedNode?.Tag as Process);
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        if (_bll.UpdateProcess(form.Process,pProj))
                        {
                            MsgBoxLib.ShowInformationOk("操作成功！");
                            //将父类加入List，表示需要从数据库中更新子类数据
                            if (pProj != null) _projectsNeedRefresh.AddFirst(pProj.Code);
                        }
                        else
                        {
                            MsgBoxLib.ShowStop("操作失败");
                        }
                    }

                    goto default;

                case "Delete":
                    if (SelectedNode?.Tag is Process proj)
                    {
                        if (_bll.DeleteProcess(proj, pProj))
                        {
                            MsgBoxLib.ShowInformationOk("操作成功");
                            //将父类加入List，表示需要从数据库中更新子类数据
                            if (pProj != null) _projectsNeedRefresh.AddFirst(pProj.Code);
                        }
                        else
                        {
                            MsgBoxLib.ShowStop("操作失败");
                        }
                    }
                    else
                    {
                        MsgBoxLib.ShowWarning("请先选择要删除的项目");

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
            var node = _bll.FindNode(uTree, proj);
            if (node == null)
            {
                MsgBoxLib.ShowWarning("未找到该项目结构");
            }
            else
            {
                node.Override.NodeAppearance.BackColor = Color.DarkTurquoise;
                _nodesWithColor.Enqueue(node);
            }
        }

        #endregion
    }
}