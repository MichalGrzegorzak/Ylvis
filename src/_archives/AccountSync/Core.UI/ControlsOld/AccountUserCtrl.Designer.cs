namespace Core.UI
{
    partial class AccountUserCtrl
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txbPosition = new System.Windows.Forms.TextBox();
            this.txbPrice = new System.Windows.Forms.TextBox();
            this.txbStop = new System.Windows.Forms.TextBox();
            this.txbDate = new System.Windows.Forms.TextBox();
            this.grbAccount = new System.Windows.Forms.GroupBox();
            this.chbEnabled = new System.Windows.Forms.CheckBox();
            this.grbAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Position:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Entry:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "SL:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Date:";
            // 
            // txbPosition
            // 
            this.txbPosition.Location = new System.Drawing.Point(59, 13);
            this.txbPosition.Name = "txbPosition";
            this.txbPosition.Size = new System.Drawing.Size(30, 20);
            this.txbPosition.TabIndex = 4;
            this.txbPosition.Text = "0 K";
            this.txbPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbPrice
            // 
            this.txbPrice.Location = new System.Drawing.Point(144, 13);
            this.txbPrice.Name = "txbPrice";
            this.txbPrice.Size = new System.Drawing.Size(30, 20);
            this.txbPrice.TabIndex = 5;
            this.txbPrice.Text = "2222";
            // 
            // txbStop
            // 
            this.txbStop.Enabled = false;
            this.txbStop.Location = new System.Drawing.Point(144, 65);
            this.txbStop.Name = "txbStop";
            this.txbStop.Size = new System.Drawing.Size(30, 20);
            this.txbStop.TabIndex = 6;
            // 
            // txbDate
            // 
            this.txbDate.Location = new System.Drawing.Point(79, 39);
            this.txbDate.Name = "txbDate";
            this.txbDate.Size = new System.Drawing.Size(95, 20);
            this.txbDate.TabIndex = 7;
            this.txbDate.Text = "2009-09-09 11:33";
            // 
            // grbAccount
            // 
            this.grbAccount.Controls.Add(this.chbEnabled);
            this.grbAccount.Controls.Add(this.label1);
            this.grbAccount.Controls.Add(this.label2);
            this.grbAccount.Controls.Add(this.txbDate);
            this.grbAccount.Controls.Add(this.label3);
            this.grbAccount.Controls.Add(this.txbStop);
            this.grbAccount.Controls.Add(this.label4);
            this.grbAccount.Controls.Add(this.txbPrice);
            this.grbAccount.Controls.Add(this.txbPosition);
            this.grbAccount.Location = new System.Drawing.Point(3, 3);
            this.grbAccount.Name = "grbAccount";
            this.grbAccount.Size = new System.Drawing.Size(180, 128);
            this.grbAccount.TabIndex = 9;
            this.grbAccount.TabStop = false;
            this.grbAccount.Text = "Account";
            // 
            // chbEnabled
            // 
            this.chbEnabled.AutoSize = true;
            this.chbEnabled.Checked = true;
            this.chbEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbEnabled.Location = new System.Drawing.Point(9, 105);
            this.chbEnabled.Name = "chbEnabled";
            this.chbEnabled.Size = new System.Drawing.Size(65, 17);
            this.chbEnabled.TabIndex = 9;
            this.chbEnabled.Text = "Enabled";
            this.chbEnabled.UseVisualStyleBackColor = true;
            // 
            // AccountUserCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbAccount);
            this.Name = "AccountUserCtrl";
            this.Size = new System.Drawing.Size(192, 139);
            this.grbAccount.ResumeLayout(false);
            this.grbAccount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbPosition;
        private System.Windows.Forms.TextBox txbPrice;
        private System.Windows.Forms.TextBox txbStop;
        private System.Windows.Forms.TextBox txbDate;
        private System.Windows.Forms.GroupBox grbAccount;
        private System.Windows.Forms.CheckBox chbEnabled;
    }
}
