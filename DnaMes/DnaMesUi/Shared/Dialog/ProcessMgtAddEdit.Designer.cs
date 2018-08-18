namespace DnaMesUi.Shared.Dialog
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessMgtAddEdit));
            this.btnCancel = new Infragistics.Win.Misc.UltraButton();
            this.btnOk = new Infragistics.Win.Misc.UltraButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtDescription = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtCode = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblName = new Infragistics.Win.Misc.UltraLabel();
            this.lblCode = new Infragistics.Win.Misc.UltraLabel();
            this.ckIsMain = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.tipForIsValid = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckIsMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipForIsValid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(300, 14);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 28);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(110, 14);
            this.btnOk.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(69, 28);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtDescription);
            this.splitContainer1.Panel1.Controls.Add(this.txtName);
            this.splitContainer1.Panel1.Controls.Add(this.txtCode);
            this.splitContainer1.Panel1.Controls.Add(this.lblName);
            this.splitContainer1.Panel1.Controls.Add(this.lblCode);
            this.splitContainer1.Panel1.Controls.Add(this.ckIsMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.btnOk);
            this.splitContainer1.Size = new System.Drawing.Size(485, 502);
            this.splitContainer1.SplitterDistance = 416;
            this.splitContainer1.TabIndex = 2;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(49, 233);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            appearance1.FontData.ItalicAsString = "True";
            appearance1.ForeColor = System.Drawing.Color.Silver;
            appearance1.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtDescription.NullTextAppearance = appearance1;
            this.txtDescription.Size = new System.Drawing.Size(361, 122);
            this.txtDescription.TabIndex = 8;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(206, 153);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtName.Name = "txtName";
            appearance2.FontData.ItalicAsString = "True";
            appearance2.ForeColor = System.Drawing.Color.Silver;
            appearance2.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtName.NullTextAppearance = appearance2;
            this.txtName.Size = new System.Drawing.Size(134, 21);
            this.txtName.TabIndex = 1;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(206, 114);
            this.txtCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCode.Name = "txtCode";
            appearance3.FontData.ItalicAsString = "True";
            appearance3.ForeColor = System.Drawing.Color.Silver;
            appearance3.ForeColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCode.NullTextAppearance = appearance3;
            this.txtCode.Size = new System.Drawing.Size(134, 21);
            this.txtCode.TabIndex = 0;
            this.txtCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtCode_Validating);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(138, 154);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(54, 16);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "工艺名称";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(138, 116);
            this.lblCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(54, 16);
            this.lblCode.TabIndex = 6;
            this.lblCode.Text = "工艺编号";
            // 
            // ckIsMain
            // 
            this.ckIsMain.AutoSize = true;
            this.ckIsMain.Location = new System.Drawing.Point(138, 210);
            this.ckIsMain.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ckIsMain.Name = "ckIsMain";
            this.ckIsMain.Size = new System.Drawing.Size(71, 19);
            this.ckIsMain.TabIndex = 4;
            this.ckIsMain.Text = "有效工艺";
            // 
            // tipForIsValid
            // 
            this.tipForIsValid.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.tipForIsValid.ContainerControl = this;
            this.tipForIsValid.Icon = ((System.Drawing.Icon)(resources.GetObject("tipForIsValid.Icon")));
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ProcessMgtAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 502);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProcessMgtAddEdit";
            this.Text = "ProcessMgtAddEdit";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckIsMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipForIsValid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton btnCancel;
        private Infragistics.Win.Misc.UltraButton btnOk;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtName;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtCode;
        private Infragistics.Win.Misc.UltraLabel lblName;
        private Infragistics.Win.Misc.UltraLabel lblCode;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor ckIsMain;
        private System.Windows.Forms.ErrorProvider tipForIsValid;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtDescription;
    }
}