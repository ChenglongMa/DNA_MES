namespace DnaMesServer
{
    partial class DbConfigForm
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
            this.TabControlMES = new System.Windows.Forms.TabControl();
            this.pageMES = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSaveMes = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMESDbName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMESServer = new System.Windows.Forms.TextBox();
            this.cmbMES = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMESPswd = new System.Windows.Forms.TextBox();
            this.btnTestMes = new System.Windows.Forms.Button();
            this.txtMESUser = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMESPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TabControlMES.SuspendLayout();
            this.pageMES.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControlMES
            // 
            this.TabControlMES.Controls.Add(this.pageMES);
            this.TabControlMES.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlMES.Location = new System.Drawing.Point(0, 0);
            this.TabControlMES.Name = "TabControlMES";
            this.TabControlMES.SelectedIndex = 0;
            this.TabControlMES.Size = new System.Drawing.Size(386, 423);
            this.TabControlMES.TabIndex = 1;
            // 
            // pageMES
            // 
            this.pageMES.Controls.Add(this.groupBox2);
            this.pageMES.Location = new System.Drawing.Point(4, 22);
            this.pageMES.Name = "pageMES";
            this.pageMES.Size = new System.Drawing.Size(378, 397);
            this.pageMES.TabIndex = 5;
            this.pageMES.Text = "MES数据库配置";
            this.pageMES.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSaveMes);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtMESPort);
            this.groupBox2.Controls.Add(this.txtMESDbName);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtMESServer);
            this.groupBox2.Controls.Add(this.cmbMES);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtMESPswd);
            this.groupBox2.Controls.Add(this.btnTestMes);
            this.groupBox2.Controls.Add(this.txtMESUser);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(378, 241);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "设置";
            // 
            // btnSaveMes
            // 
            this.btnSaveMes.Location = new System.Drawing.Point(280, 168);
            this.btnSaveMes.Name = "btnSaveMes";
            this.btnSaveMes.Size = new System.Drawing.Size(75, 23);
            this.btnSaveMes.TabIndex = 25;
            this.btnSaveMes.Text = "保存";
            this.btnSaveMes.UseVisualStyleBackColor = true;
            this.btnSaveMes.Click += new System.EventHandler(this.btnSaveMes_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 23;
            this.label8.Text = "数据库名称";
            // 
            // txtMESDbName
            // 
            this.txtMESDbName.Location = new System.Drawing.Point(106, 137);
            this.txtMESDbName.Name = "txtMESDbName";
            this.txtMESDbName.Size = new System.Drawing.Size(149, 21);
            this.txtMESDbName.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "服务器名称";
            // 
            // txtMESServer
            // 
            this.txtMESServer.Location = new System.Drawing.Point(106, 71);
            this.txtMESServer.Name = "txtMESServer";
            this.txtMESServer.Size = new System.Drawing.Size(149, 21);
            this.txtMESServer.TabIndex = 21;
            // 
            // cmbMES
            // 
            this.cmbMES.FormattingEnabled = true;
            this.cmbMES.Items.AddRange(new object[] {
            "SQLSERVER",
            "ORACLE"});
            this.cmbMES.Location = new System.Drawing.Point(106, 36);
            this.cmbMES.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMES.Name = "cmbMES";
            this.cmbMES.Size = new System.Drawing.Size(149, 20);
            this.cmbMES.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "数据库类型";
            // 
            // txtMESPswd
            // 
            this.txtMESPswd.Location = new System.Drawing.Point(106, 204);
            this.txtMESPswd.Name = "txtMESPswd";
            this.txtMESPswd.Size = new System.Drawing.Size(149, 21);
            this.txtMESPswd.TabIndex = 7;
            this.txtMESPswd.UseSystemPasswordChar = true;
            // 
            // btnTestMes
            // 
            this.btnTestMes.Location = new System.Drawing.Point(280, 106);
            this.btnTestMes.Name = "btnTestMes";
            this.btnTestMes.Size = new System.Drawing.Size(75, 23);
            this.btnTestMes.TabIndex = 1;
            this.btnTestMes.Text = "测试";
            this.btnTestMes.UseVisualStyleBackColor = true;
            this.btnTestMes.Click += new System.EventHandler(this.btnTestMes_Click);
            // 
            // txtMESUser
            // 
            this.txtMESUser.Location = new System.Drawing.Point(106, 171);
            this.txtMESUser.Name = "txtMESUser";
            this.txtMESUser.Size = new System.Drawing.Size(149, 21);
            this.txtMESUser.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 174);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 2;
            this.label11.Text = "用 户 名";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 207);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 3;
            this.label12.Text = "密    码";
            // 
            // txtMESPort
            // 
            this.txtMESPort.Location = new System.Drawing.Point(106, 106);
            this.txtMESPort.Name = "txtMESPort";
            this.txtMESPort.Size = new System.Drawing.Size(149, 21);
            this.txtMESPort.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 23;
            this.label1.Text = "端    口";
            // 
            // DbConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 423);
            this.Controls.Add(this.TabControlMES);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DbConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "数据库配置";
            this.TabControlMES.ResumeLayout(false);
            this.pageMES.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControlMES;
        private System.Windows.Forms.TabPage pageMES;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSaveMes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMESDbName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMESServer;
        private System.Windows.Forms.ComboBox cmbMES;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMESPswd;
        private System.Windows.Forms.Button btnTestMes;
        private System.Windows.Forms.TextBox txtMESUser;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMESPort;
    }
}

