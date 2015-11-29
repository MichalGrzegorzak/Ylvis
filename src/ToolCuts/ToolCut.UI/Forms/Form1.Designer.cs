namespace ToolCut.UI
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cmbTools = new System.Windows.Forms.ToolStripComboBox();
            this.menuToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.defineNewToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditTool = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmbTools,
            this.menuToolStrip});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(451, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cmbTools
            // 
            this.cmbTools.Name = "cmbTools";
            this.cmbTools.Size = new System.Drawing.Size(121, 21);
            this.cmbTools.SelectedIndexChanged += new System.EventHandler(this.cmbTools_SelectedIndexChanged);
            // 
            // menuToolStrip
            // 
            this.menuToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defineNewToolToolStripMenuItem,
            this.EditTool});
            this.menuToolStrip.Name = "menuToolStrip";
            this.menuToolStrip.Size = new System.Drawing.Size(47, 21);
            this.menuToolStrip.Text = "MENU";
            // 
            // defineNewToolToolStripMenuItem
            // 
            this.defineNewToolToolStripMenuItem.Name = "defineNewToolToolStripMenuItem";
            this.defineNewToolToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.defineNewToolToolStripMenuItem.Text = "Define new tool";
            this.defineNewToolToolStripMenuItem.Click += new System.EventHandler(this.defineNewToolToolStripMenuItem_Click);
            // 
            // EditTool
            // 
            this.EditTool.Name = "EditTool";
            this.EditTool.Size = new System.Drawing.Size(160, 22);
            this.EditTool.Text = "Edit tool";
            this.EditTool.Click += new System.EventHandler(this.editTool_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer1.Size = new System.Drawing.Size(451, 243);
            this.splitContainer1.SplitterDistance = 57;
            this.splitContainer1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 268);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripComboBox cmbTools;
        private System.Windows.Forms.ToolStripMenuItem menuToolStrip;
        private System.Windows.Forms.ToolStripMenuItem defineNewToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditTool;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

