using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC_Store
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private SqlConnection ConnectToDatabase()
        {

            string connectionString = "Data Source=MSI\\PHUONGVY;Initial Catalog=ABC_Store_Management;Integrated Security=True";
            return new SqlConnection(connectionString);
        }

      
        private bool CheckLogin(string username, string password)
        {
            using (SqlConnection conn = ConnectToDatabase())
            {
                conn.Open();
                string query = "SELECT * FROM [USERS] WHERE name = @Name AND pass = @Pass";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", username);
                cmd.Parameters.AddWithValue("@Pass", password);

                SqlDataReader reader = cmd.ExecuteReader();
                return reader.HasRows;
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPass.Text;

            if (CheckLogin(username, password))
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Open frmMain form when login is successful
                frmABCStoreManagement abcStoreManagementForm = new frmABCStoreManagement();
                abcStoreManagementForm.Show();

                // Hide login form (LoginForm)
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmWelcome welcomeForm = new frmWelcome();
            welcomeForm.Show();
            this.Hide();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            frmWelcome welcomeForm = new frmWelcome();
            welcomeForm.Show();
            this.Hide();
        }
    }
}
