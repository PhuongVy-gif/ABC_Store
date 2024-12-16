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
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            

        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {

        }

        private void lvViewCustomer_SelectedIndexChanged(object sender, EventArgs e)
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

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void lvViewCustomer_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lvViewCustomer.SelectedItems.Count > 0)
            {
                // Get the selected item
                var selectedItem = lvViewCustomer.SelectedItems[0];

                // Display data on TextBoxes
                txtCustomerID.Text = selectedItem.SubItems[0].Text;
                txtCustomerName.Text = selectedItem.SubItems[1].Text;
                txtAddress.Text = selectedItem.SubItems[2].Text;
                txtContactInfo.Text = selectedItem.SubItems[3].Text;
                txtPurchaseHistory.Text = selectedItem.SubItems[4].Text;

            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;

            string query = @"SELECT * 
                     FROM Customer 
                     WHERE CustomerName LIKE '%' + @CustomerName + '%'";
            string connectionString = "Data Source=MSI\\PHUONGVY;Initial Catalog=ABC_Store_Management;Integrated Security=True";


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@CustomerName", keyword);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    lvViewCustomer.Items.Clear();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["CustomerID"].ToString());
                        item.SubItems.Add(row["CustomerName"].ToString());
                        item.SubItems.Add(row["Address"].ToString());
                        item.SubItems.Add(row["ContactInfo"].ToString());
                        lvViewCustomer.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error searching for customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmCustomer_Load_1(object sender, EventArgs e)
        {

            // SQL statement to get data
            string query = "SELECT CustomerID, CustomerName, ContactInfo, Address, PurchaseHistory FROM Customer";

            // Delete old items in ListView
            lvViewCustomer.Items.Clear();

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
                        ListViewItem item = new ListViewItem(reader["CustomerID"].ToString());
                        item.SubItems.Add(reader["CustomerName"].ToString());
                        item.SubItems.Add(reader["Address"].ToString());
                        item.SubItems.Add(reader["ContactInfo"].ToString());
                        item.SubItems.Add(reader["PurchaseHistory"].ToString());

                        
                        lvViewCustomer.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Successfully accessed Manage Customer page ");
                }
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (lvViewCustomer.SelectedItems.Count > 0)
            {
                // Get the selected item
                var selectedItem = lvViewCustomer.SelectedItems[0];
                string selectedCustomerID = selectedItem.SubItems[0].Text;

                // Connection string
                string connectionString = "Data Source=MSI\\PHUONGVY;Initial Catalog=ABC_Store_Management;Integrated Security=True";

                
                string query = "DELETE FROM Customer WHERE CustomerID = @CustomerID";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, con);


                    command.Parameters.AddWithValue("@CustomerID", selectedCustomerID);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();

                      
                        lvViewCustomer.Items.Remove(selectedItem);

                        MessageBox.Show("Deleted successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while deleting: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            // Get search keyword
            string searchKeyword = txtSearch.Text.Trim();

            // Connection string
            string connectionString = "Data Source=MSI\\PHUONGVY;Initial Catalog=ABC_Store_Management;Integrated Security=True";

            // SQL statement to search by customer name
            string query = "SELECT CustomerID, CustomerName, Address, ContactInfo, PurchaseHistory FROM Customer WHERE CustomerName LIKE @SearchKeyword";
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
                    lvViewCustomer.Items.Clear();
                    while (reader.Read())
                    {
                        // Create a new ListViewItem
                        ListViewItem item = new ListViewItem(reader["CustomerID"].ToString());
                        item.SubItems.Add(reader["CustomerName"].ToString());
                        item.SubItems.Add(reader["Address"].ToString());
                        item.SubItems.Add(reader["ContactInfo"].ToString());
                        item.SubItems.Add(reader["PurchaseHistory"].ToString());

                        // Add item to ListView
                        lvViewCustomer.Items.Add(item);
                    }
                    reader.Close();
                    // Display message if no results found
                    if (lvViewCustomer.Items.Count == 0)
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

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            // Connection string
            string connectionString = "Data Source=MSI\\PHUONGVY;Initial Catalog=ABC_Store_Management;Integrated Security=True";

            // SQL statement to add data
            string query = "INSERT INTO Customer (CustomerID, CustomerName, Address, ContactInfo, PurchaseHistory) VALUES (@CustomerID, @CustomerName, @Address, @ContactInfo, @PurchaseHistory)";


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, con);

                // Add parameters
                command.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text);
                command.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                command.Parameters.AddWithValue("@Address", txtAddress.Text);
                command.Parameters.AddWithValue("@ContactInfo", txtContactInfo.Text);
                command.Parameters.AddWithValue("@PurchaseHistory", txtPurchaseHistory.Text);
                try
                {
                    con.Open();
                    command.ExecuteNonQuery();

                    // Add to ListView
                    ListViewItem newItem = new ListViewItem(txtCustomerID.Text);
                    newItem.SubItems.Add(txtCustomerName.Text);
                    newItem.SubItems.Add(txtAddress.Text);
                    newItem.SubItems.Add(txtContactInfo.Text);
                    newItem.SubItems.Add(txtPurchaseHistory.Text);
                    lvViewCustomer.Items.Add(newItem);


                    MessageBox.Show("New addition successful!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Delete TextBoxes after adding
                    txtCustomerID.Clear();
                    txtCustomerName.Clear();
                    txtAddress.Clear();
                    txtContactInfo.Clear();
                    txtPurchaseHistory.Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while adding: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (lvViewCustomer.SelectedItems.Count > 0)
            {
                // Get the selected item
                var selectedItem = lvViewCustomer.SelectedItems[0];

                // Update value in ListView
                selectedItem.SubItems[0].Text = txtCustomerID.Text;
                selectedItem.SubItems[1].Text = txtCustomerName.Text;
                selectedItem.SubItems[3].Text = txtAddress.Text;
                selectedItem.SubItems[2].Text = txtContactInfo.Text;

                selectedItem.SubItems[4].Text = txtPurchaseHistory.Text;


                // Update database
                string connectionString = "Data Source=MSI\\PHUONGVY;Initial Catalog=ABC_Store_Management;Integrated Security=True";

                string query = "UPDATE Customer SET CustomerName = @CustomerName, ContactInfo = @ContactInfo, Address = @Address, PurchaseHistory = @PurchaseHistory WHERE CustomerID = @CustomerID";




                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, con);

                    // Add parameters
                    command.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text);
                    command.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    command.Parameters.AddWithValue("@Address", txtAddress.Text);
                    command.Parameters.AddWithValue("@ContactInfo", txtContactInfo.Text);

                    command.Parameters.AddWithValue("@PurchaseHistory", txtPurchaseHistory.Text);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Update successful!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            txtCustomerID.Clear();
            txtCustomerName.Clear();
            txtAddress.Clear();
            txtContactInfo.Clear();

            txtPurchaseHistory.Clear();

            txtCustomerID.Focus();
        }

        private void btnClose_Click_2(object sender, EventArgs e)
        {
            frmABCStoreManagement abcStoreManagementForm = new frmABCStoreManagement();
            abcStoreManagementForm.Show();
            this.Hide();
        }
    }
}

