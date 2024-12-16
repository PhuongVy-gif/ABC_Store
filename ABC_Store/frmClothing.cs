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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ABC_Store
{
    public partial class frmClothing : Form
    {
        public frmClothing()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
           

        }

        private void frmClothing_Load(object sender, EventArgs e)
        {
            
        }

        private void lvViewClothing_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
          
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
        }
       

        private void lvViewClothing_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lvViewClothing.SelectedItems.Count > 0)
            {
                
                var selectedItem = lvViewClothing.SelectedItems[0];

                
                txtClothingID.Text = selectedItem.SubItems[0].Text;
                txtClothingName.Text = selectedItem.SubItems[1].Text;
                txtPrice.Text = selectedItem.SubItems[2].Text;
                txtStockQuantity.Text = selectedItem.SubItems[3].Text;
                txtSupplierID.Text = selectedItem.SubItems[5].Text;
            }
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            txtClothingID.Clear();
            txtClothingName.Clear();
            txtPrice.Clear();
            txtStockQuantity.Clear();
            txtSupplierID.Clear();

            txtClothingID.Focus();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            frmABCStoreManagement abcStoreManagementForm = new frmABCStoreManagement();
            abcStoreManagementForm.Show();
            this.Hide();
        }

        private void frmClothing_Load_1(object sender, EventArgs e)
        {
            
            string query = "SELECT ClothingID, ClothingName, Price, StockQuantity, SupplierID FROM Clothing";

         
            lvViewClothing.Items.Clear();

            
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

                       
                        decimal price = Convert.ToDecimal(reader["Price"]);
                        string formattedPrice = string.Format("{0:#,##0} VND", price);
                        item.SubItems.Add(formattedPrice);

                        item.SubItems.Add(reader["StockQuantity"].ToString());
                        item.SubItems.Add(reader["SupplierID"].ToString());

                        
                        lvViewClothing.Items.Add(item);
                    }

                    
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (lvViewClothing.SelectedItems.Count > 0)
            {
                
                var selectedItem = lvViewClothing.SelectedItems[0];

                
                selectedItem.SubItems[0].Text = txtClothingID.Text;
                selectedItem.SubItems[1].Text = txtClothingName.Text;
                selectedItem.SubItems[2].Text = txtPrice.Text;
                selectedItem.SubItems[3].Text = txtStockQuantity.Text;
                selectedItem.SubItems[5].Text = txtSupplierID.Text;

               
                string connectionString = "Data Source=MSI\\PHUONGVY;Initial Catalog=ABC_Store_Management;Integrated Security=True";
                string query = "UPDATE Clothing SET ClothingName = @ClothingName, Price = @Price, StockQuantity = @StockQuantity,SupplierID = @SupplierID WHERE ClothingID = @ClothingID";



                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, con);

                    command.Parameters.AddWithValue("@ClothingID", txtClothingID.Text);
                    command.Parameters.AddWithValue("@ClothingName", txtClothingName.Text);
                    command.Parameters.AddWithValue("@Price", Convert.ToDecimal(txtPrice.Text)); // Convert to decimal for Price
                    command.Parameters.AddWithValue("@StockQuantity", Convert.ToInt32(txtStockQuantity.Text)); // Convert to int for StockQuantity
                    command.Parameters.AddWithValue("@SupplierID", txtSupplierID.Text);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Updated successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while updating: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an item to update!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            
            string connectionString = "Data Source=MSI\\PHUONGVY;Initial Catalog=ABC_Store_Management;Integrated Security=True";

            
            string query = "INSERT INTO Clothing (ClothingID, ClothingName, Price, StockQuantity,SupplierID) VALUES (@ClothingID, @ClothingName, @Price, @StockQuantity,@SupplierID)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, con);

            
                command.Parameters.AddWithValue("@ClothingID", txtClothingID.Text);
                command.Parameters.AddWithValue("@ClothingName", txtClothingName.Text);
                command.Parameters.AddWithValue("@Price", Convert.ToDecimal(txtPrice.Text)); // Ensure correct decimal format for Price
                command.Parameters.AddWithValue("@StockQuantity", Convert.ToInt32(txtStockQuantity.Text)); // Ensure correct integer format for StockQuantity       
                command.Parameters.AddWithValue("@SupplierID", txtSupplierID.Text);

                try
                {
                    con.Open();
                    command.ExecuteNonQuery();

                    ListViewItem newItem = new ListViewItem(txtClothingID.Text);
                    newItem.SubItems.Add(txtClothingName.Text);
                    newItem.SubItems.Add(Convert.ToDecimal(txtPrice.Text).ToString("F2")); // Format the price as decimal with 2 places
                    newItem.SubItems.Add(Convert.ToInt32(txtStockQuantity.Text).ToString()); // Format the stock quantity as integer
                    newItem.SubItems.Add(txtSupplierID.Text);
                    lvViewClothing.Items.Add(newItem);


                    MessageBox.Show("New addition successful!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   
                    txtClothingID.Clear();
                    txtClothingName.Clear();
                    txtPrice.Clear();
                    txtStockQuantity.Clear();
                    txtSupplierID.Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding new: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (lvViewClothing.SelectedItems.Count > 0)
            {
                
                var selectedItem = lvViewClothing.SelectedItems[0];
                string selectedClothingID = selectedItem.SubItems[0].Text;

                string connectionString = "Data Source=MSI\\PHUONGVY;Initial Catalog=ABC_Store_Management;Integrated Security=True";

                
                string query = "DELETE FROM Clothing WHERE ClothingID = @ClothingID";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, con);

                    
                    command.Parameters.AddWithValue("@CustomerID", selectedClothingID);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();

                        lvViewClothing.Items.Remove(selectedItem);

                        MessageBox.Show("Deletion successful!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while deleting: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an item to delete!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            // Get search keyword
            string searchKeyword = txtSearch.Text.Trim();

            // Connection string
            string connectionString = "Data Source=MSI\\PHUONGVY;Initial Catalog=ABC_Store_Management;Integrated Security=True";

            // SQL statement to search by Bill name
            string query = "SELECT ClothingID, ClothingName, Price, StockQuantity, SupplierID FROM Clothing WHERE ClothingName LIKE @SearchKeyword";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, con);

                // Add parameters with wildcard %
                command.Parameters.AddWithValue("@SearchKeyword", "%" + searchKeyword + "%");

                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Delete old items in ListView
                    lvViewClothing.Items.Clear();

                    while (reader.Read())
                    {
                        // Create a new ListViewItem
                        ListViewItem item = new ListViewItem(reader["ClothingID"].ToString());
                        item.SubItems.Add(reader["ClothingName"].ToString());
                        item.SubItems.Add(Convert.ToDecimal(reader["Price"]).ToString("F2")); // Format price as decimal with 2 places
                        item.SubItems.Add(Convert.ToInt32(reader["StockQuantity"]).ToString()); // Format stock quantity as integer
                        item.SubItems.Add(reader["SupplierID"].ToString());
                        lvViewClothing.Items.Add(item);

                        lvViewClothing.Items.Add(item);
                    }

                    reader.Close();

                    // Display message if no results found
                    if (lvViewClothing.Items.Count == 0)
                    {
                        MessageBox.Show("No matching results found!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while searching: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
