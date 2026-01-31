namespace SamiCargoYSY
{
    partial class Invoice_Management
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
            this.grpInvoiceDetails = new System.Windows.Forms.GroupBox();
            this.chkCorrectDate = new System.Windows.Forms.CheckBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dtInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.cmbDeliveryType = new System.Windows.Forms.ComboBox();
            this.cmbCargo = new System.Windows.Forms.ComboBox();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpInvoicesList = new System.Windows.Forms.GroupBox();
            this.dgvInvoices = new System.Windows.Forms.DataGridView();
            this.grpInvoiceDetails.SuspendLayout();
            this.grpInvoicesList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).BeginInit();
            this.SuspendLayout();
            // 
            // grpInvoiceDetails
            // 
            this.grpInvoiceDetails.Controls.Add(this.chkCorrectDate);
            this.grpInvoiceDetails.Controls.Add(this.txtAmount);
            this.grpInvoiceDetails.Controls.Add(this.btnClear);
            this.grpInvoiceDetails.Controls.Add(this.btnGenerate);
            this.grpInvoiceDetails.Controls.Add(this.dtInvoiceDate);
            this.grpInvoiceDetails.Controls.Add(this.cmbDeliveryType);
            this.grpInvoiceDetails.Controls.Add(this.cmbCargo);
            this.grpInvoiceDetails.Controls.Add(this.cmbCustomer);
            this.grpInvoiceDetails.Controls.Add(this.label5);
            this.grpInvoiceDetails.Controls.Add(this.label4);
            this.grpInvoiceDetails.Controls.Add(this.label3);
            this.grpInvoiceDetails.Controls.Add(this.label2);
            this.grpInvoiceDetails.Controls.Add(this.label1);
            this.grpInvoiceDetails.Location = new System.Drawing.Point(38, 25);
            this.grpInvoiceDetails.Name = "grpInvoiceDetails";
            this.grpInvoiceDetails.Size = new System.Drawing.Size(453, 614);
            this.grpInvoiceDetails.TabIndex = 0;
            this.grpInvoiceDetails.TabStop = false;
            this.grpInvoiceDetails.Text = "Invoice Details";
            // 
            // chkCorrectDate
            // 
            this.chkCorrectDate.AutoSize = true;
            this.chkCorrectDate.Location = new System.Drawing.Point(29, 470);
            this.chkCorrectDate.Name = "chkCorrectDate";
            this.chkCorrectDate.Size = new System.Drawing.Size(126, 24);
            this.chkCorrectDate.TabIndex = 13;
            this.chkCorrectDate.Text = "Correct Date";
            this.chkCorrectDate.UseVisualStyleBackColor = true;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(166, 212);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(225, 26);
            this.txtAmount.TabIndex = 12;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(300, 555);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(147, 37);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(38, 555);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(206, 37);
            this.btnGenerate.TabIndex = 10;
            this.btnGenerate.Text = "Generate Invoice";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // dtInvoiceDate
            // 
            this.dtInvoiceDate.Location = new System.Drawing.Point(167, 363);
            this.dtInvoiceDate.Name = "dtInvoiceDate";
            this.dtInvoiceDate.Size = new System.Drawing.Size(238, 26);
            this.dtInvoiceDate.TabIndex = 9;
            // 
            // cmbDeliveryType
            // 
            this.cmbDeliveryType.FormattingEnabled = true;
            this.cmbDeliveryType.Location = new System.Drawing.Point(167, 280);
            this.cmbDeliveryType.Name = "cmbDeliveryType";
            this.cmbDeliveryType.Size = new System.Drawing.Size(225, 28);
            this.cmbDeliveryType.TabIndex = 8;
            // 
            // cmbCargo
            // 
            this.cmbCargo.FormattingEnabled = true;
            this.cmbCargo.Location = new System.Drawing.Point(167, 135);
            this.cmbCargo.Name = "cmbCargo";
            this.cmbCargo.Size = new System.Drawing.Size(225, 28);
            this.cmbCargo.TabIndex = 7;
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(167, 79);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(225, 28);
            this.cmbCustomer.TabIndex = 6;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 363);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Invoice Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Delivery Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Amount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cargo / Tracking No:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer:";
            // 
            // grpInvoicesList
            // 
            this.grpInvoicesList.Controls.Add(this.dgvInvoices);
            this.grpInvoicesList.Location = new System.Drawing.Point(517, 25);
            this.grpInvoicesList.Name = "grpInvoicesList";
            this.grpInvoicesList.Size = new System.Drawing.Size(483, 628);
            this.grpInvoicesList.TabIndex = 1;
            this.grpInvoicesList.TabStop = false;
            this.grpInvoicesList.Text = "Invoices List";
            // 
            // dgvInvoices
            // 
            this.dgvInvoices.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoices.Location = new System.Drawing.Point(16, 39);
            this.dgvInvoices.Name = "dgvInvoices";
            this.dgvInvoices.RowHeadersWidth = 62;
            this.dgvInvoices.RowTemplate.Height = 28;
            this.dgvInvoices.Size = new System.Drawing.Size(427, 519);
            this.dgvInvoices.TabIndex = 0;
            this.dgvInvoices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoices_CellClick);
            // 
            // Invoice_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1012, 656);
            this.Controls.Add(this.grpInvoicesList);
            this.Controls.Add(this.grpInvoiceDetails);
            this.Name = "Invoice_Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice_Management";
            this.grpInvoiceDetails.ResumeLayout(false);
            this.grpInvoiceDetails.PerformLayout();
            this.grpInvoicesList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInvoiceDetails;
        private System.Windows.Forms.ComboBox cmbDeliveryType;
        private System.Windows.Forms.ComboBox cmbCargo;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpInvoicesList;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DateTimePicker dtInvoiceDate;
        private System.Windows.Forms.CheckBox chkCorrectDate;
        private System.Windows.Forms.DataGridView dgvInvoices;
    }
}