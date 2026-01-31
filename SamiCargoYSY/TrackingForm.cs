using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SamiCargoYSY
{
    public partial class TrackingForm : Form
    {
        string conStr = @"Data Source=DESKTOP-DT9O51H\SQLEXPRESS;
                          Initial Catalog=SamiCargoDB;
                          Integrated Security=True";

        public TrackingForm()
        {
            InitializeComponent();
        }

        // ================= SEARCH BUTTON =================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTrackingNumber.Text))
            {
                MessageBox.Show("Please enter tracking number");
                return;
            }

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(
                    @"SELECT 
                        C.TrackingNumber,
                        CU.FirstName + ' ' + CU.LastName AS Customer,
                        C.FromAddress,
                        C.ToAddress,
                        C.Status,
                        C.DeliveryType
                      FROM Cargo C
                      INNER JOIN Customers CU 
                        ON C.CustomerId = CU.CustomerId
                      WHERE C.TrackingNumber = @track", con);

                cmd.Parameters.AddWithValue("@track", txtTrackingNumber.Text.Trim());

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtDTracking.Text = dr["TrackingNumber"].ToString();
                    lblCustomer.Text = dr["Customer"].ToString();
                    lblFrom.Text = dr["FromAddress"].ToString();
                    lblTo.Text = dr["ToAddress"].ToString();
                    lblStatus.Text = dr["Status"].ToString();
                    lblDeliveryType.Text = dr["DeliveryType"].ToString();
                }
                else
                {
                    MessageBox.Show("Tracking number not found");
                    ClearDetails();
                }
            }
        }

        // ================= CLEAR DETAILS =================
        private void ClearDetails()
        {
            txtDTracking.Text = "";
            lblCustomer.Text = "";
            lblFrom.Text = "";
            lblTo.Text = "";
            lblStatus.Text = "";
            lblDeliveryType.Text = "";
        }

        // ================= OK BUTTON =================
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}