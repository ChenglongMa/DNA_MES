namespace DnaMesUi.BasicInfo
{
    partial class ProcessManagementForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("SysToolBar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool1");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool1");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this.ProcessManagementForm_Fill_Panel = new System.Windows.Forms.Panel();
            this._ProcessManagementForm_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ProcessManagementForm_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ProcessManagementForm_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ProcessManagementForm_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraToolbarsManager1
            // 
            this.ultraToolbarsManager1.DesignerFlags = 1;
            this.ultraToolbarsManager1.DockWithinContainer = this;
            this.ultraToolbarsManager1.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.ultraToolbarsManager1.FormDisplayStyle = Infragistics.Win.UltraWinToolbars.FormDisplayStyle.Standard;
            this.ultraToolbarsManager1.LockToolbars = true;
            this.ultraToolbarsManager1.MenuSettings.ShowToolTips = Infragistics.Win.DefaultableBoolean.True;
            this.ultraToolbarsManager1.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.ultraToolbarsManager1.ShowFullMenusDelay = 500;
            this.ultraToolbarsManager1.ShowShortcutsInToolTips = true;
            this.ultraToolbarsManager1.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2007;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.FloatingSize = new System.Drawing.Size(142, 27);
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool5});
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
            this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            this.ultraToolbarsManager1.ToolbarSettings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
            this.ultraToolbarsManager1.ToolbarSettings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.False;
            this.ultraToolbarsManager1.ToolbarSettings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.False;
            this.ultraToolbarsManager1.ToolbarSettings.AllowDockRight = Infragistics.Win.DefaultableBoolean.False;
            this.ultraToolbarsManager1.ToolbarSettings.AllowDockTop = Infragistics.Win.DefaultableBoolean.True;
            this.ultraToolbarsManager1.ToolbarSettings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            this.ultraToolbarsManager1.ToolbarSettings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            this.ultraToolbarsManager1.ToolbarSettings.ShowToolTips = Infragistics.Win.DefaultableBoolean.True;
            appearance1.Image = global::DnaMesUi.Properties.Resources.增加用户32;
            buttonTool6.SharedPropsInternal.AppearancesLarge.Appearance = appearance1;
            appearance2.Image = global::DnaMesUi.Properties.Resources.增加用户16;
            buttonTool6.SharedPropsInternal.AppearancesSmall.Appearance = appearance2;
            buttonTool6.SharedPropsInternal.Caption = "ButtonTool1";
            this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool6});
            this.ultraToolbarsManager1.ToolTipDisplayStyle = Infragistics.Win.UltraWinToolbars.ToolTipDisplayStyle.Standard;
            // 
            // ProcessManagementForm_Fill_Panel
            // 
            this.ProcessManagementForm_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.ProcessManagementForm_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProcessManagementForm_Fill_Panel.Location = new System.Drawing.Point(0, 44);
            this.ProcessManagementForm_Fill_Panel.Name = "ProcessManagementForm_Fill_Panel";
            this.ProcessManagementForm_Fill_Panel.Size = new System.Drawing.Size(498, 325);
            this.ProcessManagementForm_Fill_Panel.TabIndex = 0;
            // 
            // _ProcessManagementForm_Toolbars_Dock_Area_Left
            // 
            this._ProcessManagementForm_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ProcessManagementForm_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._ProcessManagementForm_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._ProcessManagementForm_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ProcessManagementForm_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 44);
            this._ProcessManagementForm_Toolbars_Dock_Area_Left.Name = "_ProcessManagementForm_Toolbars_Dock_Area_Left";
            this._ProcessManagementForm_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 325);
            this._ProcessManagementForm_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _ProcessManagementForm_Toolbars_Dock_Area_Right
            // 
            this._ProcessManagementForm_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ProcessManagementForm_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._ProcessManagementForm_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._ProcessManagementForm_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ProcessManagementForm_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(498, 44);
            this._ProcessManagementForm_Toolbars_Dock_Area_Right.Name = "_ProcessManagementForm_Toolbars_Dock_Area_Right";
            this._ProcessManagementForm_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 325);
            this._ProcessManagementForm_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _ProcessManagementForm_Toolbars_Dock_Area_Top
            // 
            this._ProcessManagementForm_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ProcessManagementForm_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._ProcessManagementForm_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._ProcessManagementForm_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ProcessManagementForm_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._ProcessManagementForm_Toolbars_Dock_Area_Top.Name = "_ProcessManagementForm_Toolbars_Dock_Area_Top";
            this._ProcessManagementForm_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(498, 44);
            this._ProcessManagementForm_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _ProcessManagementForm_Toolbars_Dock_Area_Bottom
            // 
            this._ProcessManagementForm_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ProcessManagementForm_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this._ProcessManagementForm_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._ProcessManagementForm_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ProcessManagementForm_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 369);
            this._ProcessManagementForm_Toolbars_Dock_Area_Bottom.Name = "_ProcessManagementForm_Toolbars_Dock_Area_Bottom";
            this._ProcessManagementForm_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(498, 0);
            this._ProcessManagementForm_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // ProcessManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 369);
            this.Controls.Add(this.ProcessManagementForm_Fill_Panel);
            this.Controls.Add(this._ProcessManagementForm_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._ProcessManagementForm_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._ProcessManagementForm_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this._ProcessManagementForm_Toolbars_Dock_Area_Top);
            this.Name = "ProcessManagementForm";
            this.Text = "ProcessManagementForm";
            ((System.ComponentModel.ISupportInitialize)(this.ultraToolbarsManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
        private System.Windows.Forms.Panel ProcessManagementForm_Fill_Panel;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ProcessManagementForm_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ProcessManagementForm_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ProcessManagementForm_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ProcessManagementForm_Toolbars_Dock_Area_Top;
    }
}