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
    public partial class frmRevenueReport : Form
    {
        public frmRevenueReport()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        string connectionString = "Data Source=MSI\\PHUONGVY;Initial Catalog=ABC_Store_Management;Integrated Security=True";
        public void LoadDailyRevenueReport(ListView listView)
        {
            string connectionString = "Data Source=MSI\\PHUONGVY;Initial Catalog=ABC_Store_Management;Integrated Security=True"; // Chuỗi kết nối đến SQL Server
                                                                                                                                 // Câu lệnh SQL để lấy báo cáo doanh thu theo ngày
            string query = @"
        SELECT 
            CONVERT(DATE, BillDate) AS BillDate, 
            SUM(TotalAmount) AS TotalRevenue
        FROM Bill
        GROUP BY CONVERT(DATE, BillDate)
        ORDER BY BillDate;
    ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open(); 
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                 
                    listView.Items.Clear();

                    
                    while (reader.Read())
                    {
                        
                        string date = Convert.ToDateTime(reader["BillDate"]).ToString("yyyy-MM-dd");
                        string totalRevenue = string.Format("{0:N0} VND", Convert.ToDecimal(reader["TotalRevenue"]));

                        
                        ListViewItem item = new ListViewItem(date);
                        item.SubItems.Add(totalRevenue);

                        
                        listView.Items.Add(item);
                    }

                    reader.Close(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message); // Display errors if any
                }
            }
        }

        private void LoadSalesReport(DateTime startDate, DateTime endDate)
        {
           
        }
        

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void btnRevenueReport_Click(object sender, EventArgs e)
        {
            LoadDailyRevenueReport(lvViewRevenueReport);

        }

        private void btnInventoryReport_Click(object sender, EventArgs e)
        {
            frmInventoryReport inventoryReportForm = new frmInventoryReport();
            inventoryReportForm.Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frmSaleReport saleReportForm = new frmSaleReport();
            saleReportForm.Show();
            this.Hide();
        }

        private void lvViewRevenueReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            lvViewRevenueReport.View = View.Details;
            lvViewRevenueReport.FullRowSelect = true;  
            lvViewRevenueReport.GridLines = true;     
            lvViewRevenueReport.Columns.Clear();      

           
            lvViewRevenueReport.Columns.Add("Date", 150);          
            lvViewRevenueReport.Columns.Add("Total Revenue", 200); 
            
        }

        private void frmRevenueReport_Load(object sender, EventArgs e)
        {

            // SQL statement to get data
            string query = "SELECT BillDate, TotalAmount FROM Bill";

            // Delete old items in ListView
            lvViewRevenueReport.Items.Clear();

            // Connection string to the database
            string connectionString = "Data Source=MSI\\PHUONGVY;Initial Catalog=ABC_Store_Management;Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionString);
            {
                SqlCommand command = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // Create a new ListViewItem
                        ListViewItem item = new ListViewItem(reader["BillID"].ToString());
                
                        item.SubItems.Add(Convert.ToDateTime(reader["BillDate"]).ToString("yyyy-MM-dd")); // Format the date if necessary
                        item.SubItems.Add(reader["TotalAmount"].ToString());



                        // Add item to ListView
                        lvViewRevenueReport.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Successfully accessed Manage Bill page ");
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            
        }
    }
    
}

      
    
    

