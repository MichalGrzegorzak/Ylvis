namespace Stock.Forms
{
    partial class CreditForm
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.BankNametextBox = new System.Windows.Forms.TextBox();
            this.StartDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FinishDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.AmountTextBox = new System.Windows.Forms.TextBox();
            this.YearlyInterestPercentTextBox = new System.Windows.Forms.TextBox();
            this.ProvisionPercentTextBox = new System.Windows.Forms.TextBox();
            this.InsurancePercentTextBox = new System.Windows.Forms.TextBox();
            this.MinInstallmentTextBox = new System.Windows.Forms.TextBox();
            this.AddCreditButton = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finishDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearlyInterestPercentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.provisionPercentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insurancePercentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minInstallmentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.bankNameDataGridViewTextBoxColumn,
            this.startDateDataGridViewTextBoxColumn,
            this.finishDateDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.yearlyInterestPercentDataGridViewTextBoxColumn,
            this.provisionPercentDataGridViewTextBoxColumn,
            this.insurancePercentDataGridViewTextBoxColumn,
            this.minInstallmentDataGridViewTextBoxColumn,
            this.iDDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 305);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(958, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(Stock.Core.Domain.Credit);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Start date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Bank Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Finish date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Yearly Interest Percent";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Amount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Provision Percent";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Insurance Percent";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Min Installment";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(168, 9);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(802, 20);
            this.NameTextBox.TabIndex = 10;
            // 
            // BankNametextBox
            // 
            this.BankNametextBox.Location = new System.Drawing.Point(168, 32);
            this.BankNametextBox.Name = "BankNametextBox";
            this.BankNametextBox.Size = new System.Drawing.Size(802, 20);
            this.BankNametextBox.TabIndex = 11;
            // 
            // StartDateDateTimePicker
            // 
            this.StartDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartDateDateTimePicker.Location = new System.Drawing.Point(168, 60);
            this.StartDateDateTimePicker.Name = "StartDateDateTimePicker";
            this.StartDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.StartDateDateTimePicker.TabIndex = 12;
            // 
            // FinishDateDateTimePicker
            // 
            this.FinishDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FinishDateDateTimePicker.Location = new System.Drawing.Point(168, 86);
            this.FinishDateDateTimePicker.Name = "FinishDateDateTimePicker";
            this.FinishDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.FinishDateDateTimePicker.TabIndex = 13;
            // 
            // AmountTextBox
            // 
            this.AmountTextBox.Location = new System.Drawing.Point(168, 117);
            this.AmountTextBox.Name = "AmountTextBox";
            this.AmountTextBox.Size = new System.Drawing.Size(200, 20);
            this.AmountTextBox.TabIndex = 14;
            // 
            // YearlyInterestPercentTextBox
            // 
            this.YearlyInterestPercentTextBox.Location = new System.Drawing.Point(168, 140);
            this.YearlyInterestPercentTextBox.Name = "YearlyInterestPercentTextBox";
            this.YearlyInterestPercentTextBox.Size = new System.Drawing.Size(200, 20);
            this.YearlyInterestPercentTextBox.TabIndex = 15;
            // 
            // ProvisionPercentTextBox
            // 
            this.ProvisionPercentTextBox.Location = new System.Drawing.Point(168, 162);
            this.ProvisionPercentTextBox.Name = "ProvisionPercentTextBox";
            this.ProvisionPercentTextBox.Size = new System.Drawing.Size(200, 20);
            this.ProvisionPercentTextBox.TabIndex = 16;
            // 
            // InsurancePercentTextBox
            // 
            this.InsurancePercentTextBox.Location = new System.Drawing.Point(168, 184);
            this.InsurancePercentTextBox.Name = "InsurancePercentTextBox";
            this.InsurancePercentTextBox.Size = new System.Drawing.Size(200, 20);
            this.InsurancePercentTextBox.TabIndex = 17;
            // 
            // MinInstallmentTextBox
            // 
            this.MinInstallmentTextBox.Location = new System.Drawing.Point(168, 207);
            this.MinInstallmentTextBox.Name = "MinInstallmentTextBox";
            this.MinInstallmentTextBox.Size = new System.Drawing.Size(200, 20);
            this.MinInstallmentTextBox.TabIndex = 18;
            // 
            // AddCreditButton
            // 
            this.AddCreditButton.Location = new System.Drawing.Point(25, 253);
            this.AddCreditButton.Name = "AddCreditButton";
            this.AddCreditButton.Size = new System.Drawing.Size(75, 23);
            this.AddCreditButton.TabIndex = 19;
            this.AddCreditButton.Text = "Add Credit";
            this.AddCreditButton.UseVisualStyleBackColor = true;
            this.AddCreditButton.Click += new System.EventHandler(this.AddCreditButton_Click);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // bankNameDataGridViewTextBoxColumn
            // 
            this.bankNameDataGridViewTextBoxColumn.DataPropertyName = "BankName";
            this.bankNameDataGridViewTextBoxColumn.HeaderText = "BankName";
            this.bankNameDataGridViewTextBoxColumn.Name = "bankNameDataGridViewTextBoxColumn";
            this.bankNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // startDateDataGridViewTextBoxColumn
            // 
            this.startDateDataGridViewTextBoxColumn.DataPropertyName = "StartDate";
            this.startDateDataGridViewTextBoxColumn.HeaderText = "StartDate";
            this.startDateDataGridViewTextBoxColumn.Name = "startDateDataGridViewTextBoxColumn";
            this.startDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // finishDateDataGridViewTextBoxColumn
            // 
            this.finishDateDataGridViewTextBoxColumn.DataPropertyName = "FinishDate";
            this.finishDateDataGridViewTextBoxColumn.HeaderText = "FinishDate";
            this.finishDateDataGridViewTextBoxColumn.Name = "finishDateDataGridViewTextBoxColumn";
            this.finishDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // yearlyInterestPercentDataGridViewTextBoxColumn
            // 
            this.yearlyInterestPercentDataGridViewTextBoxColumn.DataPropertyName = "YearlyInterestPercent";
            this.yearlyInterestPercentDataGridViewTextBoxColumn.HeaderText = "YearlyInterestPercent";
            this.yearlyInterestPercentDataGridViewTextBoxColumn.Name = "yearlyInterestPercentDataGridViewTextBoxColumn";
            this.yearlyInterestPercentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // provisionPercentDataGridViewTextBoxColumn
            // 
            this.provisionPercentDataGridViewTextBoxColumn.DataPropertyName = "ProvisionPercent";
            this.provisionPercentDataGridViewTextBoxColumn.HeaderText = "ProvisionPercent";
            this.provisionPercentDataGridViewTextBoxColumn.Name = "provisionPercentDataGridViewTextBoxColumn";
            this.provisionPercentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // insurancePercentDataGridViewTextBoxColumn
            // 
            this.insurancePercentDataGridViewTextBoxColumn.DataPropertyName = "InsurancePercent";
            this.insurancePercentDataGridViewTextBoxColumn.HeaderText = "InsurancePercent";
            this.insurancePercentDataGridViewTextBoxColumn.Name = "insurancePercentDataGridViewTextBoxColumn";
            this.insurancePercentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // minInstallmentDataGridViewTextBoxColumn
            // 
            this.minInstallmentDataGridViewTextBoxColumn.DataPropertyName = "MinInstallment";
            this.minInstallmentDataGridViewTextBoxColumn.HeaderText = "MinInstallment";
            this.minInstallmentDataGridViewTextBoxColumn.Name = "minInstallmentDataGridViewTextBoxColumn";
            this.minInstallmentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(292, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Log";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CreditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 491);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AddCreditButton);
            this.Controls.Add(this.MinInstallmentTextBox);
            this.Controls.Add(this.InsurancePercentTextBox);
            this.Controls.Add(this.ProvisionPercentTextBox);
            this.Controls.Add(this.YearlyInterestPercentTextBox);
            this.Controls.Add(this.AmountTextBox);
            this.Controls.Add(this.FinishDateDateTimePicker);
            this.Controls.Add(this.StartDateDateTimePicker);
            this.Controls.Add(this.BankNametextBox);
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
            this.Controls.Add(this.dataGridView1);
            this.Name = "CreditForm";
            this.Text = "CreditForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox BankNametextBox;
        private System.Windows.Forms.DateTimePicker StartDateDateTimePicker;
        private System.Windows.Forms.DateTimePicker FinishDateDateTimePicker;
        private System.Windows.Forms.TextBox AmountTextBox;
        private System.Windows.Forms.TextBox YearlyInterestPercentTextBox;
        private System.Windows.Forms.TextBox ProvisionPercentTextBox;
        private System.Windows.Forms.TextBox InsurancePercentTextBox;
        private System.Windows.Forms.TextBox MinInstallmentTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button AddCreditButton;
        private System.Windows.Forms.DataGridViewImageColumn imageDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDesignableDataGridViewCheckBoxColumn;
        protected System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn finishDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yearlyInterestPercentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn provisionPercentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn insurancePercentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn minInstallmentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
    }
}