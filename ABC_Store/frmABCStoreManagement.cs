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
    public partial class frmABCStoreManagement : Form
    {
        public frmABCStoreManagement()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            frmBill billForm = new frmBill();
            billForm.Show();
            this.Hide();
        }

        private void btnClothing_Click(object sender, EventArgs e)
        {
            frmClothing clothingForm = new frmClothing();
            clothingForm.Show();
            this.Hide();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmCustomer customerForm = new frmCustomer();
            customerForm.Show();
            this.Hide();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            frmSupplier supplierForm = new frmSupplier();
            supplierForm.Show();
            this.Hide();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            frmEmployee employeeForm = new frmEmployee();
            employeeForm.Show();
            this.Hide();
        }

        private void btnBillDetail_Click(object sender, EventArgs e)
        {
            frmBillDetail billDetailForm = new frmBillDetail();
            billDetailForm.Show();
            this.Hide();
        }

        private void btnSaleResport_Click(object sender, EventArgs e)
        {
            frmSaleReport saleReportForm = new frmSaleReport();
            saleReportForm.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Confirm logout action with a dialog
            var result = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                // Close the current form (main form) and show the login form
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                this.Hide(); // Hide the main form
            }
        }
    }
}
