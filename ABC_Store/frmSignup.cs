using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC_Store
{
    public partial class frmSignup : Form
    {
        public frmSignup()
        {
            InitializeComponent();
        }

        private void frmSignup_Load(object sender, EventArgs e)
        {

        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            // Get values ​​from input cells
            string fullName = txtFullName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string password = txtPass.Text;

            // Check if input fields are not empty
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all information.");
            }
            else
            {
                // Perform registration
                MessageBox.Show($"Congratulations {fullName}, You have successfully registered!");
                this.Close();  // Close registration form after success
            }

            frmABCStoreManagement abcStoreManagementForm = new frmABCStoreManagement();
            abcStoreManagementForm.Show();
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmWelcome welcomeForm = new frmWelcome();
            welcomeForm.Show();
            this.Hide();
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
