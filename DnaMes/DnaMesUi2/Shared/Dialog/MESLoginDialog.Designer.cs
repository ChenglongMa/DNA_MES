﻿namespace DnaMesUi.Shared.Dialog
{
    partial class MESLoginDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MESLoginDialog));
            this.checkBoxStaffnoLogin = new System.Windows.Forms.CheckBox();
            this.lbName = new System.Windows.Forms.Label();
            this.txtBoxUserName = new System.Windows.Forms.TextBox();
            this.txtStaffno = new System.Windows.Forms.TextBox();
            this.pdcLbPswd = new System.Windows.Forms.Label();
            this.txtBoxPassword = new System.Windows.Forms.TextBox();
            this.pdcLabelIP = new System.Windows.Forms.Label();
            this.txtMESServerIP = new System.Windows.Forms.TextBox();
            this.BtnchangeServerIP = new System.Windows.Forms.Button();
            this.btnSaveIP = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lbStaffNo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBoxStaffnoLogin
            // 
            this.checkBoxStaffnoLogin.AutoSize = true;
            this.checkBoxStaffnoLogin.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxStaffnoLogin.Location = new System.Drawing.Point(431, 49);
            this.checkBoxStaffnoLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxStaffnoLogin.Name = "checkBoxStaffnoLogin";
            this.checkBoxStaffnoLogin.Size = new System.Drawing.Size(114, 31);
            this.checkBoxStaffnoLogin.TabIndex = 14;
            this.checkBoxStaffnoLogin.Text = "工号登入";
            this.checkBoxStaffnoLogin.UseVisualStyleBackColor = true;
            this.checkBoxStaffnoLogin.Visible = false;
            this.checkBoxStaffnoLogin.CheckedChanged += new System.EventHandler(this.checkBoxStaffnoLogin_CheckedChanged);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbName.Location = new System.Drawing.Point(49, 46);
            this.lbName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(72, 27);
            this.lbName.TabIndex = 15;
            this.lbName.Text = "用户名";
            // 
            // txtBoxUserName
            // 
            this.txtBoxUserName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBoxUserName.Location = new System.Drawing.Point(161, 46);
            this.txtBoxUserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBoxUserName.Name = "txtBoxUserName";
            this.txtBoxUserName.Size = new System.Drawing.Size(221, 34);
            this.txtBoxUserName.TabIndex = 1;
            // 
            // txtStaffno
            // 
            this.txtStaffno.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStaffno.Location = new System.Drawing.Point(161, 46);
            this.txtStaffno.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStaffno.Name = "txtStaffno";
            this.txtStaffno.Size = new System.Drawing.Size(221, 34);
            this.txtStaffno.TabIndex = 18;
            this.txtStaffno.Visible = false;
            // 
            // pdcLbPswd
            // 
            this.pdcLbPswd.AutoSize = true;
            this.pdcLbPswd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pdcLbPswd.Location = new System.Drawing.Point(55, 126);
            this.pdcLbPswd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pdcLbPswd.Name = "pdcLbPswd";
            this.pdcLbPswd.Size = new System.Drawing.Size(52, 27);
            this.pdcLbPswd.TabIndex = 19;
            this.pdcLbPswd.Text = "密码";
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBoxPassword.Location = new System.Drawing.Point(161, 122);
            this.txtBoxPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.Size = new System.Drawing.Size(221, 34);
            this.txtBoxPassword.TabIndex = 2;
            this.txtBoxPassword.UseSystemPasswordChar = true;
            // 
            // pdcLabelIP
            // 
            this.pdcLabelIP.AutoSize = true;
            this.pdcLabelIP.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pdcLabelIP.Location = new System.Drawing.Point(49, 191);
            this.pdcLabelIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pdcLabelIP.Name = "pdcLabelIP";
            this.pdcLabelIP.Size = new System.Drawing.Size(72, 27);
            this.pdcLabelIP.TabIndex = 21;
            this.pdcLabelIP.Text = "服务器";
            this.pdcLabelIP.Visible = false;
            // 
            // txtMESServerIP
            // 
            this.txtMESServerIP.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMESServerIP.Location = new System.Drawing.Point(161, 188);
            this.txtMESServerIP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMESServerIP.Name = "txtMESServerIP";
            this.txtMESServerIP.Size = new System.Drawing.Size(221, 34);
            this.txtMESServerIP.TabIndex = 4;
            this.txtMESServerIP.Visible = false;
            // 
            // BtnchangeServerIP
            // 
            this.BtnchangeServerIP.Image = ((System.Drawing.Image)(resources.GetObject("BtnchangeServerIP.Image")));
            this.BtnchangeServerIP.Location = new System.Drawing.Point(459, 125);
            this.BtnchangeServerIP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnchangeServerIP.Name = "BtnchangeServerIP";
            this.BtnchangeServerIP.Size = new System.Drawing.Size(44, 36);
            this.BtnchangeServerIP.TabIndex = 3;
            this.BtnchangeServerIP.UseVisualStyleBackColor = true;
            this.BtnchangeServerIP.Click += new System.EventHandler(this.BtnchangeServerIP_Click);
            // 
            // btnSaveIP
            // 
            this.btnSaveIP.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveIP.Image")));
            this.btnSaveIP.Location = new System.Drawing.Point(459, 188);
            this.btnSaveIP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveIP.Name = "btnSaveIP";
            this.btnSaveIP.Size = new System.Drawing.Size(44, 41);
            this.btnSaveIP.TabIndex = 24;
            this.btnSaveIP.UseVisualStyleBackColor = true;
            this.btnSaveIP.Visible = false;
            this.btnSaveIP.Click += new System.EventHandler(this.pdcBtnSaveIP_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.Location = new System.Drawing.Point(116, 255);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(120, 40);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "   登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(356, 255);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 40);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "  退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbStaffNo
            // 
            this.lbStaffNo.AutoSize = true;
            this.lbStaffNo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbStaffNo.Location = new System.Drawing.Point(55, 46);
            this.lbStaffNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbStaffNo.Name = "lbStaffNo";
            this.lbStaffNo.Size = new System.Drawing.Size(52, 27);
            this.lbStaffNo.TabIndex = 17;
            this.lbStaffNo.Text = "工号";
            this.lbStaffNo.Visible = false;
            // 
            // MESLoginDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 306);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnSaveIP);
            this.Controls.Add(this.BtnchangeServerIP);
            this.Controls.Add(this.txtMESServerIP);
            this.Controls.Add(this.pdcLabelIP);
            this.Controls.Add(this.txtBoxPassword);
            this.Controls.Add(this.pdcLbPswd);
            this.Controls.Add(this.txtStaffno);
            this.Controls.Add(this.lbStaffNo);
            this.Controls.Add(this.txtBoxUserName);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.checkBoxStaffnoLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "MESLoginDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MES系统登录";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MESLoginDialog_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxStaffnoLogin;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox txtBoxUserName;
        private System.Windows.Forms.TextBox txtStaffno;
        private System.Windows.Forms.Label pdcLbPswd;
        private System.Windows.Forms.TextBox txtBoxPassword;
        private System.Windows.Forms.Label pdcLabelIP;
        private System.Windows.Forms.TextBox txtMESServerIP;
        private System.Windows.Forms.Button BtnchangeServerIP;
        private System.Windows.Forms.Button btnSaveIP;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lbStaffNo;
    }
}