namespace Stock.Forms
{
    partial class CreditFormMVP
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
            this.AddCreditButton = new System.Windows.Forms.Button();
            this.MinInstallmentTextBox = new System.Windows.Forms.TextBox();
            this.InsurancePercentTextBox = new System.Windows.Forms.TextBox();
            this.ProvisionPercentTextBox = new System.Windows.Forms.TextBox();
            this.YearlyInterestPercentTextBox = new System.Windows.Forms.TextBox();
            this.AmountTextBox = new System.Windows.Forms.TextBox();
            this.FinishDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.StartDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.BankNameTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // AddCreditButton
            // 
            this.AddCreditButton.Location = new System.Drawing.Point(18, 262);
            this.AddCreditButton.Name = "AddCreditButton";
            this.AddCreditButton.Size = new System.Drawing.Size(98, 23);
            this.AddCreditButton.TabIndex = 38;
            this.AddCreditButton.Text = "Add Credit";
            this.AddCreditButton.UseVisualStyleBackColor = true;
            this.AddCreditButton.Click += new System.EventHandler(this.AddCreditButton_Click);
            // 
            // MinInstallmentTextBox
            // 
            this.MinInstallmentTextBox.Location = new System.Drawing.Point(161, 216);
            this.MinInstallmentTextBox.Name = "MinInstallmentTextBox";
            this.MinInstallmentTextBox.Size = new System.Drawing.Size(223, 20);
            this.MinInstallmentTextBox.TabIndex = 37;
            // 
            // InsurancePercentTextBox
            // 
            this.InsurancePercentTextBox.Location = new System.Drawing.Point(161, 193);
            this.InsurancePercentTextBox.Name = "InsurancePercentTextBox";
            this.InsurancePercentTextBox.Size = new System.Drawing.Size(223, 20);
            this.InsurancePercentTextBox.TabIndex = 36;
            // 
            // ProvisionPercentTextBox
            // 
            this.ProvisionPercentTextBox.Location = new System.Drawing.Point(161, 171);
            this.ProvisionPercentTextBox.Name = "ProvisionPercentTextBox";
            this.ProvisionPercentTextBox.Size = new System.Drawing.Size(223, 20);
            this.ProvisionPercentTextBox.TabIndex = 35;
            // 
            // YearlyInterestPercentTextBox
            // 
            this.YearlyInterestPercentTextBox.Location = new System.Drawing.Point(161, 149);
            this.YearlyInterestPercentTextBox.Name = "YearlyInterestPercentTextBox";
            this.YearlyInterestPercentTextBox.Size = new System.Drawing.Size(223, 20);
            this.YearlyInterestPercentTextBox.TabIndex = 34;
            // 
            // AmountTextBox
            // 
            this.AmountTextBox.Location = new System.Drawing.Point(161, 126);
            this.AmountTextBox.Name = "AmountTextBox";
            this.AmountTextBox.Size = new System.Drawing.Size(223, 20);
            this.AmountTextBox.TabIndex = 33;
            // 
            // FinishDateDateTimePicker
            // 
            this.FinishDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FinishDateDateTimePicker.Location = new System.Drawing.Point(161, 95);
            this.FinishDateDateTimePicker.Name = "FinishDateDateTimePicker";
            this.FinishDateDateTimePicker.Size = new System.Drawing.Size(223, 20);
            this.FinishDateDateTimePicker.TabIndex = 32;
            // 
            // StartDateDateTimePicker
            // 
            this.StartDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartDateDateTimePicker.Location = new System.Drawing.Point(161, 69);
            this.StartDateDateTimePicker.Name = "StartDateDateTimePicker";
            this.StartDateDateTimePicker.Size = new System.Drawing.Size(223, 20);
            this.StartDateDateTimePicker.TabIndex = 31;
            // 
            // BankNameTextBox
            // 
            this.BankNameTextBox.Location = new System.Drawing.Point(161, 41);
            this.BankNameTextBox.Name = "BankNameTextBox";
            this.BankNameTextBox.Size = new System.Drawing.Size(657, 20);
            this.BankNameTextBox.TabIndex = 30;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(161, 18);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(657, 20);
            this.NameTextBox.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 216);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Min Installment";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Insurance Percent";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Provision Percent";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Amount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Yearly Interest Percent";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Finish date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Bank Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Start date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Name";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 292);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(800, 150);
            this.dataGridView1.TabIndex = 39;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(453, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 40;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CreditFormMVP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 484);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.AddCreditButton);
            this.Controls.Add(this.MinInstallmentTextBox);
            this.Controls.Add(this.InsurancePercentTextBox);
            this.Controls.Add(this.ProvisionPercentTextBox);
            this.Controls.Add(this.YearlyInterestPercentTextBox);
            this.Controls.Add(this.AmountTextBox);
            this.Controls.Add(this.FinishDateDateTimePicker);
            this.Controls.Add(this.StartDateDateTimePicker);
            this.Controls.Add(this.BankNameTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CreditFormMVP";
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddCreditButton;
        private System.Windows.Forms.TextBox MinInstallmentTextBox;
        private System.Windows.Forms.TextBox InsurancePercentTextBox;
        private System.Windows.Forms.TextBox ProvisionPercentTextBox;
        private System.Windows.Forms.TextBox YearlyInterestPercentTextBox;
        private System.Windows.Forms.TextBox AmountTextBox;
        private System.Windows.Forms.DateTimePicker FinishDateDateTimePicker;
        private System.Windows.Forms.DateTimePicker StartDateDateTimePicker;
        private System.Windows.Forms.TextBox BankNameTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
    }
}