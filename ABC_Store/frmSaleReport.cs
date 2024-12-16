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
    public partial class frmSaleReport : Form
    {
        public frmSaleReport()
        {
            InitializeComponent();
        }

        private void btnRevenueReport_Click(object sender, EventArgs e)
        {
            frmRevenueReport revenueReportForm = new frmRevenueReport();
            revenueReportForm.Show();
            this.Hide();
        }

        private void btnInventoryReport_Click(object sender, EventArgs e)
        {
            frmInventoryReport inventoryReportForm = new frmInventoryReport();
            inventoryReportForm.Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frmABCStoreManagement abcStoreManagementForm = new frmABCStoreManagement();
            abcStoreManagementForm.Show();
            this.Hide();
        }
    }
}
