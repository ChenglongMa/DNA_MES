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
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Logout");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Exit");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Logout");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Exit");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this._MainForm_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.toolBarManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
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
            // _MainForm_Toolbars_Dock_Area_Left
            // 
            this._MainForm_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MainForm_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._MainForm_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._MainForm_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MainForm_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 44);
            this._MainForm_Toolbars_Dock_Area_Left.Margin = new System.Windows.Forms.Padding(2);
            this._MainForm_Toolbars_Dock_Area_Left.Name = "_MainForm_Toolbars_Dock_Area_Left";
            this._MainForm_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 356);
            this._MainForm_Toolbars_Dock_Area_Left.ToolbarsManager = this.toolBarManager;
            // 
            // toolBarManager
            // 
            this.toolBarManager.DesignerFlags = 1;
            this.toolBarManager.DockWithinContainer = this;
            this.toolBarManager.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.toolBarManager.FormDisplayStyle = Infragistics.Win.UltraWinToolbars.FormDisplayStyle.Standard;
            this.toolBarManager.LockToolbars = true;
            this.toolBarManager.MenuSettings.ShowToolTips = Infragistics.Win.DefaultableBoolean.True;
            this.toolBarManager.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.toolBarManager.ShowFullMenusDelay = 500;
            this.toolBarManager.ShowShortcutsInToolTips = true;
            this.toolBarManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2007;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.FloatingSize = new System.Drawing.Size(142, 27);
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2});
            ultraToolbar1.Settings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockRight = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowDockTop = Infragistics.Win.DefaultableBoolean.True;
            ultraToolbar1.Settings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Settings.ToolDisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            ultraToolbar1.Settings.UseLargeImages = Infragistics.Win.DefaultableBoolean.True;
            ultraToolbar1.Text = "工具栏";
            this.toolBarManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            this.toolBarManager.ToolbarSettings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
            this.toolBarManager.ToolbarSettings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.False;
            this.toolBarManager.ToolbarSettings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.False;
            this.toolBarManager.ToolbarSettings.AllowDockRight = Infragistics.Win.DefaultableBoolean.False;
            this.toolBarManager.ToolbarSettings.AllowDockTop = Infragistics.Win.DefaultableBoolean.True;
            this.toolBarManager.ToolbarSettings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            this.toolBarManager.ToolbarSettings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            this.toolBarManager.ToolbarSettings.ShowToolTips = Infragistics.Win.DefaultableBoolean.True;
            appearance1.Image = global::DnaMesUi.Properties.Resources.登陆32;
            buttonTool3.SharedPropsInternal.AppearancesLarge.Appearance = appearance1;
            buttonTool3.SharedPropsInternal.Caption = "注销";
            appearance2.Image = global::DnaMesUi.Properties.Resources.退出32;
            buttonTool4.SharedPropsInternal.AppearancesLarge.Appearance = appearance2;
            buttonTool4.SharedPropsInternal.Caption = "退出";
            this.toolBarManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool3,
            buttonTool4});
            this.toolBarManager.ToolTipDisplayStyle = Infragistics.Win.UltraWinToolbars.ToolTipDisplayStyle.Standard;
            this.toolBarManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.toolBarManager_ToolClick);
            // 
            // _MainForm_Toolbars_Dock_Area_Right
            // 
            this._MainForm_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MainForm_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._MainForm_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._MainForm_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MainForm_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(632, 44);
            this._MainForm_Toolbars_Dock_Area_Right.Margin = new System.Windows.Forms.Padding(2);
            this._MainForm_Toolbars_Dock_Area_Right.Name = "_MainForm_Toolbars_Dock_Area_Right";
            this._MainForm_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 356);
            this._MainForm_Toolbars_Dock_Area_Right.ToolbarsManager = this.toolBarManager;
            // 
            // _MainForm_Toolbars_Dock_Area_Top
            // 
            this._MainForm_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MainForm_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._MainForm_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._MainForm_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MainForm_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._MainForm_Toolbars_Dock_Area_Top.Margin = new System.Windows.Forms.Padding(2);
            this._MainForm_Toolbars_Dock_Area_Top.Name = "_MainForm_Toolbars_Dock_Area_Top";
            this._MainForm_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(632, 44);
            this._MainForm_Toolbars_Dock_Area_Top.ToolbarsManager = this.toolBarManager;
            // 
            // _MainForm_Toolbars_Dock_Area_Bottom
            // 
            this._MainForm_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MainForm_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._MainForm_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._MainForm_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MainForm_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 400);
            this._MainForm_Toolbars_Dock_Area_Bottom.Margin = new System.Windows.Forms.Padding(2);
            this._MainForm_Toolbars_Dock_Area_Bottom.Name = "_MainForm_Toolbars_Dock_Area_Bottom";
            this._MainForm_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(632, 0);
            this._MainForm_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.toolBarManager;
            // 
            // tabbedMdiManager
            // 
            this.tabbedMdiManager.MdiParent = this;
            this.tabbedMdiManager.TabGroupSettings.CloseButtonLocation = Infragistics.Win.UltraWinTabs.TabCloseButtonLocation.Tab;
            this.tabbedMdiManager.TabSettings.CloseButtonVisibility = Infragistics.Win.UltraWinTabs.TabCloseButtonVisibility.WhenSelectedOrHotTracked;
            this.tabbedMdiManager.ViewStyle = Infragistics.Win.UltraWinTabbedMdi.ViewStyle.Office2007;
            this.tabbedMdiManager.InitializeContextMenu += new Infragistics.Win.UltraWinTabbedMdi.MdiTabContextMenuEventHandler(this.tabbedMdiManager_InitializeContextMenu);
            this.tabbedMdiManager.TabClosing += new Infragistics.Win.UltraWinTabbedMdi.CancelableMdiTabEventHandler(this.tabbedMdiManager_TabClosing);
            this.tabbedMdiManager.TabDisplayed += new Infragistics.Win.UltraWinTabbedMdi.MdiTabEventHandler(this.tabbedMdiManager_TabDisplayed);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 400);
            this.ultraStatusBar1.Margin = new System.Windows.Forms.Padding(2);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(632, 18);
            this.ultraStatusBar1.TabIndex = 5;
            this.ultraStatusBar1.Text = "ultraStatusBar1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 418);
            this.Controls.Add(this._MainForm_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._MainForm_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._MainForm_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this._MainForm_Toolbars_Dock_Area_Top);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ultraStatusBar1.SetStatusBarText(this, "就绪");
            this.Text = "DNA 制造管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
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



