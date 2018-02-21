namespace DnaMesUi.Shared.Sys
{
    partial class HomeForm
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
            this.MenuExplorerBar = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            ((System.ComponentModel.ISupportInitialize)(this.MenuExplorerBar)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuExplorerBar
            // 
            this.MenuExplorerBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuExplorerBar.Location = new System.Drawing.Point(0, 0);
            this.MenuExplorerBar.Name = "MenuExplorerBar";
            this.MenuExplorerBar.Size = new System.Drawing.Size(969, 665);
            this.MenuExplorerBar.TabIndex = 0;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 665);
            this.Controls.Add(this.MenuExplorerBar);
            this.Name = "HomeForm";
            this.Text = "Home";
            ((System.ComponentModel.ISupportInitialize)(this.MenuExplorerBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar MenuExplorerBar;
    }
}