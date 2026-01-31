using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SamiCargoYSY
{
    public partial class UserManagementForm : Form
    {
        string conStr = @"Data Source=DESKTOP-DT9O51H\SQLEXPRESS;
                          Initial Catalog=SamiCargoDB;
                          Integrated Security=True";

        int selectedUserId = -1;

        public UserManagementForm()
        {
            InitializeComponent();

            cmbRole.Items.Clear();
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Staff");

            LoadUsers();
        }

        // ================= LOAD USERS =================
        private void LoadUsers()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT UserId, Username, Role, IsActive FROM Users", con);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvUsers.DataSource = dt;
            }
        }

        // ================= ADD USER =================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "" ||
        txtPassword.Text.Trim() == "" ||
        cmbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Users 
              (FullName, Username, PasswordHash, Role, IsActive)
              VALUES (@f, @u, @p, @r, 1)", con);

                // ✅ TEMP SOLUTION: use Username as FullName
                cmd.Parameters.AddWithValue("@f", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@u", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@p", txtPassword.Text.Trim());
                cmd.Parameters.AddWithValue("@r", cmbRole.Text);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("User added successfully");

            ClearFields();
            LoadUsers();}

        // ================= UPDATE USER =================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Select a user first");
                return;
            }

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Users SET Username=@u, Role=@r WHERE UserId=@id", con);

                cmd.Parameters.AddWithValue("@u", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@r", cmbRole.Text);
                cmd.Parameters.AddWithValue("@id", selectedUserId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("User updated successfully");
            ClearFields();
            LoadUsers();
        }

        // ================= DEACTIVATE USER =================
        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Select a user first");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to deactivate this user?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Users SET IsActive = 0 WHERE UserId = @id", con);

                cmd.Parameters.AddWithValue("@id", selectedUserId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("User deactivated successfully");
            ClearFields();
            LoadUsers();
        }

        // ================= GRID ROW CLICK =================
        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];

                selectedUserId = Convert.ToInt32(row.Cells["UserId"].Value);
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                cmbRole.Text = row.Cells["Role"].Value.ToString();
            }
        }

        // ================= CLEAR =================
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            cmbRole.SelectedIndex = -1;
            selectedUserId = -1;
        }
    }
}