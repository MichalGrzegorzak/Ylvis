namespace AService
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
            this.btnChangeConfig = new System.Windows.Forms.Button();
            this.logControl1 = new Core.UI.Controls.LogControl();
            this.SuspendLayout();
            // 
            // btnChangeConfig
            // 
            this.btnChangeConfig.Location = new System.Drawing.Point(12, 12);
            this.btnChangeConfig.Name = "btnChangeConfig";
            this.btnChangeConfig.Size = new System.Drawing.Size(105, 23);
            this.btnChangeConfig.TabIndex = 2;
            this.btnChangeConfig.Text = "Change config";
            this.btnChangeConfig.UseVisualStyleBackColor = true;
            this.btnChangeConfig.Click += new System.EventHandler(this.btnChangeConfig_Click);
            // 
            // logControl1
            // 
            this.logControl1.Location = new System.Drawing.Point(12, 53);
            this.logControl1.Name = "logControl1";
            this.logControl1.Size = new System.Drawing.Size(291, 208);
            this.logControl1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 273);
            this.Controls.Add(this.logControl1);
            this.Controls.Add(this.btnChangeConfig);
            this.Name = "Form1";
            this.Text = "Alarm Event Server";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChangeConfig;
        private Core.UI.Controls.LogControl logControl1;
    }
}

