using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SamiCargoYSY
{
    public partial class Invoice_Management : Form
    {
        public bool IsStaffMode = false;

        string conStr = @"Data Source=DESKTOP-DT9O51H\SQLEXPRESS;
                          Initial Catalog=SamiCargoDB;
                          Integrated Security=True";

        int selectedInvoiceId = -1;

        public Invoice_Management()
        {
            InitializeComponent();
            LoadCustomers();
            LoadDeliveryTypes();
            LoadInvoices();
        }

        // ================= LOAD CUSTOMERS =================
        private void LoadCustomers()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT 
                        CustomerId,
                        FirstName + ' ' + LastName AS CustomerName
                      FROM Customers", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbCustomer.DataSource = dt;
                cmbCustomer.DisplayMember = "CustomerName";
                cmbCustomer.ValueMember = "CustomerId";
                cmbCustomer.SelectedIndex = -1;
            }
        }

        // ================= LOAD CARGO BY CUSTOMER =================
        private void LoadCargoByCustomer(int customerId)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT 
                        CargoId,
                        TrackingNumber
                      FROM Cargo
                      WHERE CustomerId = @cid", con);

                da.SelectCommand.Parameters.AddWithValue("@cid", customerId);

                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbCargo.DataSource = dt;
                cmbCargo.DisplayMember = "TrackingNumber";
                cmbCargo.ValueMember = "CargoId";
                cmbCargo.SelectedIndex = -1;
            }
        }

        // ================= DELIVERY TYPES =================
        private void LoadDeliveryTypes()
        {
            cmbDeliveryType.Items.Clear();
            cmbDeliveryType.Items.Add("Air");
            cmbDeliveryType.Items.Add("Sea");
            cmbDeliveryType.Items.Add("Land");
            cmbDeliveryType.SelectedIndex = -1;
        }

        // ================= LOAD INVOICES =================
        private void LoadInvoices()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT 
                        I.InvoiceId,
                        (C.FirstName + ' ' + C.LastName) AS Customer,
                        I.CargoTrackingNo,
                        I.DeliveryType,
                        I.Amount,
                        I.InvoiceDate,
                        I.IsPaid
                      FROM Invoices I
                      INNER JOIN Customers C 
                          ON I.CustomerId = C.CustomerId", con);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvInvoices.DataSource = dt;
            }
        }

        // ================= GENERATE INVOICE =================
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex == -1 ||
                cmbCargo.SelectedIndex == -1 ||
                cmbDeliveryType.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                MessageBox.Show("Please fill all required fields");
                return;
            }

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Invoices
                      (CustomerId, CargoId, CargoTrackingNo, DeliveryType, Amount, InvoiceDate, IsPaid)
                      VALUES (@cid, @cargoId, @tracking, @dtype, @amt, @date, 0)", con);

                cmd.Parameters.AddWithValue("@cid", cmbCustomer.SelectedValue);
                cmd.Parameters.AddWithValue("@cargoId", cmbCargo.SelectedValue);
                cmd.Parameters.AddWithValue("@tracking", cmbCargo.Text);
                cmd.Parameters.AddWithValue("@dtype", cmbDeliveryType.Text);
                cmd.Parameters.AddWithValue("@amt", decimal.Parse(txtAmount.Text));
                cmd.Parameters.AddWithValue("@date", dtInvoiceDate.Value.Date);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Invoice generated successfully");
            ClearFields();
            LoadInvoices();
        }

        // ================= GRID CLICK =================
        private void dgvInvoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvInvoices.Rows[e.RowIndex];

            selectedInvoiceId = Convert.ToInt32(row.Cells["InvoiceId"].Value);
            cmbCustomer.Text = row.Cells["Customer"].Value.ToString();
            cmbCargo.Text = row.Cells["CargoTrackingNo"].Value.ToString();
            cmbDeliveryType.Text = row.Cells["DeliveryType"].Value.ToString();
            txtAmount.Text = row.Cells["Amount"].Value.ToString();
            dtInvoiceDate.Value = Convert.ToDateTime(row.Cells["InvoiceDate"].Value);
        }

        // ================= CUSTOMER CHANGE =================
        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedValue == null)
                return;

            if (cmbCustomer.SelectedValue is DataRowView)
                return;

            int customerId = Convert.ToInt32(cmbCustomer.SelectedValue);
            LoadCargoByCustomer(customerId);
        }

        // ================= CLEAR =================
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            cmbCustomer.SelectedIndex = -1;
            cmbCargo.DataSource = null;
            cmbDeliveryType.SelectedIndex = -1;
            txtAmount.Clear();
            dtInvoiceDate.Value = DateTime.Now;
            selectedInvoiceId = -1;
        }
        private void Invoice_Management_Load(object sender, EventArgs e)
        {
            if (IsStaffMode)
            {
                btnGenerate.Enabled = false;
            }
        }
    }
}