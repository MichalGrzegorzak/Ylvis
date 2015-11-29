namespace WatTest
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCurrentPos = new System.Windows.Forms.Button();
            this.btnChangePos = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.chbMonitoring = new System.Windows.Forms.CheckBox();
            this.btnPopup = new System.Windows.Forms.Button();
            this.btnMonitoring = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbMain = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbSync = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSendSignal = new System.Windows.Forms.Button();
            this.txbSignal = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.logControl1 = new WatTest.Controls.LogControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(21, 19);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.Login_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(241, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Position";
            // 
            // btnCurrentPos
            // 
            this.btnCurrentPos.Location = new System.Drawing.Point(21, 50);
            this.btnCurrentPos.Name = "btnCurrentPos";
            this.btnCurrentPos.Size = new System.Drawing.Size(75, 23);
            this.btnCurrentPos.TabIndex = 2;
            this.btnCurrentPos.Text = "CurrentPos";
            this.btnCurrentPos.UseVisualStyleBackColor = true;
            this.btnCurrentPos.Click += new System.EventHandler(this.CurrentPos_Click);
            // 
            // btnChangePos
            // 
            this.btnChangePos.Location = new System.Drawing.Point(21, 77);
            this.btnChangePos.Name = "btnChangePos";
            this.btnChangePos.Size = new System.Drawing.Size(75, 23);
            this.btnChangePos.TabIndex = 3;
            this.btnChangePos.Text = "ChangePos";
            this.btnChangePos.UseVisualStyleBackColor = true;
            this.btnChangePos.Click += new System.EventHandler(this.ChangePos_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(21, 106);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chbMonitoring
            // 
            this.chbMonitoring.AutoSize = true;
            this.chbMonitoring.Checked = true;
            this.chbMonitoring.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbMonitoring.Location = new System.Drawing.Point(6, 48);
            this.chbMonitoring.Name = "chbMonitoring";
            this.chbMonitoring.Size = new System.Drawing.Size(114, 17);
            this.chbMonitoring.TabIndex = 6;
            this.chbMonitoring.Text = "MonitoringEnabled";
            this.chbMonitoring.UseVisualStyleBackColor = true;
            this.chbMonitoring.CheckedChanged += new System.EventHandler(this.chbMonitoring_CheckedChanged);
            // 
            // btnPopup
            // 
            this.btnPopup.Location = new System.Drawing.Point(524, 291);
            this.btnPopup.Name = "btnPopup";
            this.btnPopup.Size = new System.Drawing.Size(75, 23);
            this.btnPopup.TabIndex = 8;
            this.btnPopup.Text = "Popup";
            this.btnPopup.UseVisualStyleBackColor = true;
            this.btnPopup.Click += new System.EventHandler(this.TestPopup_Click_1);
            // 
            // btnMonitoring
            // 
            this.btnMonitoring.Location = new System.Drawing.Point(22, 19);
            this.btnMonitoring.Name = "btnMonitoring";
            this.btnMonitoring.Size = new System.Drawing.Size(75, 23);
            this.btnMonitoring.TabIndex = 9;
            this.btnMonitoring.Text = "Start monitoring";
            this.btnMonitoring.UseVisualStyleBackColor = true;
            this.btnMonitoring.Click += new System.EventHandler(this.TestMonitoring_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(503, 320);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "2acc - Login&GetPos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(390, 301);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Timer";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(8, 71);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(178, 23);
            this.progressBar1.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLogin);
            this.groupBox1.Controls.Add(this.btnCurrentPos);
            this.groupBox1.Controls.Add(this.btnChangePos);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(118, 142);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Single account tests";
            // 
            // cmbMain
            // 
            this.cmbMain.FormattingEnabled = true;
            this.cmbMain.Items.AddRange(new object[] {
            "MGRZ",
            "EWA_FULL"});
            this.cmbMain.Location = new System.Drawing.Point(56, 19);
            this.cmbMain.Name = "cmbMain";
            this.cmbMain.Size = new System.Drawing.Size(102, 21);
            this.cmbMain.TabIndex = 14;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbSync);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmbMain);
            this.groupBox2.Location = new System.Drawing.Point(148, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(178, 100);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Choose accounts";
            // 
            // cmbSync
            // 
            this.cmbSync.FormattingEnabled = true;
            this.cmbSync.Location = new System.Drawing.Point(56, 57);
            this.cmbSync.Name = "cmbSync";
            this.cmbSync.Size = new System.Drawing.Size(102, 21);
            this.cmbSync.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "ToSync";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Main";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSendSignal);
            this.groupBox4.Controls.Add(this.txbSignal);
            this.groupBox4.Controls.Add(this.btnMonitoring);
            this.groupBox4.Controls.Add(this.chbMonitoring);
            this.groupBox4.Controls.Add(this.progressBar1);
            this.groupBox4.Location = new System.Drawing.Point(12, 173);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(241, 100);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Monitoring";
            // 
            // btnSendSignal
            // 
            this.btnSendSignal.Location = new System.Drawing.Point(171, 19);
            this.btnSendSignal.Name = "btnSendSignal";
            this.btnSendSignal.Size = new System.Drawing.Size(62, 23);
            this.btnSendSignal.TabIndex = 19;
            this.btnSendSignal.Text = "Send signal";
            this.btnSendSignal.UseVisualStyleBackColor = true;
            this.btnSendSignal.Click += new System.EventHandler(this.btnSendSignal_Click);
            // 
            // txbSignal
            // 
            this.txbSignal.Location = new System.Drawing.Point(124, 19);
            this.txbSignal.Name = "txbSignal";
            this.txbSignal.Size = new System.Drawing.Size(41, 20);
            this.txbSignal.TabIndex = 20;
            this.txbSignal.Text = "4K";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(348, 250);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 18;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // logControl1
            // 
            this.logControl1.Location = new System.Drawing.Point(332, 12);
            this.logControl1.Name = "logControl1";
            this.logControl1.Size = new System.Drawing.Size(305, 226);
            this.logControl1.TabIndex = 19;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 365);
            this.Controls.Add(this.logControl1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPopup);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCurrentPos;
        private System.Windows.Forms.Button btnChangePos;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chbMonitoring;
        private System.Windows.Forms.Button btnPopup;
        private System.Windows.Forms.Button btnMonitoring;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbMain;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbSync;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnSendSignal;
        private System.Windows.Forms.TextBox txbSignal;
        private WatTest.Controls.LogControl logControl1;
    }
}

