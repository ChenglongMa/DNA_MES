namespace DnaMesServer
{
    partial class ServorInitilizeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServorInitilizeForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDBInitial = new System.Windows.Forms.Button();
            this.rbnDBInitial = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBackupRestore = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.sfDialog = new System.Windows.Forms.SaveFileDialog();
            this.ofDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.btnUpdateDataBase = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDBInitial);
            this.groupBox1.Controls.Add(this.rbnDBInitial);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "初始化数据库";
            // 
            // btnDBInitial
            // 
            this.btnDBInitial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDBInitial.Location = new System.Drawing.Point(422, 27);
            this.btnDBInitial.Name = "btnDBInitial";
            this.btnDBInitial.Size = new System.Drawing.Size(75, 23);
            this.btnDBInitial.TabIndex = 1;
            this.btnDBInitial.Text = "确 定";
            this.btnDBInitial.UseVisualStyleBackColor = true;
            this.btnDBInitial.Click += new System.EventHandler(this.btnDBInitial_Click);
            // 
            // rbnDBInitial
            // 
            this.rbnDBInitial.AutoSize = true;
            this.rbnDBInitial.Checked = true;
            this.rbnDBInitial.Location = new System.Drawing.Point(61, 30);
            this.rbnDBInitial.Name = "rbnDBInitial";
            this.rbnDBInitial.Size = new System.Drawing.Size(95, 16);
            this.rbnDBInitial.TabIndex = 0;
            this.rbnDBInitial.TabStop = true;
            this.rbnDBInitial.Text = "初始化数据库";
            this.rbnDBInitial.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.btnUpdateDataBase);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(551, 81);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "升级数据库";
            // 
            // btnBackupRestore
            // 
            this.btnBackupRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackupRestore.Location = new System.Drawing.Point(422, 30);
            this.btnBackupRestore.Name = "btnBackupRestore";
            this.btnBackupRestore.Size = new System.Drawing.Size(75, 23);
            this.btnBackupRestore.TabIndex = 3;
            this.btnBackupRestore.Text = "确 定";
            this.btnBackupRestore.UseVisualStyleBackColor = true;
            this.btnBackupRestore.Click += new System.EventHandler(this.btnBackupRestore_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(61, 30);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(83, 16);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "升级数据库";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(424, 260);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "退 出";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnBackupRestore);
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 155);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(551, 81);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "导入DNC设备列表";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(61, 35);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(113, 16);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "导入DNC设备列表";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // btnUpdateDataBase
            // 
            this.btnUpdateDataBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateDataBase.Location = new System.Drawing.Point(422, 29);
            this.btnUpdateDataBase.Name = "btnUpdateDataBase";
            this.btnUpdateDataBase.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateDataBase.TabIndex = 1;
            this.btnUpdateDataBase.Text = "确 定";
            this.btnUpdateDataBase.UseVisualStyleBackColor = true;
            this.btnUpdateDataBase.Click += new System.EventHandler(this.btnUpdateDataBase_Click);
            // 
            // ServorInitilizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(551, 295);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServorInitilizeForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据维护工具";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDBInitial;
        private System.Windows.Forms.RadioButton rbnDBInitial;
        private System.Windows.Forms.Button btnBackupRestore;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.SaveFileDialog sfDialog;
        private System.Windows.Forms.OpenFileDialog ofDialog;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnUpdateDataBase;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}