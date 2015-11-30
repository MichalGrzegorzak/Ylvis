namespace ToolCut.UI
{
    partial class InputControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txbToolDiameter = new System.Windows.Forms.TextBox();
            this.txbToolSfm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbToolDiameter
            // 
            this.txbToolDiameter.Location = new System.Drawing.Point(3, 26);
            this.txbToolDiameter.Name = "txbToolDiameter";
            this.txbToolDiameter.Size = new System.Drawing.Size(100, 20);
            this.txbToolDiameter.TabIndex = 0;
            // 
            // txbToolSfm
            // 
            this.txbToolSfm.Location = new System.Drawing.Point(109, 26);
            this.txbToolSfm.Name = "txbToolSfm";
            this.txbToolSfm.Size = new System.Drawing.Size(100, 20);
            this.txbToolSfm.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tool diameter:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "SFM:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(216, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 24);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // InputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbToolSfm);
            this.Controls.Add(this.txbToolDiameter);
            this.Name = "InputControl";
            this.Size = new System.Drawing.Size(292, 53);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbToolDiameter;
        private System.Windows.Forms.TextBox txbToolSfm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}
