using Commons.Appenders;

namespace AServiceClient
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnMonitor = new System.Windows.Forms.Button();
            this.btnDetectPosition = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.ctrlChangePosition = new Core.UI.Controls.DoActionOnPosition();
            this.logControl1 = new Core.UI.Controls.LogControl();
            this.accounts1 = new Core.UI.Controls.Accounts();
            this.ctrlSendMail = new Core.UI.Controls.DoActionOnPosition();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(6, 19);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnMonitor
            // 
            this.btnMonitor.Location = new System.Drawing.Point(6, 19);
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Size = new System.Drawing.Size(75, 23);
            this.btnMonitor.TabIndex = 5;
            this.btnMonitor.Text = "Start monitor";
            this.btnMonitor.UseVisualStyleBackColor = true;
            this.btnMonitor.Click += new System.EventHandler(this.btnMonitoring_Click);
            // 
            // btnDetectPosition
            // 
            this.btnDetectPosition.Location = new System.Drawing.Point(6, 89);
            this.btnDetectPosition.Name = "btnDetectPosition";
            this.btnDetectPosition.Size = new System.Drawing.Size(75, 23);
            this.btnDetectPosition.TabIndex = 7;
            this.btnDetectPosition.Text = "Detect position";
            this.btnDetectPosition.UseVisualStyleBackColor = true;
            this.btnDetectPosition.Click += new System.EventHandler(this.btnDetectPosition_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(296, 353);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(264, 46);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // ctrlChangePosition
            // 
            this.ctrlChangePosition.Location = new System.Drawing.Point(6, 49);
            this.ctrlChangePosition.Name = "ctrlChangePosition";
            this.ctrlChangePosition.Size = new System.Drawing.Size(175, 34);
            this.ctrlChangePosition.TabIndex = 10;
            // 
            // logControl1
            // 
            this.logControl1.Location = new System.Drawing.Point(296, 164);
            this.logControl1.Name = "logControl1";
            this.logControl1.Size = new System.Drawing.Size(264, 179);
            this.logControl1.TabIndex = 6;
            // 
            // accounts1
            // 
            this.accounts1.Location = new System.Drawing.Point(12, 2);
            this.accounts1.Name = "accounts1";
            this.accounts1.Size = new System.Drawing.Size(548, 156);
            this.accounts1.TabIndex = 1;
            // 
            // ctrlSendMail
            // 
            this.ctrlSendMail.Location = new System.Drawing.Point(80, 13);
            this.ctrlSendMail.Name = "ctrlSendMail";
            this.ctrlSendMail.Size = new System.Drawing.Size(175, 34);
            this.ctrlSendMail.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMonitor);
            this.groupBox1.Controls.Add(this.ctrlSendMail);
            this.groupBox1.Location = new System.Drawing.Point(12, 346);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 53);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gmail monitor";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ctrlChangePosition);
            this.groupBox2.Controls.Add(this.btnConnect);
            this.groupBox2.Controls.Add(this.btnDetectPosition);
            this.groupBox2.Location = new System.Drawing.Point(12, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(252, 136);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server actions";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 411);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.logControl1);
            this.Controls.Add(this.accounts1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Core.UI.Controls.Accounts accounts1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnMonitor;
        private Core.UI.Controls.LogControl logControl1;
        private System.Windows.Forms.Button btnDetectPosition;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private Core.UI.Controls.DoActionOnPosition ctrlChangePosition;
        private Core.UI.Controls.DoActionOnPosition ctrlSendMail;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

