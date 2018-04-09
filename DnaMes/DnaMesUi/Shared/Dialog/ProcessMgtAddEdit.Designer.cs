﻿namespace DnaMesUi.Shared.Dialog
{
    partial class ProcessMgtAddEdit
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessMgtAddEdit));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.btnCancel = new Infragistics.Win.Misc.UltraButton();
            this.btnOk = new Infragistics.Win.Misc.UltraButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dteEndTime = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.dteStartTime = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.txtName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtCode = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblName = new Infragistics.Win.Misc.UltraLabel();
            this.lblCode = new Infragistics.Win.Misc.UltraLabel();
            this.ckIsMain = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.tipForIsMain = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtDescription = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteEndTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteStartTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckIsMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipForIsMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(400, 18);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 35);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(146, 18);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(92, 35);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "确定";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtDescription);
            this.splitContainer1.Panel1.Controls.Add(this.dteEndTime);
            this.splitContainer1.Panel1.Controls.Add(this.dteStartTime);
            this.splitContainer1.Panel1.Controls.Add(this.txtName);
            this.splitContainer1.Panel1.Controls.Add(this.txtCode);
            this.splitContainer1.Panel1.Controls.Add(this.lblName);
            this.splitContainer1.Panel1.Controls.Add(this.lblCode);
            this.splitContainer1.Panel1.Controls.Add(this.ckIsMain);
            this.splitContainer1.Panel1.Controls.Add(this.ultraLabel4);
            this.splitContainer1.Panel1.Controls.Add(this.ultraLabel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.btnOk);
            this.splitContainer1.Size = new System.Drawing.Size(647, 627);
            this.splitContainer1.SplitterDistance = 541;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 2;
            // 
            // dteEndTime
            // 
            this.dteEndTime.Location = new System.Drawing.Point(274, 287);
            this.dteEndTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dteEndTime.MaskInput = "{date} {time}";
            this.dteEndTime.Name = "dteEndTime";
            this.dteEndTime.Size = new System.Drawing.Size(180, 24);
            this.dteEndTime.TabIndex = 3;
            // 
            // dteStartTime
            // 
            this.dteStartTime.Location = new System.Drawing.Point(274, 239);
            this.dteStartTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dteStartTime.MaskInput = "{date} {time}";
            this.dteStartTime.Name = "dteStartTime";
            this.dteStartTime.Size = new System.Drawing.Size(180, 24);
            this.dteStartTime.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(274, 191);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            appearance2.FontData.ItalicAsString = "True";
            appearance2.ForeColor = System.Drawing.Color.Silver;
            appearance2.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtName.NullTextAppearance = appearance2;
            this.txtName.Size = new System.Drawing.Size(178, 24);
            this.txtName.TabIndex = 1;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(274, 143);
            this.txtCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCode.Name = "txtCode";
            appearance3.FontData.ItalicAsString = "True";
            appearance3.ForeColor = System.Drawing.Color.Silver;
            appearance3.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCode.NullTextAppearance = appearance3;
            this.txtCode.Size = new System.Drawing.Size(178, 24);
            this.txtCode.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(184, 193);
            this.lblName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(67, 19);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "项目名称";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(184, 145);
            this.lblCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(67, 19);
            this.lblCode.TabIndex = 6;
            this.lblCode.Text = "项目编号";
            // 
            // ckIsMain
            // 
            this.ckIsMain.AutoSize = true;
            this.ckIsMain.Location = new System.Drawing.Point(184, 332);
            this.ckIsMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckIsMain.Name = "ckIsMain";
            this.ckIsMain.Size = new System.Drawing.Size(69, 22);
            this.ckIsMain.TabIndex = 4;
            this.ckIsMain.Text = "主项目";
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.AutoSize = true;
            this.ultraLabel4.Location = new System.Drawing.Point(184, 287);
            this.ultraLabel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(67, 19);
            this.ultraLabel4.TabIndex = 0;
            this.ultraLabel4.Text = "结束时间";
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.AutoSize = true;
            this.ultraLabel3.Location = new System.Drawing.Point(184, 239);
            this.ultraLabel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(67, 19);
            this.ultraLabel3.TabIndex = 0;
            this.ultraLabel3.Text = "开始时间";
            // 
            // tipForIsMain
            // 
            this.tipForIsMain.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.tipForIsMain.ContainerControl = this;
            this.tipForIsMain.Icon = ((System.Drawing.Icon)(resources.GetObject("tipForIsMain.Icon")));
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(65, 361);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            appearance1.FontData.ItalicAsString = "True";
            appearance1.ForeColor = System.Drawing.Color.Silver;
            appearance1.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtDescription.NullTextAppearance = appearance1;
            this.txtDescription.Size = new System.Drawing.Size(481, 152);
            this.txtDescription.TabIndex = 8;
            // 
            // ProcessMgtAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 627);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ProcessMgtAddEdit";
            this.Text = "ProcessMgtAddEdit";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dteEndTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteStartTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckIsMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipForIsMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton btnCancel;
        private Infragistics.Win.Misc.UltraButton btnOk;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dteEndTime;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor dteStartTime;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtName;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtCode;
        private Infragistics.Win.Misc.UltraLabel lblName;
        private Infragistics.Win.Misc.UltraLabel lblCode;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor ckIsMain;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private System.Windows.Forms.ErrorProvider tipForIsMain;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtDescription;
    }
}