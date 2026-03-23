using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MIDTERM_SALON
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // This is the ONLY place your logic should live
        private void button1_Click(object sender, EventArgs e)
        {
            // Database is MIDTERM_DB, Table is SALON_DB
            string connectionString = @"Data Source=ANDREW\SQLEXPRESS;Initial Catalog=MIDTERM_DB;Integrated Security=True";
            string query = "INSERT INTO SALON_DB (Name, Email, ContactNumber) VALUES (@Name, @Email, @Contact)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // These names must match the (Name) property in the Designer
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Contact", txtContact.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("The SALON is already booked!");

                    // Clear the boxes
                    txtName.Clear();
                    txtEmail.Clear();
                    txtContact.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}