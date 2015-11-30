namespace Stock
{
    partial class TransactionsForm
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
            this.grbNewTransaction = new System.Windows.Forms.GroupBox();
            this.txtGroupId = new System.Windows.Forms.TextBox();
            this.txtFee = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblKod = new System.Windows.Forms.Label();
            this.chbBuy = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblCena = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblIlosc = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblSuma = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGroup = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Buy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbNewTransaction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // grbNewTransaction
            // 
            this.grbNewTransaction.Controls.Add(this.txtGroupId);
            this.grbNewTransaction.Controls.Add(this.txtFee);
            this.grbNewTransaction.Controls.Add(this.dtpDate);
            this.grbNewTransaction.Controls.Add(this.lblKod);
            this.grbNewTransaction.Controls.Add(this.chbBuy);
            this.grbNewTransaction.Controls.Add(this.btnAdd);
            this.grbNewTransaction.Controls.Add(this.lblCena);
            this.grbNewTransaction.Controls.Add(this.txtCode);
            this.grbNewTransaction.Controls.Add(this.txtPrice);
            this.grbNewTransaction.Controls.Add(this.lblIlosc);
            this.grbNewTransaction.Controls.Add(this.txtAmount);
            this.grbNewTransaction.Location = new System.Drawing.Point(3, 3);
            this.grbNewTransaction.Name = "grbNewTransaction";
            this.grbNewTransaction.Size = new System.Drawing.Size(717, 75);
            this.grbNewTransaction.TabIndex = 11;
            this.grbNewTransaction.TabStop = false;
            this.grbNewTransaction.Text = "New transaction";
            // 
            // txtGroupId
            // 
            this.txtGroupId.Location = new System.Drawing.Point(495, 37);
            this.txtGroupId.Name = "txtGroupId";
            this.txtGroupId.Size = new System.Drawing.Size(75, 20);
            this.txtGroupId.TabIndex = 12;
            this.txtGroupId.Text = "group Id";
            // 
            // txtFee
            // 
            this.txtFee.Location = new System.Drawing.Point(426, 37);
            this.txtFee.Name = "txtFee";
            this.txtFee.Size = new System.Drawing.Size(63, 20);
            this.txtFee.TabIndex = 11;
            this.txtFee.Text = "Fee";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(7, 37);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(82, 20);
            this.dtpDate.TabIndex = 10;
            // 
            // lblKod
            // 
            this.lblKod.AutoSize = true;
            this.lblKod.Location = new System.Drawing.Point(95, 22);
            this.lblKod.Name = "lblKod";
            this.lblKod.Size = new System.Drawing.Size(44, 13);
            this.lblKod.TabIndex = 3;
            this.lblKod.Text = "Symbol:";
            // 
            // chbBuy
            // 
            this.chbBuy.AutoSize = true;
            this.chbBuy.Location = new System.Drawing.Point(288, 40);
            this.chbBuy.Name = "chbBuy";
            this.chbBuy.Size = new System.Drawing.Size(44, 17);
            this.chbBuy.TabIndex = 9;
            this.chbBuy.Text = "Buy";
            this.chbBuy.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(594, 36);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(97, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add transaction";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // lblCena
            // 
            this.lblCena.AutoSize = true;
            this.lblCena.Location = new System.Drawing.Point(335, 22);
            this.lblCena.Name = "lblCena";
            this.lblCena.Size = new System.Drawing.Size(34, 13);
            this.lblCena.TabIndex = 8;
            this.lblCena.Text = "Price:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(98, 38);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(78, 20);
            this.txtCode.TabIndex = 4;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(338, 37);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(82, 20);
            this.txtPrice.TabIndex = 7;
            // 
            // lblIlosc
            // 
            this.lblIlosc.AutoSize = true;
            this.lblIlosc.Location = new System.Drawing.Point(179, 22);
            this.lblIlosc.Name = "lblIlosc";
            this.lblIlosc.Size = new System.Drawing.Size(46, 13);
            this.lblIlosc.TabIndex = 5;
            this.lblIlosc.Text = "Amount:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(182, 38);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 6;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(726, 356);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh grid";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.iDDataGridViewTextBoxColumn,
            this.Date,
            this.Symbol,
            this.Buy,
            this.amountDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.Value,
            this.Fee,
            this.GroupId});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(1, 122);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(884, 210);
            this.dataGridView1.TabIndex = 1;
            // 
            // lblSuma
            // 
            this.lblSuma.AutoSize = true;
            this.lblSuma.Location = new System.Drawing.Point(491, 335);
            this.lblSuma.Name = "lblSuma";
            this.lblSuma.Size = new System.Drawing.Size(46, 13);
            this.lblSuma.TabIndex = 11;
            this.lblSuma.Text = "Suma: 0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(352, 367);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "label1";
            // 
            // btnGroup
            // 
            this.btnGroup.Location = new System.Drawing.Point(473, 357);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(108, 23);
            this.btnGroup.TabIndex = 13;
            this.btnGroup.Text = "Group together";
            this.btnGroup.UseVisualStyleBackColor = true;
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(597, 358);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(54, 20);
            this.textBox1.TabIndex = 14;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(Stock.Core.Domain.Transaction);
            // 
            // Select
            // 
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            this.Select.Width = 20;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 20;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // Symbol
            // 
            this.Symbol.DataPropertyName = "Symbol";
            this.Symbol.HeaderText = "Symbol";
            this.Symbol.Name = "Symbol";
            this.Symbol.ReadOnly = true;
            // 
            // Buy
            // 
            this.Buy.DataPropertyName = "Buy";
            this.Buy.HeaderText = "Buy";
            this.Buy.Name = "Buy";
            this.Buy.ReadOnly = true;
            this.Buy.Width = 15;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.DataPropertyName = "Value";
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            // 
            // Fee
            // 
            this.Fee.DataPropertyName = "Fee";
            this.Fee.HeaderText = "Fee";
            this.Fee.Name = "Fee";
            // 
            // GroupId
            // 
            this.GroupId.DataPropertyName = "GroupId";
            this.GroupId.HeaderText = "GroupId";
            this.GroupId.Name = "GroupId";
            // 
            // TransactionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 513);
            this.Controls.Add(this.grbNewTransaction);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnGroup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSuma);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dataGridView1);
            this.Name = "TransactionsForm";
            this.Text = "Form1";
            this.grbNewTransaction.ResumeLayout(false);
            this.grbNewTransaction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblSuma;
        protected System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGroup;
        private System.Windows.Forms.TextBox textBox1;
//
        private System.Windows.Forms.GroupBox grbNewTransaction;
        private System.Windows.Forms.TextBox txtGroupId;
        private System.Windows.Forms.TextBox txtFee;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblKod;
        private System.Windows.Forms.CheckBox chbBuy;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblCena;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblIlosc;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Symbol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Buy;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fee;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupId;
    }
}

