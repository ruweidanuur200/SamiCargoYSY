using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SamiCargoYSY
{
    public partial class StafDashboard : Form
    {
        string conStr = @"Data Source=DESKTOP-DT9O51H\SQLEXPRESS;
                          Initial Catalog=SamiCargoDB;
                          Integrated Security=True";

        public StafDashboard()
        {
            InitializeComponent();
            LoadTodayCargo();
        }

        // ================= LOAD DATA FOR STAFF GRID =================
        private void LoadTodayCargo()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT 
                        C.TrackingNumber,
                        CU.FirstName + ' ' + CU.LastName AS Customer,
                        C.Status,
                        C.DeliveryType,
                        C.CreatedAt
                      FROM Cargo C
                      INNER JOIN Customers CU ON C.CustomerId = CU.CustomerId
                      ORDER BY C.CreatedAt DESC", con);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStaff.DataSource = dt;
            }
        }

        // ================= TRACKING =================
        private void btnTracking_Click(object sender, EventArgs e)
        {
            TrackingForm t = new TrackingForm();
            t.ShowDialog();
        }

        // ================= VIEW INVOICES (READ ONLY) =================
        private void btnInvoices_Click(object sender, EventArgs e)
        {
            Invoice_Management inv = new Invoice_Management();
            inv.IsStaffMode = true; // IMPORTANT
            inv.ShowDialog();
        }

        // ================= CARGO STATUS (READ ONLY) =================
        private void btnCargoStatus_Click(object sender, EventArgs e)
        {
            CargoManagementForm cargo = new CargoManagementForm();
            cargo.IsStaffMode = true; // IMPORTANT
            cargo.ShowDialog();
        }

        // ================= LOGOUT =================
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Logout?", "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Login l = new Login();
                l.Show();
            }
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Staff only views data – no edit
        }
    }
}