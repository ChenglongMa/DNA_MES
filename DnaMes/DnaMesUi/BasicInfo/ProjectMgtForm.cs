using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DnaLib.Control;
using DnaLib.Helper;
using DnaMesModel.Link.BasicInfo;
using DnaMesModel.Model.BasicInfo;
using DnaMesModel.Shared;
using DnaMesUi.Shared.Dialog;
using DnaMesUiBll.BasicInfo;
using DnaMesUiBll.Shared;
using DnaMesUiConfig.Helper;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinTree;

namespace DnaMesUi.BasicInfo
{
    public partial class ProjectMgtForm : BaseForm
    {
        private readonly ProjectMgtBll _bll = new ProjectMgtBll();

        private readonly UltraTreeDrawFilterHelper _drawFilter = new UltraTreeDrawFilterHelper();

        public ProjectMgtForm()
        {
            InitializeComponent();
            dteStartTime.Enabled = ckStartTime.Checked;
            dteEndTime.Enabled = ckEndTime.Checked;
            _bll.BuildTree(ref uTree, imageList1.Images, _bll.ParentsToBeUpdated, p => p.IsMain);
            FieldName = "BasicInfo\\Project.xml";
            GridBindingBll<Project>.BindingStyleAndData(ug1, null, FieldName);
            uTree.DrawFilter = _drawFilter;
            _drawFilter.Invalidate += DrawFilterInvalidate;
            _drawFilter.QueryStateAllowedForNode += DrawFilterQueryStateAllowedForNode;
            SetToolsEnable(true, "Add");
        }


        #region 其他

        private void RefreshData()
        {
            _bll.BuildTree(ref uTree, imageList1.Images, _bll.ParentsToBeUpdated, p => p.IsMain);
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
            if (projs.IsNullOrEmpty())
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

        private void uTree_AfterExpand(object sender, NodeEventArgs e)
        {
            _bll.AfterExpand(e.TreeNode, imageList1.Images);
        }

        private void uTree_AfterSelect(object sender, SelectEventArgs e)
        {
            ResetNodeBackColor();
            SetToolsEnable(SelectedNode?.Tag is Project, "Delete", "Edit");

            foreach (var node in uTree.SelectedNodes)
            {
                node.Expanded = true;
            }

            var dataSource = new List<Project> {SelectedNode?.Tag as Project};
            dataSource.AddRange(_bll.GetChildren(uTree.SelectedNodes));
            GridBindingBll<Project>.BindingData(ug1, dataSource, FieldName);
        }

        private void uTree_SelectionDragStart(object sender, EventArgs e)
        {
            uTree.DoDragDrop(uTree.SelectedNodes, DragDropEffects.Move);
        }

        private void DrawFilterQueryStateAllowedForNode(object sender,
            UltraTreeDrawFilterHelper.QueryStateAllowedForNodeEventArgs e)
        {
            e.StatesAllowed = DropLinePositionEnum.OnNode;
        }

        private void DrawFilterInvalidate(object sender, EventArgs e)
        {
            uTree.Invalidate();
        }

        private void uTree_DragDrop(object sender, DragEventArgs e)
        {
            UltraTreeNode aNode;

            int i;
            var dropNode = _drawFilter.DropHightLightNode;

            var selectedNodes = (SelectedNodesCollection) e.Data.GetData(typeof(SelectedNodesCollection));
            selectedNodes = selectedNodes.Clone() as SelectedNodesCollection;
            if (selectedNodes == null)
            {
                return;
            }

            selectedNodes.SortByPosition();
            switch (_drawFilter.DropLinePosition)
            {
                case DropLinePositionEnum.OnNode:
                {
                    var children = new List<Project>();
                    for (i = 0; i <= selectedNodes.Count - 1; i++)
                    {
                        aNode = selectedNodes[i];
                        aNode.Reposition(dropNode.Nodes);
                        if (aNode.Tag is Project proj)
                        {
                            children.Add(proj);
                        }
                    }

                    var pPorj = dropNode?.Tag as Project;
                    _bll.ChangeParent(children, pPorj);
                    break;
                }
                case DropLinePositionEnum.BelowNode:
                {
                    for (i = 0; i <= selectedNodes.Count - 1; i++)
                    {
                        aNode = selectedNodes[i];
                        aNode.Reposition(dropNode, NodePosition.Next);
                        dropNode = aNode;
                    }

                    break;
                }
                case DropLinePositionEnum.AboveNode:
                {
                    for (i = 0; i <= selectedNodes.Count - 1; i++)
                    {
                        aNode = selectedNodes[i];
                        aNode.Reposition(dropNode, NodePosition.Previous);
                    }

                    break;
                }
            }

            _drawFilter.ClearDropHighlight();
        }

        private void uTree_DragLeave(object sender, EventArgs e)
        {
            _drawFilter.ClearDropHighlight();
        }

        private void uTree_DragOver(object sender, DragEventArgs e)
        {
            var pointInTree = uTree.PointToClient(new Point(e.X, e.Y));
            var aNode = uTree.GetNodeFromPoint(pointInTree);
            if (aNode == null)
            {
                e.Effect = DragDropEffects.None;
                _drawFilter.ClearDropHighlight();
                return;
            }

            if (IsAnyParentSelected(aNode))
            {
                e.Effect = DragDropEffects.None;
                _drawFilter.ClearDropHighlight();
                return;
            }

            _drawFilter.SetDropHighlightNode(aNode, pointInTree);
            e.Effect = DragDropEffects.Move;
        }

        private static bool IsAnyParentSelected(UltraTreeNode node)
        {
            var returnValue = false;

            var parentNode = node.Parent;
            while (parentNode != null)
            {
                if (parentNode.Selected)
                {
                    returnValue = true;
                    break;
                }

                parentNode = parentNode.Parent;
            }

            return returnValue;
        }

        #endregion

        #region 工具栏区

        private void toolBarManager_ToolClick(object sender, ToolClickEventArgs e)
        {
            var pProj = SelectedNode?.Parent?.Tag as Project;
            ProjectMgtAddEdit form;
            switch (e.Tool.Key)
            {
                case "Refresh":
                default:
                    RefreshData();
                    break;
                case "Add":
                    var thisProj = SelectedNode?.Tag as Project;
                    form = new ProjectMgtAddEdit(thisProj == null);
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        if (_bll.AddProject(form.TransModel, thisProj))
                        {
                            MsgBoxLib.ShowInformationOk("操作成功！");
                            //将父类加入List，表示需要从数据库中更新子类数据
                            if (thisProj?.Code != null) _bll.ParentsToBeUpdated.AddFirst(thisProj.Code);
                        }
                        else
                        {
                            MsgBoxLib.ShowStop("操作失败");
                        }
                    }

                    goto default;

                case "Edit":
                    form = new ProjectMgtAddEdit("编辑项目", SelectedNode?.Tag as Project);
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        if (_bll.UpdateModel(form.TransModel, pProj))
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
                    if (SelectedNode?.Tag is Project proj && MsgBoxLib.ShowQuestion("确定要删除该项目吗？"))
                    {
                        if (_bll.DeleteModel<Project, ProjectProject>(proj, pProj))
                        {
                            MsgBoxLib.ShowInformationOk("操作成功");
                            //将父类加入List，表示需要从数据库中更新子类数据
                            if (pProj != null) _bll.ParentsToBeUpdated.AddFirst(pProj.Code);
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
            ResetNodeBackColor();
            if (!(e.Row.ListObject is Project proj)) return;
            var node = _bll.FindNode(uTree, proj);
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
    }
}