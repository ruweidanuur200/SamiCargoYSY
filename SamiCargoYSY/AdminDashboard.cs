using System;
using System.Windows.Forms;

namespace SamiCargoYSY
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        // ================= USER MANAGEMENT =================
        private void btnUser_Click(object sender, EventArgs e)
        {
            UserManagementForm usersForm = new UserManagementForm();
            usersForm.ShowDialog();



           
        }

        // ================= CUSTOMERS =================
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CustomerManagementForm customersForm = new CustomerManagementForm();
            customersForm.ShowDialog();
        }

        // ================= INVOICES =================
        private void btnInvoice_Click(object sender, EventArgs e)
        {
            Invoice_Management invoiceForm = new Invoice_Management();
            invoiceForm.Show();
        }

        // ================= TRACKING =================
        private void btnTracking_Click(object sender, EventArgs e)
        {
            TrackingForm tf = new TrackingForm();
            tf.ShowDialog(); // modal (recommended)
        }

        // ================= CARGO =================
        private void btnCargo_Click(object sender, EventArgs e)
        {
            CargoManagementForm cargoForm = new CargoManagementForm();
            cargoForm.Show();
            this.Hide(); 
        }

        // ================= REPORTS =================
        private void btnReports_Click(object sender, EventArgs e)
        {
            REPORTS rpt = new REPORTS();
            rpt.ShowDialog();   // modal window
        }

        // ================= LOGOUT (BOTTOM BUTTON) =================
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.Show();
            }
        }

        // ================= DASHBOARD (SIDEBAR) =================
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "You are already on the Dashboard",
                "Info",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // ================= LOGOUT (SIDEBAR) =================
        private void btnLogoutSide_Click(object sender, EventArgs e)
        {
            btnLogout_Click(sender, e);
        }
    }
}