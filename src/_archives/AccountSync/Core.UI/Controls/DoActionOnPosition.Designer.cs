namespace Core.UI.Controls
{
    partial class DoActionOnPosition
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
            this.btnAction = new System.Windows.Forms.Button();
            this.txbSize = new System.Windows.Forms.TextBox();
            this.cmbDirection = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(4, 3);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(75, 23);
            this.btnAction.TabIndex = 0;
            this.btnAction.Text = "btnAction";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // txbSize
            // 
            this.txbSize.Location = new System.Drawing.Point(85, 6);
            this.txbSize.Name = "txbSize";
            this.txbSize.Size = new System.Drawing.Size(37, 20);
            this.txbSize.TabIndex = 1;
            this.txbSize.Text = "2";
            // 
            // cmbDirection
            // 
            this.cmbDirection.FormattingEnabled = true;
            this.cmbDirection.Items.AddRange(new object[] {
            "K",
            "S"});
            this.cmbDirection.Location = new System.Drawing.Point(128, 6);
            this.cmbDirection.Name = "cmbDirection";
            this.cmbDirection.Size = new System.Drawing.Size(38, 21);
            this.cmbDirection.TabIndex = 2;
            this.cmbDirection.SelectedIndexChanged += new System.EventHandler(this.cmbDirection_SelectedIndexChanged);
            // 
            // DoActionOnPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbDirection);
            this.Controls.Add(this.txbSize);
            this.Controls.Add(this.btnAction);
            this.Name = "DoActionOnPosition";
            this.Size = new System.Drawing.Size(175, 34);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.TextBox txbSize;
        private System.Windows.Forms.ComboBox cmbDirection;
    }
}
