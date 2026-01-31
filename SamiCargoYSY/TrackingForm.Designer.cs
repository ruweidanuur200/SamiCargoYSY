namespace SamiCargoYSY
{
    partial class TrackingForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblTrackingNo = new System.Windows.Forms.Label();
            this.txtTrackingNumber = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.t = new System.Windows.Forms.Label();
            this.c = new System.Windows.Forms.Label();
            this.f = new System.Windows.Forms.Label();
            this.ta = new System.Windows.Forms.Label();
            this.st = new System.Windows.Forms.Label();
            this.dt = new System.Windows.Forms.Label();
            this.txtDTracking = new System.Windows.Forms.Label();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDeliveryType = new System.Windows.Forms.Label();
            this.grpDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(292, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "TRACK SHIPMENT";
            // 
            // lblTrackingNo
            // 
            this.lblTrackingNo.AutoSize = true;
            this.lblTrackingNo.Location = new System.Drawing.Point(95, 100);
            this.lblTrackingNo.Name = "lblTrackingNo";
            this.lblTrackingNo.Size = new System.Drawing.Size(133, 20);
            this.lblTrackingNo.TabIndex = 1;
            this.lblTrackingNo.Text = "Tracking Number:";
            // 
            // txtTrackingNumber
            // 
            this.txtTrackingNumber.Location = new System.Drawing.Point(248, 100);
            this.txtTrackingNumber.Name = "txtTrackingNumber";
            this.txtTrackingNumber.Size = new System.Drawing.Size(355, 26);
            this.txtTrackingNumber.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(627, 90);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(157, 36);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.SteelBlue;
            this.btnOK.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOK.Location = new System.Drawing.Point(368, 627);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(286, 36);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // t
            // 
            this.t.AutoSize = true;
            this.t.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t.Location = new System.Drawing.Point(56, 61);
            this.t.Name = "t";
            this.t.Size = new System.Drawing.Size(193, 26);
            this.t.TabIndex = 0;
            this.t.Text = "Tracking Number";
            // 
            // c
            // 
            this.c.AutoSize = true;
            this.c.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c.Location = new System.Drawing.Point(56, 130);
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(115, 26);
            this.c.TabIndex = 1;
            this.c.Text = "Customer";
            // 
            // f
            // 
            this.f.AutoSize = true;
            this.f.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f.Location = new System.Drawing.Point(56, 203);
            this.f.Name = "f";
            this.f.Size = new System.Drawing.Size(161, 26);
            this.f.TabIndex = 2;
            this.f.Text = "From Address";
            // 
            // ta
            // 
            this.ta.AutoSize = true;
            this.ta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ta.Location = new System.Drawing.Point(56, 276);
            this.ta.Name = "ta";
            this.ta.Size = new System.Drawing.Size(132, 26);
            this.ta.TabIndex = 3;
            this.ta.Text = "To Address";
            // 
            // st
            // 
            this.st.AutoSize = true;
            this.st.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.st.Location = new System.Drawing.Point(56, 336);
            this.st.Name = "st";
            this.st.Size = new System.Drawing.Size(80, 26);
            this.st.TabIndex = 4;
            this.st.Text = "Status";
            // 
            // dt
            // 
            this.dt.AutoSize = true;
            this.dt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt.Location = new System.Drawing.Point(56, 389);
            this.dt.Name = "dt";
            this.dt.Size = new System.Drawing.Size(157, 26);
            this.dt.TabIndex = 5;
            this.dt.Text = "Delivery Type";
            // 
            // txtDTracking
            // 
            this.txtDTracking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDTracking.Location = new System.Drawing.Point(301, 65);
            this.txtDTracking.Name = "txtDTracking";
            this.txtDTracking.Size = new System.Drawing.Size(261, 35);
            this.txtDTracking.TabIndex = 12;
            // 
            // grpDetails
            // 
            this.grpDetails.BackColor = System.Drawing.Color.White;
            this.grpDetails.Controls.Add(this.lblDeliveryType);
            this.grpDetails.Controls.Add(this.lblStatus);
            this.grpDetails.Controls.Add(this.lblTo);
            this.grpDetails.Controls.Add(this.lblFrom);
            this.grpDetails.Controls.Add(this.lblCustomer);
            this.grpDetails.Controls.Add(this.txtDTracking);
            this.grpDetails.Controls.Add(this.dt);
            this.grpDetails.Controls.Add(this.st);
            this.grpDetails.Controls.Add(this.ta);
            this.grpDetails.Controls.Add(this.f);
            this.grpDetails.Controls.Add(this.c);
            this.grpDetails.Controls.Add(this.t);
            this.grpDetails.Location = new System.Drawing.Point(67, 148);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(692, 454);
            this.grpDetails.TabIndex = 4;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Shipment Details";
            // 
            // lblCustomer
            // 
            this.lblCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCustomer.Location = new System.Drawing.Point(301, 130);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(261, 35);
            this.lblCustomer.TabIndex = 13;
            // 
            // lblFrom
            // 
            this.lblFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFrom.Location = new System.Drawing.Point(301, 194);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(261, 35);
            this.lblFrom.TabIndex = 14;
            // 
            // lblTo
            // 
            this.lblTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTo.Location = new System.Drawing.Point(301, 267);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(261, 35);
            this.lblTo.TabIndex = 15;
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Location = new System.Drawing.Point(301, 327);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(261, 35);
            this.lblStatus.TabIndex = 16;
            // 
            // lblDeliveryType
            // 
            this.lblDeliveryType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDeliveryType.Location = new System.Drawing.Point(301, 380);
            this.lblDeliveryType.Name = "lblDeliveryType";
            this.lblDeliveryType.Size = new System.Drawing.Size(261, 35);
            this.lblDeliveryType.TabIndex = 17;
            // 
            // TrackingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(855, 675);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtTrackingNumber);
            this.Controls.Add(this.lblTrackingNo);
            this.Controls.Add(this.label1);
            this.Name = "TrackingForm";
            this.Text = " Track Shipment";
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTrackingNo;
        private System.Windows.Forms.TextBox txtTrackingNumber;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label t;
        private System.Windows.Forms.Label c;
        private System.Windows.Forms.Label f;
        private System.Windows.Forms.Label ta;
        private System.Windows.Forms.Label st;
        private System.Windows.Forms.Label dt;
        private System.Windows.Forms.Label txtDTracking;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblDeliveryType;
        private System.Windows.Forms.Label lblStatus;
    }
}