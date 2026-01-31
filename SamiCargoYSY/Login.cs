using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SamiCargoYSY
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            // Fill roles
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Staff");
            cmbRole.SelectedIndex = 0;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Nothing needed here
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = cmbRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please enter username, password and role",
                                "Missing Data",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(
                    @"Data Source=DESKTOP-DT9O51H\SQLEXPRESS;
                      Initial Catalog=SamiCargoDB;
                      Integrated Security=True"))
                {
                    string query = @"
                        SELECT COUNT(*) 
                        FROM Users
                        WHERE Username = @u
                          AND PasswordHash = @p
                          AND Role = @r
                          AND IsActive = 1";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", password);
                    cmd.Parameters.AddWithValue("@r", role);

                    con.Open();
                    int result = (int)cmd.ExecuteScalar();

                    if (result == 1)
                    {
                        // ✅ LOGIN OK
                        this.Hide();

                        if (role == "Admin")
                        {
                            AdminDashboard admin = new AdminDashboard();
                            admin.FormClosed += (s, args) => this.Close();
                            admin.Show();
                        }
                        else if (role == "Staff")
                        {
                            StafDashboard staff = new StafDashboard();
                            staff.FormClosed += (s, args) => this.Close();
                            staff.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password",
                                        "Login Failed",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error:\n" + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}