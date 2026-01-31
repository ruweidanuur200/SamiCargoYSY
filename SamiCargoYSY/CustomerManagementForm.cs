using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SamiCargoYSY
{
    public partial class CustomerManagementForm : Form
    {
        string conStr = @"Data Source=DESKTOP-DT9O51H\SQLEXPRESS;
                          Initial Catalog=SamiCargoDB;
                          Integrated Security=True";

        int selectedCustomerId = -1;

        public CustomerManagementForm()
        {
            InitializeComponent();
            LoadCustomers();
        }

        // ================= LOAD CUSTOMERS =================
        private void LoadCustomers()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT 
                        CustomerId,
                        FirstName,
                        LastName,
                        Email,
                        Phone,
                        Address
                      FROM Customers", con);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCustomers.DataSource = dt;

                if (dgvCustomers.Columns["Address"] != null)
                    dgvCustomers.Columns["Address"].Visible = false;
            }
        }

        // ================= VALIDATION =================
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First Name is required");
                txtFirstName.Focus();
                return false;
            }

            if (!Regex.IsMatch(txtFirstName.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("First Name must contain letters only");
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Last Name is required");
                txtLastName.Focus();
                return false;
            }

            if (!Regex.IsMatch(txtLastName.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Last Name must contain letters only");
                txtLastName.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text) &&
                !Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Invalid email format");
                txtEmail.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtPhone.Text) &&
                !Regex.IsMatch(txtPhone.Text, @"^[0-9]{7,15}$"))
            {
                MessageBox.Show("Phone must contain numbers only (7–15 digits)");
                txtPhone.Focus();
                return false;
            }

            return true;
        }

        // ================= ADD =================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Customers 
                      (FirstName, LastName, Email, Phone, Address)
                      VALUES (@fn,@ln,@em,@ph,@ad)", con);

                cmd.Parameters.AddWithValue("@fn", txtFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@ln", txtLastName.Text.Trim());
                cmd.Parameters.AddWithValue("@em", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@ph", txtPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@ad", txtAddress.Text.Trim());

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Customer added successfully");
            ClearFields();
            LoadCustomers();
        }

        // ================= UPDATE =================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == -1)
            {
                MessageBox.Show("Select a customer first");
                return;
            }

            if (!ValidateInputs()) return;

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(
                    @"UPDATE Customers 
                      SET FirstName=@fn, LastName=@ln, Email=@em, Phone=@ph, Address=@ad
                      WHERE CustomerId=@id", con);

                cmd.Parameters.AddWithValue("@fn", txtFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@ln", txtLastName.Text.Trim());
                cmd.Parameters.AddWithValue("@em", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@ph", txtPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@ad", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@id", selectedCustomerId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Customer updated");
            ClearFields();
            LoadCustomers();
        }

        // ================= DELETE =================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == -1)
            {
                MessageBox.Show("Select a customer first");
                return;
            }

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand checkCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Cargo WHERE CustomerId=@id", con);

                checkCmd.Parameters.AddWithValue("@id", selectedCustomerId);
                con.Open();

                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (count > 0)
                {
                    MessageBox.Show("Customer has cargo records and cannot be deleted");
                    return;
                }
            }

            if (MessageBox.Show("Delete this customer?",
                "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Customers WHERE CustomerId=@id", con);

                cmd.Parameters.AddWithValue("@id", selectedCustomerId);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Customer deleted");
            ClearFields();
            LoadCustomers();
        }

        // ================= GRID CLICK =================
        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
            selectedCustomerId = Convert.ToInt32(row.Cells["CustomerId"].Value);

            txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
            txtLastName.Text = row.Cells["LastName"].Value.ToString();
            txtEmail.Text = row.Cells["Email"].Value.ToString();
            txtPhone.Text = row.Cells["Phone"].Value.ToString();
            txtAddress.Text = row.Cells["Address"].Value.ToString();
        }

        // ================= CLEAR =================
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            selectedCustomerId = -1;
            txtFirstName.Focus();
        }
    }
}