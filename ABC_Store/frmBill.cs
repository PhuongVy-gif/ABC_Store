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
    public partial class frmBill : Form
    {
        public frmBill()
        {
            InitializeComponent();
        }

        private void lvViewBill_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvViewBill.SelectedItems.Count > 0)
            {
                // Get the selected item
                var selectedItem = lvViewBill.SelectedItems[0];

                // Display data on TextBoxes
                txtBillID.Text = selectedItem.SubItems[0].Text;
                txtCustomerID.Text = selectedItem.SubItems[1].Text;
                txtEmployeeID.Text = selectedItem.SubItems[2].Text;
                txtBillDate.Text = selectedItem.SubItems[3].Text;
                txtTotalAmount.Text = selectedItem.SubItems[4].Text;


            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            
        }

        private void frmBill_Load(object sender, EventArgs e)
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

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            txtBillID.Clear();
            txtCustomerID.Clear();
            txtEmployeeID.Clear();
            txtBillDate.Clear();
            txtTotalAmount.Clear();
            txtBillID.Focus();
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            // Get search keyword
            string searchKeyword = txtSearch.Text.Trim();

            // Connection string
            string connectionString = "Data Source=MSI\\PHUONGVY;Initial Catalog=ABC_Store_Management;Integrated Security=True";

            // SQL statement to search by Bill name
            string query = "SELECT BillID, CustomerID, EmployeeID, BillDate, TotalAmount  FROM Bill WHERE TotalAmount LIKE @SearchKeyword";

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
                    lvViewBill.Items.Clear();

                    while (reader.Read())
                    {
                        // Create a new ListViewItem
                        ListViewItem item = new ListViewItem(reader["BillID"].ToString());
                        item.SubItems.Add(reader["CustomerID"].ToString());
                        item.SubItems.Add(reader["EmployeeID"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(reader["BillDate"]).ToString("yyyy-MM-dd")); // Format the date if needed
                        item.SubItems.Add(reader["TotalAmount"].ToString());


                        // Add item to ListView
                        lvViewBill.Items.Add(item);
                    }

                    reader.Close();

                    // Display message if no results found
                    if (lvViewBill.Items.Count == 0)
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

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (lvViewBill.SelectedItems.Count > 0)
            {
                // Get the selected item
                var selectedItem = lvViewBill.SelectedItems[0];
                string selectedBillID = selectedItem.SubItems[0].Text;

                // Connection string
                string connectionString = "Data Source=MSI\\PHUONGVY;Initial Catalog=ABC_Store_Management;Integrated Security=True";

                // SQL statement to delete
                string query = "DELETE FROM Bill WHERE BillID = @BillID";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, con);

                    // Add parameters
                    command.Parameters.AddWithValue("@BillID", selectedBillID);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();

                        // Remove from ListView
                        lvViewBill.Items.Remove(selectedItem);

                        MessageBox.Show("Deleted successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            // Connection string
            string connectionString = "Data Source=MSI\\PHUONGVY;Initial Catalog=ABC_Store_Management;Integrated Security=True";

            // SQL statement to add data
            string query = "INSERT INTO Bill (BillID, CustomerID, EmployeeID, BillDate, TotalAmount) " +
                           "VALUES (@BillID, @CustomerID, @EmployeeID, @BillDate, @TotalAmount)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, con);

                try
                {
                    // Retrieve and trim input data
                    string billID = txtBillID.Text.Trim();
                    string customerID = txtCustomerID.Text.Trim();
                    string employeeID = txtEmployeeID.Text.Trim();

                    // Handle date (show a warning if the format is incorrect)
                    DateTime billDate;
                    if (!DateTime.TryParse(txtBillDate.Text, out billDate))
                    {
                        MessageBox.Show("Invalid date format. Please enter again.",
                                        "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtBillDate.Focus();
                        return;
                    }

                    // Get TotalAmount as a string without enforcing any format
                    string totalAmount = txtTotalAmount.Text.Trim();

                    // Add parameters to the SQL query
                    command.Parameters.AddWithValue("@BillID", billID);
                    command.Parameters.AddWithValue("@CustomerID", customerID);
                    command.Parameters.AddWithValue("@EmployeeID", employeeID);
                    command.Parameters.AddWithValue("@BillDate", billDate);
                    command.Parameters.AddWithValue("@TotalAmount", totalAmount); // No numeric conversion

                    // Open connection and execute query
                    con.Open();
                    command.ExecuteNonQuery();

                    // Add to ListView
                    ListViewItem newItem = new ListViewItem(billID);
                    newItem.SubItems.Add(customerID);
                    newItem.SubItems.Add(employeeID);
                    newItem.SubItems.Add(billDate.ToString("yyyy-MM-dd"));
                    newItem.SubItems.Add(totalAmount); // Display TotalAmount as entered

                    lvViewBill.Items.Add(newItem);

                    MessageBox.Show("Addition successful!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear input fields after adding
                    txtBillID.Clear();
                    txtCustomerID.Clear();
                    txtEmployeeID.Clear();
                    txtBillDate.Clear();
                    txtTotalAmount.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while adding: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (lvViewBill.SelectedItems.Count > 0)
            {
                // Get the selected item
                var selectedItem = lvViewBill.SelectedItems[0];

                // Update value in ListView
                selectedItem.SubItems[0].Text = txtBillID.Text;
                selectedItem.SubItems[1].Text = txtCustomerID.Text;
                selectedItem.SubItems[2].Text = txtEmployeeID.Text;
                selectedItem.SubItems[3].Text = txtBillDate.Text;
                selectedItem.SubItems[4].Text = txtTotalAmount.Text;


                // Update database
                string connectionString = "Data Source=MSI\\PHUONGVY;Initial Catalog=ABC_Store_Management;Integrated Security=True";

                string query = "UPDATE Bill SET CustomerID = @CustomerID, EmployeeID = @EmployeeID, BillDate = @BillDate, TotalAmount = @TotalAmount, BillStatus = @BillStatus WHERE BillID = @BillID";


                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, con);

                    // Add parameters
                    command.Parameters.AddWithValue("@BillID", txtBillID.Text);
                    command.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text);
                    command.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);
                    command.Parameters.AddWithValue("@BillDate", Convert.ToDateTime(txtBillDate.Text)); // Ensure correct format if needed
                    command.Parameters.AddWithValue("@TotalAmount", Convert.ToDecimal(txtTotalAmount.Text)); // Convert to decimal if applicable


                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Update successful!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Update successful!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an item to update!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            frmABCStoreManagement abcStoreManagementForm = new frmABCStoreManagement();
            abcStoreManagementForm.Show();
            this.Hide();
        }

        private void frmBill_Load_1(object sender, EventArgs e)
        {
            // SQL statement to get data
            string query = "SELECT BillID, CustomerID, EmployeeID, BillDate, TotalAmount FROM Bill";

            // Delete old items in ListView
            lvViewBill.Items.Clear();

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
                        item.SubItems.Add(reader["CustomerID"].ToString());
                        item.SubItems.Add(reader["EmployeeID"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(reader["BillDate"]).ToString("yyyy-MM-dd")); // Format the date if necessary
                                                                                                          // Format TotalAmount as VND
                        decimal totalAmount = Convert.ToDecimal(reader["TotalAmount"]);
                        string formattedAmount = string.Format("{0:#,##0} VND", totalAmount);
                        item.SubItems.Add(formattedAmount);

                        // Add item to ListView
                        lvViewBill.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Successfully accessed Manage Bill page ");
                }
            }
        }
    }
}

