using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SamiCargoYSY
{
    public partial class CargoManagementForm : Form
    {
        public bool IsStaffMode = false;

        string conStr = @"Data Source=DESKTOP-DT9O51H\SQLEXPRESS;
                          Initial Catalog=SamiCargoDB;
                          Integrated Security=True";

        int selectedCargoId = -1;

        public CargoManagementForm()
        {
            InitializeComponent();

            LoadCustomers();
            LoadServiceTypes();
            LoadSpeedTypes();
            LoadDeliveryTypes();
            LoadStatus();
            GenerateTrackingNumber();
            LoadCargo();
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

                cmbCustomer.DataSource = dt;
                cmbCustomer.DisplayMember = "CustomerName";
                cmbCustomer.ValueMember = "CustomerId";
                cmbCustomer.SelectedIndex = -1;
            }
        }

        // ================= SERVICE TYPE =================
        private void LoadServiceTypes()
        {
            cmbServiceType.Items.Clear();
            cmbServiceType.Items.Add("Standard");
            cmbServiceType.Items.Add("Express");
            cmbServiceType.Items.Add("Economy");
            cmbServiceType.SelectedIndex = 0;
        }

        // ================= SPEED TYPE =================
        private void LoadSpeedTypes()
        {
            cmbSpeedType.Items.Clear();
            cmbSpeedType.Items.Add("Normal");
            cmbSpeedType.Items.Add("Fast");
            cmbSpeedType.Items.Add("Overnight");
            cmbSpeedType.SelectedIndex = 0;
        }

        // ================= DELIVERY TYPE =================
        private void LoadDeliveryTypes()
        {
            cmbDeliveryType.Items.Clear();
            cmbDeliveryType.Items.Add("Office");
            cmbDeliveryType.Items.Add("Home");
            cmbDeliveryType.Items.Add("Warehouse");
            cmbDeliveryType.SelectedIndex = 0;
        }

        // ================= STATUS =================
        private void LoadStatus()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Pending");
            cmbStatus.Items.Add("In Transit");
            cmbStatus.Items.Add("Delivered");
            cmbStatus.SelectedIndex = 0;
        }

        // ================= TRACKING NUMBER =================
        private void GenerateTrackingNumber()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd =
                    new SqlCommand("SELECT ISNULL(MAX(CargoId),0) + 1 FROM Cargo", con);

                con.Open();
                int nextId = Convert.ToInt32(cmd.ExecuteScalar());

                txtTrackingNumber.Text = $"CRG-{DateTime.Now.Year}-{nextId:D5}";
                txtTrackingNumber.ReadOnly = true;
            }
        }

        // ================= LOAD CARGO =================
        private void LoadCargo()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT 
                        C.CargoId,
                        C.TrackingNumber,
                        (CU.FirstName + ' ' + CU.LastName) AS Customer,
                        C.FromAddress,
                        C.ToAddress,
                        C.Quantity,
                        C.ServiceType,
                        C.SpeedType,
                        C.DeliveryType,
                        C.Status,
                        C.CreatedAt
                      FROM Cargo C
                      INNER JOIN Customers CU ON C.CustomerId = CU.CustomerId
                      ORDER BY C.CargoId DESC", con);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCargo.DataSource = dt;
            }
        }

        // ================= ADD CARGO =================
        private void btnAddCargo_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex == -1 ||
        string.IsNullOrWhiteSpace(txtFromAddress.Text) ||
        string.IsNullOrWhiteSpace(txtToAddress.Text))
            {
                MessageBox.Show("Fill all required fields");
                return;
            }

            int createdBy = 1; // 🔥 MUST BE INT (Admin/User ID)

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Cargo
              (TrackingNumber, CustomerId, FromAddress, ToAddress,
               Quantity, ServiceType, SpeedType,
               DeliveryType, Status, CreatedAt, CreatedBy)
              VALUES
              (@track,@cid,@from,@to,@qty,@service,@speed,
               @delivery,@status,GETDATE(),@createdBy)", con);

                cmd.Parameters.AddWithValue("@track", txtTrackingNumber.Text);
                cmd.Parameters.AddWithValue("@cid", cmbCustomer.SelectedValue);
                cmd.Parameters.AddWithValue("@from", txtFromAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@to", txtToAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@qty", numQuantity.Value);
                cmd.Parameters.AddWithValue("@service", cmbServiceType.Text);
                cmd.Parameters.AddWithValue("@speed", cmbSpeedType.Text);
                cmd.Parameters.AddWithValue("@delivery", cmbDeliveryType.Text);
                cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
                cmd.Parameters.AddWithValue("@createdBy", createdBy); // ✅ INT

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Cargo added successfully");
            ClearFields();
            GenerateTrackingNumber();
            LoadCargo();
        }

        // ================= GRID CLICK =================
        private void dgvCargo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvCargo.Rows[e.RowIndex];

            selectedCargoId = Convert.ToInt32(row.Cells["CargoId"].Value);
            txtTrackingNumber.Text = row.Cells["TrackingNumber"].Value.ToString();
            cmbCustomer.Text = row.Cells["Customer"].Value.ToString();
            txtFromAddress.Text = row.Cells["FromAddress"].Value.ToString();
            txtToAddress.Text = row.Cells["ToAddress"].Value.ToString();
            numQuantity.Value = Convert.ToDecimal(row.Cells["Quantity"].Value);
            cmbServiceType.Text = row.Cells["ServiceType"].Value.ToString();
            cmbSpeedType.Text = row.Cells["SpeedType"].Value.ToString();
            cmbDeliveryType.Text = row.Cells["DeliveryType"].Value.ToString();
            cmbStatus.Text = row.Cells["Status"].Value.ToString();
        }

        // ================= UPDATE =================
        private void btnUpdateCargo_Click(object sender, EventArgs e)
        {
            if (selectedCargoId == -1)
            {
                MessageBox.Show("Select a cargo first");
                return;
            }

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(
                    @"UPDATE Cargo SET
                        FromAddress=@from,
                        ToAddress=@to,
                        Quantity=@qty,
                        ServiceType=@service,
                        SpeedType=@speed,
                        DeliveryType=@delivery,
                        Status=@status
                      WHERE CargoId=@id", con);

                cmd.Parameters.AddWithValue("@from", txtFromAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@to", txtToAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@qty", numQuantity.Value);
                cmd.Parameters.AddWithValue("@service", cmbServiceType.Text);
                cmd.Parameters.AddWithValue("@speed", cmbSpeedType.Text);
                cmd.Parameters.AddWithValue("@delivery", cmbDeliveryType.Text);
                cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
                cmd.Parameters.AddWithValue("@id", selectedCargoId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Cargo updated");
            ClearFields();
            LoadCargo();
        }

        // ================= DELETE =================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCargoId == -1)
            {
                MessageBox.Show("Select a cargo first");
                return;
            }

            if (MessageBox.Show("Delete this cargo?", "Confirm",
                MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd =
                    new SqlCommand("DELETE FROM Cargo WHERE CargoId=@id", con);

                cmd.Parameters.AddWithValue("@id", selectedCargoId);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            ClearFields();
            LoadCargo();
        }

        // ================= CLEAR =================
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            GenerateTrackingNumber();
        }

        private void ClearFields()
        {
            cmbCustomer.SelectedIndex = -1;
            txtFromAddress.Clear();
            txtToAddress.Clear();
            numQuantity.Value = 1;
            cmbServiceType.SelectedIndex = 0;
            cmbSpeedType.SelectedIndex = 0;
            cmbDeliveryType.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            selectedCargoId = -1;
        }
        private void CargoManagementForm_Load(object sender, EventArgs e)
        {
            if (IsStaffMode)
            {
                btnAddCargo.Enabled = false;
                btnUpdateCargo.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void brnBack_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
            this.Close();
        }
    }
}