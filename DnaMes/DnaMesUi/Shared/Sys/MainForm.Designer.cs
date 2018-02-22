namespace DnaMesUi.Shared.Sys
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("SysToolBar");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("MainMenuBar");
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolBarManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._MainForm_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._MainForm_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._MainForm_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._MainForm_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.tabbedMdiManager = new Infragistics.Win.UltraWinTabbedMdi.UltraTabbedMdiManager(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.toolBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedMdiManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraStatusBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBarManager
            // 
            this.toolBarManager.DesignerFlags = 1;
            this.toolBarManager.DockWithinContainer = this;
            this.toolBarManager.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.toolBarManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.WindowsVista;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 1;
            ultraToolbar1.FloatingSize = new System.Drawing.Size(142, 27);
            ultraToolbar1.Text = "SysToolBar";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 0;
            ultraToolbar2.IsMainMenuBar = true;
            ultraToolbar2.Text = "MainMenuBar";
            this.toolBarManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2});
            this.toolBarManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.toolBarManager_ToolClick);
            // 
            // _MainForm_Toolbars_Dock_Area_Left
            // 
            this._MainForm_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MainForm_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(230)))), ((int)(((byte)(246)))));
            this._MainForm_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._MainForm_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MainForm_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 91);
            this._MainForm_Toolbars_Dock_Area_Left.Name = "_MainForm_Toolbars_Dock_Area_Left";
            this._MainForm_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 409);
            this._MainForm_Toolbars_Dock_Area_Left.ToolbarsManager = this.toolBarManager;
            // 
            // _MainForm_Toolbars_Dock_Area_Right
            // 
            this._MainForm_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MainForm_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(230)))), ((int)(((byte)(246)))));
            this._MainForm_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._MainForm_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MainForm_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(843, 91);
            this._MainForm_Toolbars_Dock_Area_Right.Name = "_MainForm_Toolbars_Dock_Area_Right";
            this._MainForm_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 409);
            this._MainForm_Toolbars_Dock_Area_Right.ToolbarsManager = this.toolBarManager;
            // 
            // _MainForm_Toolbars_Dock_Area_Top
            // 
            this._MainForm_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MainForm_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(230)))), ((int)(((byte)(246)))));
            this._MainForm_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._MainForm_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MainForm_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._MainForm_Toolbars_Dock_Area_Top.Name = "_MainForm_Toolbars_Dock_Area_Top";
            this._MainForm_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(843, 91);
            this._MainForm_Toolbars_Dock_Area_Top.ToolbarsManager = this.toolBarManager;
            // 
            // _MainForm_Toolbars_Dock_Area_Bottom
            // 
            this._MainForm_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MainForm_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(230)))), ((int)(((byte)(246)))));
            this._MainForm_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._MainForm_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MainForm_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 500);
            this._MainForm_Toolbars_Dock_Area_Bottom.Name = "_MainForm_Toolbars_Dock_Area_Bottom";
            this._MainForm_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(843, 0);
            this._MainForm_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.toolBarManager;
            // 
            // tabbedMdiManager
            // 
            this.tabbedMdiManager.MdiParent = this;
            this.tabbedMdiManager.InitializeContextMenu += new Infragistics.Win.UltraWinTabbedMdi.MdiTabContextMenuEventHandler(this.tabbedMdiManager_InitializeContextMenu);
            this.tabbedMdiManager.InitializeTab += new Infragistics.Win.UltraWinTabbedMdi.MdiTabEventHandler(this.tabbedMdiManager_InitializeTab);
            this.tabbedMdiManager.TabClosed += new Infragistics.Win.UltraWinTabbedMdi.MdiTabEventHandler(this.tabbedMdiManager_TabClosed);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 500);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(843, 23);
            this.ultraStatusBar1.TabIndex = 5;
            this.ultraStatusBar1.Text = "ultraStatusBar1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 523);
            this.Controls.Add(this._MainForm_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._MainForm_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._MainForm_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this._MainForm_Toolbars_Dock_Area_Top);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.toolBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedMdiManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraStatusBar1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.ToolTip toolTip;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager toolBarManager;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MainForm_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MainForm_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MainForm_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MainForm_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinTabbedMdi.UltraTabbedMdiManager tabbedMdiManager;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
    }
}



