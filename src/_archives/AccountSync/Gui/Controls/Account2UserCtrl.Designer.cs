using Core;

namespace WatTest.Controls
{
    

    partial class Account2UserCtrl : IAccountUserCtrl
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
            this.lblPos = new System.Windows.Forms.Label();
            this.lblEntry = new System.Windows.Forms.Label();
            this.lblSl = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.grbAccount = new System.Windows.Forms.GroupBox();
            this.lblPositionEnter = new System.Windows.Forms.Label();
            this.chbEnabled = new System.Windows.Forms.CheckBox();
            this.grbAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPos
            // 
            this.lblPos.AutoSize = true;
            this.lblPos.Location = new System.Drawing.Point(6, 19);
            this.lblPos.Name = "lblPos";
            this.lblPos.Size = new System.Drawing.Size(47, 13);
            this.lblPos.TabIndex = 0;
            this.lblPos.Text = "Position:";
            // 
            // lblEntry
            // 
            this.lblEntry.AutoSize = true;
            this.lblEntry.Location = new System.Drawing.Point(6, 42);
            this.lblEntry.Name = "lblEntry";
            this.lblEntry.Size = new System.Drawing.Size(34, 13);
            this.lblEntry.TabIndex = 1;
            this.lblEntry.Text = "Entry:";
            // 
            // lblSl
            // 
            this.lblSl.AutoSize = true;
            this.lblSl.Location = new System.Drawing.Point(103, 42);
            this.lblSl.Name = "lblSl";
            this.lblSl.Size = new System.Drawing.Size(23, 13);
            this.lblSl.TabIndex = 2;
            this.lblSl.Text = "SL:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(6, 66);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Date:";
            // 
            // grbAccount
            // 
            this.grbAccount.Controls.Add(this.lblPositionEnter);
            this.grbAccount.Controls.Add(this.chbEnabled);
            this.grbAccount.Controls.Add(this.lblPos);
            this.grbAccount.Controls.Add(this.lblEntry);
            this.grbAccount.Controls.Add(this.lblSl);
            this.grbAccount.Controls.Add(this.lblDate);
            this.grbAccount.Location = new System.Drawing.Point(3, 3);
            this.grbAccount.Name = "grbAccount";
            this.grbAccount.Size = new System.Drawing.Size(179, 96);
            this.grbAccount.TabIndex = 9;
            this.grbAccount.TabStop = false;
            this.grbAccount.Text = "Account";
            // 
            // lblPositionEnter
            // 
            this.lblPositionEnter.AutoSize = true;
            this.lblPositionEnter.Location = new System.Drawing.Point(59, 19);
            this.lblPositionEnter.Name = "lblPositionEnter";
            this.lblPositionEnter.Size = new System.Drawing.Size(35, 13);
            this.lblPositionEnter.TabIndex = 10;
            this.lblPositionEnter.Text = "label5";
            // 
            // chbEnabled
            // 
            this.chbEnabled.AutoSize = true;
            this.chbEnabled.Checked = true;
            this.chbEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbEnabled.Location = new System.Drawing.Point(106, 15);
            this.chbEnabled.Name = "chbEnabled";
            this.chbEnabled.Size = new System.Drawing.Size(65, 17);
            this.chbEnabled.TabIndex = 9;
            this.chbEnabled.Text = "Enabled";
            this.chbEnabled.UseVisualStyleBackColor = true;
            // 
            // Account2UserCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbAccount);
            this.Name = "Account2UserCtrl";
            this.Size = new System.Drawing.Size(185, 103);
            this.grbAccount.ResumeLayout(false);
            this.grbAccount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPos;
        private System.Windows.Forms.Label lblEntry;
        private System.Windows.Forms.Label lblSl;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.GroupBox grbAccount;
        private System.Windows.Forms.CheckBox chbEnabled;
        private System.Windows.Forms.Label lblPositionEnter;
    }
}
