using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SamiCargoYSY
{
    public partial class REPORTS : Form
    {
        string conStr = @"Data Source=DESKTOP-DT9O51H\SQLEXPRESS;
                          Initial Catalog=SamiCargoDB;
                          Integrated Security=True";

        public REPORTS()
        {
            InitializeComponent();
            LoadCustomers();
            SetupGrid();
        }

        // ================= LOAD CUSTOMERS =================
        private void LoadCustomers()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT CustomerId,
                             FirstName + ' ' + LastName AS CustomerName
                      FROM Customers", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                // Add "All"
                DataRow row = dt.NewRow();
                row["CustomerId"] = 0;
                row["CustomerName"] = "All";
                dt.Rows.InsertAt(row, 0);

                cmbCustomer.DataSource = dt;
                cmbCustomer.DisplayMember = "CustomerName";
                cmbCustomer.ValueMember = "CustomerId";
                cmbCustomer.SelectedIndex = 0;
            }
        }

        // ================= GRID SETUP =================
        private void SetupGrid()
        {
            dgvReport.AutoGenerateColumns = true;
            dgvReport.ReadOnly = true;
            dgvReport.AllowUserToAddRows = false;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ================= GENERATE REPORT =================
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query =
                @"SELECT
                    C.TrackingNumber     AS [Cargo Number],
                    CU.FirstName + ' ' + CU.LastName AS [Customer],
                    C.Status             AS [Status],
                    ISNULL(I.Amount,0)   AS [Amount],
                    I.InvoiceDate        AS [Date]
                  FROM Cargo C
                  INNER JOIN Customers CU ON C.CustomerId = CU.CustomerId
                  LEFT JOIN Invoices I ON C.TrackingNumber = I.CargoTrackingNo
                  WHERE C.CreatedAt BETWEEN @from AND @to";

                if (Convert.ToInt32(cmbCustomer.SelectedValue) != 0)
                {
                    query += " AND CU.CustomerId = @cid";
                }

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@from", dtFrom.Value.Date);
                cmd.Parameters.AddWithValue("@to", dtTo.Value.Date.AddDays(1));

                if (Convert.ToInt32(cmbCustomer.SelectedValue) != 0)
                {
                    cmd.Parameters.AddWithValue("@cid", cmbCustomer.SelectedValue);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvReport.DataSource = dt;

                if (dt.Rows.Count == 0)
                    MessageBox.Show("No records found");
            }
        }

        // ================= EXPORT CSV =================
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvReport.Rows.Count == 0)
            {
                MessageBox.Show("Nothing to export");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV File|*.csv";
            sfd.FileName = "Cargo_Report.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();

                // Headers
                foreach (DataGridViewColumn col in dgvReport.Columns)
                {
                    sb.Append(col.HeaderText + ",");
                }
                sb.AppendLine();

                // Rows
                foreach (DataGridViewRow row in dgvReport.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        sb.Append(cell.Value?.ToString() + ",");
                    }
                    sb.AppendLine();
                }

                File.WriteAllText(sfd.FileName, sb.ToString());
                MessageBox.Show("Report exported successfully");
            }
        }

        // ================= CLOSE =================
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvReport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvReport.Rows[e.RowIndex];

            // Example: show selected row info (optional)
            string cargoNo = row.Cells["Cargo Number"].Value?.ToString();
            string customer = row.Cells["Customer"].Value?.ToString();
            string status = row.Cells["Status"].Value?.ToString();
            string amount = row.Cells["Amount"].Value?.ToString();

            MessageBox.Show(
                $"Cargo: {cargoNo}\nCustomer: {customer}\nStatus: {status}\nAmount: {amount}",
                "Selected Report Row",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}