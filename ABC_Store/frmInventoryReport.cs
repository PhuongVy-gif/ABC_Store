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
    public partial class frmInventoryReport : Form
    {
        public frmInventoryReport()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          

        }

        private void btnRevenueReport_Click(object sender, EventArgs e)
        {
            frmRevenueReport revenueReportForm = new frmRevenueReport();
            revenueReportForm.Show();
            this.Hide();
        }
        string connectionString = "Data Source=MSI\\PHUONGVY;Initial Catalog=ABC_Store_Management;Integrated Security=True";
        private void LoadStockDataToListView(ListView ListView)
        {
            // Chuỗi kết nối SQL Server
            string connectionString = "Data Source=MSI\\PHUONGVY;Initial Catalog=ABC_Store_Management;Integrated Security=True";

            // Truy vấn SQL
            string query = @"
        SELECT 
            ClothingName, 
            Price,
            StockQuantity
            
        FROM Clothing
        ORDER BY StockQuantity DESC;
    ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open(); // Open connection
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    lvViewStock.Items.Clear();// Delete old data in ListView

                    // Load data from SQL Server into ListView
                    while (reader.Read())
                    {
                        // Get data from columns ClothingName, StockQuantity, Price
                        string clothingName = reader["ClothingName"].ToString();
                        string price = string.Format("{0:N0} VND", Convert.ToDecimal(reader["Price"]));
                        string stockQuantity = reader["StockQuantity"].ToString();
                        

                        ListViewItem item = new ListViewItem(clothingName); 
                        item.SubItems.Add(price);                          
                        item.SubItems.Add(stockQuantity);                 
                        

                        lvViewStock.Items.Add(item); 
                    }

                    reader.Close(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnInventoryReport_Click(object sender, EventArgs e)
        {
            LoadStockDataToListView(lvViewStock); // Load data into ListView when button is pressed
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frmSaleReport saleReportForm = new frmSaleReport();
            saleReportForm.Show();
            this.Hide();
        }
       

        private void lvViewRevenueReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvViewStock.View = View.Details;         
            lvViewStock.FullRowSelect = true;       
            lvViewStock.GridLines = true;          
            lvViewStock.Columns.Clear();            

            // Thêm cột vào ListView
            lvViewStock.Columns.Add("Clothing Name", 200);   
            lvViewStock.Columns.Add("Price (VND)", 150);     
            lvViewStock.Columns.Add("Stock Quantity", 150);  
            
        }

        private void frmInventoryReport_Load(object sender, EventArgs e)
        {
            // SQL statement to get data
            string query = "SELECT ClothingName,Price, StockQuantity  FROM Clothing";

          
            lvViewStock.Items.Clear();

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
                        
                        ListViewItem item = new ListViewItem(reader["ClothingID"].ToString());
                        item.SubItems.Add(reader["ClothingName"].ToString());
                        item.SubItems.Add(reader["Price"].ToString());
                        item.SubItems.Add(reader["StockQuantity"].ToString());
                      
                        
                     

                        
                        lvViewStock.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Success " + ex.Message);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
