namespace DnaMesServer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnErpStop = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.dataProcessLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataProcessBar = new System.Windows.Forms.ToolStripProgressBar();
            this.pbDataService = new System.Windows.Forms.PictureBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.calcuBeginTimeDTP = new System.Windows.Forms.DateTimePicker();
            this.btnStart = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.proBar = new System.Windows.Forms.ToolStripProgressBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label3 = new System.Windows.Forms.Label();
            this.btnErpStart = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.exitTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.picErp = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCappStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCappStart = new System.Windows.Forms.Button();
            this.picCapp = new System.Windows.Forms.PictureBox();
            this.miTools = new System.Windows.Forms.ToolStripMenuItem();
            this.miDBSet = new System.Windows.Forms.ToolStripMenuItem();
            this.miInitial = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDataService)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picErp)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCapp)).BeginInit();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnErpStop
            // 
            this.btnErpStop.BackColor = System.Drawing.SystemColors.Control;
            this.btnErpStop.Enabled = false;
            this.btnErpStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnErpStop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnErpStop.Location = new System.Drawing.Point(736, 60);
            this.btnErpStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnErpStop.Name = "btnErpStop";
            this.btnErpStop.Size = new System.Drawing.Size(100, 41);
            this.btnErpStop.TabIndex = 16;
            this.btnErpStop.Text = "停止";
            this.btnErpStop.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.statusStrip2);
            this.groupBox1.Controls.Add(this.pbDataService);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.calcuBeginTimeDTP);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(16, 76);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(872, 206);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据处理服务";
            // 
            // statusStrip2
            // 
            this.statusStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataProcessLabel,
            this.dataProcessBar});
            this.statusStrip2.Location = new System.Drawing.Point(4, 138);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip2.Size = new System.Drawing.Size(801, 26);
            this.statusStrip2.TabIndex = 21;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // dataProcessLabel
            // 
            this.dataProcessLabel.AutoSize = false;
            this.dataProcessLabel.Name = "dataProcessLabel";
            this.dataProcessLabel.Size = new System.Drawing.Size(150, 21);
            this.dataProcessLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataProcessBar
            // 
            this.dataProcessBar.AutoSize = false;
            this.dataProcessBar.Maximum = 1000;
            this.dataProcessBar.Name = "dataProcessBar";
            this.dataProcessBar.Size = new System.Drawing.Size(627, 20);
            // 
            // pbDataService
            // 
            this.pbDataService.Location = new System.Drawing.Point(8, 32);
            this.pbDataService.Margin = new System.Windows.Forms.Padding(4);
            this.pbDataService.Name = "pbDataService";
            this.pbDataService.Size = new System.Drawing.Size(64, 60);
            this.pbDataService.TabIndex = 17;
            this.pbDataService.TabStop = false;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.SystemColors.Control;
            this.btnStop.Enabled = false;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStop.Location = new System.Drawing.Point(736, 32);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 41);
            this.btnStop.TabIndex = 16;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = false;
            // 
            // calcuBeginTimeDTP
            // 
            this.calcuBeginTimeDTP.CalendarForeColor = System.Drawing.SystemColors.Control;
            this.calcuBeginTimeDTP.CalendarMonthBackground = System.Drawing.SystemColors.Control;
            this.calcuBeginTimeDTP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calcuBeginTimeDTP.CustomFormat = "yyyy年MM月dd日 HH:00:00";
            this.calcuBeginTimeDTP.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.calcuBeginTimeDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.calcuBeginTimeDTP.Location = new System.Drawing.Point(565, 86);
            this.calcuBeginTimeDTP.Margin = new System.Windows.Forms.Padding(4);
            this.calcuBeginTimeDTP.Name = "calcuBeginTimeDTP";
            this.calcuBeginTimeDTP.Size = new System.Drawing.Size(277, 29);
            this.calcuBeginTimeDTP.TabIndex = 24;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.Control;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.Location = new System.Drawing.Point(565, 34);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 40);
            this.btnStart.TabIndex = 15;
            this.btnStart.Text = "启动";
            this.btnStart.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(216, 86);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 23);
            this.label4.TabIndex = 23;
            this.label4.Text = "计算开始时间";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(123, 34);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(219, 23);
            this.label7.TabIndex = 18;
            this.label7.Text = "DNA制造过程管理数据服务";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(376, 165);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(469, 23);
            this.label2.TabIndex = 19;
            this.label2.Text = "注意：数据服务用于自动处理数据，启动后定时在后台执行。";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = false;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(150, 23);
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // proBar
            // 
            this.proBar.AutoSize = false;
            this.proBar.Maximum = 1000;
            this.proBar.Name = "proBar";
            this.proBar.Size = new System.Drawing.Size(627, 22);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.proBar});
            this.statusStrip1.Location = new System.Drawing.Point(8, 202);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(801, 28);
            this.statusStrip1.TabIndex = 20;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(123, 149);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 23);
            this.label3.TabIndex = 18;
            this.label3.Text = "CAPP接口数据服务";
            // 
            // btnErpStart
            // 
            this.btnErpStart.BackColor = System.Drawing.SystemColors.Control;
            this.btnErpStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnErpStart.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnErpStart.Location = new System.Drawing.Point(565, 61);
            this.btnErpStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnErpStart.Name = "btnErpStart";
            this.btnErpStart.Size = new System.Drawing.Size(100, 40);
            this.btnErpStart.TabIndex = 15;
            this.btnErpStart.Text = "启动";
            this.btnErpStart.UseVisualStyleBackColor = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "DNA制造过程管理服务端";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTSMI,
            this.exitTSMI});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 52);
            // 
            // openTSMI
            // 
            this.openTSMI.Name = "openTSMI";
            this.openTSMI.Size = new System.Drawing.Size(175, 24);
            this.openTSMI.Text = "打开";
            this.openTSMI.Click += new System.EventHandler(this.openTSMI_Click);
            // 
            // exitTSMI
            // 
            this.exitTSMI.Name = "exitTSMI";
            this.exitTSMI.Size = new System.Drawing.Size(175, 24);
            this.exitTSMI.Text = "退出";
            this.exitTSMI.Click += new System.EventHandler(this.exitTSMI_Click);
            // 
            // picErp
            // 
            this.picErp.Location = new System.Drawing.Point(8, 41);
            this.picErp.Margin = new System.Windows.Forms.Padding(4);
            this.picErp.Name = "picErp";
            this.picErp.Size = new System.Drawing.Size(64, 60);
            this.picErp.TabIndex = 17;
            this.picErp.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.picErp);
            this.groupBox2.Controls.Add(this.btnErpStop);
            this.groupBox2.Controls.Add(this.statusStrip1);
            this.groupBox2.Controls.Add(this.btnCappStop);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnErpStart);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnCappStart);
            this.groupBox2.Controls.Add(this.picCapp);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(16, 290);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(871, 235);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接口服务";
            // 
            // btnCappStop
            // 
            this.btnCappStop.BackColor = System.Drawing.SystemColors.Control;
            this.btnCappStop.Enabled = false;
            this.btnCappStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCappStop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCappStop.Location = new System.Drawing.Point(736, 146);
            this.btnCappStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnCappStop.Name = "btnCappStop";
            this.btnCappStop.Size = new System.Drawing.Size(100, 41);
            this.btnCappStop.TabIndex = 16;
            this.btnCappStop.Text = "停止";
            this.btnCappStop.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(123, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "ERP接口数据服务";
            // 
            // btnCappStart
            // 
            this.btnCappStart.BackColor = System.Drawing.SystemColors.Control;
            this.btnCappStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCappStart.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCappStart.Location = new System.Drawing.Point(565, 148);
            this.btnCappStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnCappStart.Name = "btnCappStart";
            this.btnCappStart.Size = new System.Drawing.Size(100, 40);
            this.btnCappStart.TabIndex = 15;
            this.btnCappStart.Text = "启动";
            this.btnCappStart.UseVisualStyleBackColor = false;
            // 
            // picCapp
            // 
            this.picCapp.Location = new System.Drawing.Point(8, 128);
            this.picCapp.Margin = new System.Windows.Forms.Padding(4);
            this.picCapp.Name = "picCapp";
            this.picCapp.Size = new System.Drawing.Size(64, 60);
            this.picCapp.TabIndex = 17;
            this.picCapp.TabStop = false;
            // 
            // miTools
            // 
            this.miTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miDBSet,
            this.miInitial});
            this.miTools.Name = "miTools";
            this.miTools.Size = new System.Drawing.Size(70, 24);
            this.miTools.Text = "工具(&T)";
            // 
            // miDBSet
            // 
            this.miDBSet.Name = "miDBSet";
            this.miDBSet.Size = new System.Drawing.Size(181, 26);
            this.miDBSet.Text = "数据库配置(&D)";
            this.miDBSet.Click += new System.EventHandler(this.miDBSet_Click);
            // 
            // miInitial
            // 
            this.miInitial.Name = "miInitial";
            this.miInitial.Size = new System.Drawing.Size(181, 26);
            this.miInitial.Text = "系统初始化(&I)";
            this.miInitial.Click += new System.EventHandler(this.miInitial_Click);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(181, 26);
            this.miExit.Text = "退出(&E)";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miTools,
            this.miHelp});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.mainMenu.Size = new System.Drawing.Size(1130, 28);
            this.mainMenu.TabIndex = 28;
            this.mainMenu.Text = "menuStrip1";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miExit});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(69, 24);
            this.miFile.Text = "文件(&F)";
            // 
            // miHelp
            // 
            this.miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAbout});
            this.miHelp.Name = "miHelp";
            this.miHelp.Size = new System.Drawing.Size(73, 24);
            this.miHelp.Text = "帮助(&H)";
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(181, 26);
            this.miAbout.Text = "关于(&A)";
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 566);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DNA制造过程管理服务端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDataService)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picErp)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCapp)).EndInit();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnErpStop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel dataProcessLabel;
        private System.Windows.Forms.ToolStripProgressBar dataProcessBar;
        private System.Windows.Forms.PictureBox pbDataService;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.DateTimePicker calcuBeginTimeDTP;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripProgressBar proBar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnErpStart;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openTSMI;
        private System.Windows.Forms.ToolStripMenuItem exitTSMI;
        private System.Windows.Forms.PictureBox picErp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCappStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCappStart;
        private System.Windows.Forms.PictureBox picCapp;
        private System.Windows.Forms.ToolStripMenuItem miTools;
        private System.Windows.Forms.ToolStripMenuItem miDBSet;
        private System.Windows.Forms.ToolStripMenuItem miInitial;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miHelp;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
    }
}