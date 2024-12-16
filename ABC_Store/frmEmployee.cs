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
    public partial class frmEmployee : Form
    {
        public frmEmployee()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            

        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
        }

        private void lvViewEmployee_SelectedIndexChanged(object sender, EventArgs e)
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

        private void lvViewEmployee_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lvViewEmployee.SelectedItems.Count > 0)
            {
               
                var selectedItem = lvViewEmployee.SelectedItems[0];

                
                txtEmployeeID.Text = selectedItem.SubItems[0].Text;
                txtEmployeeName.Text = selectedItem.SubItems[1].Text;
                txtRole.Text = selectedItem.SubItems[2].Text;
                txtContactInfo.Text = selectedItem.SubItems[3].Text;

            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            frmABCStoreManagement abcStoreManagementForm = new frmABCStoreManagement();
            abcStoreManagementForm.Show();
            this.Hide();
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            txtEmployeeID.Clear();
            txtEmployeeName.Clear();
            txtRole.Clear();
            txtContactInfo.Clear();

            txtEmployeeID.Focus();
        }

        private void frmEmployee_Load_1(object sender, EventArgs e)
        {

            // SQL statement to get data
            string query = "SELECT EmployeeID, EmployeeName, Role, ContactInfo FROM Employee";

            // Delete old items in ListView
            lvViewEmployee.Items.Clear();

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
                        
                        ListViewItem item = new ListViewItem(reader["EmployeeID"].ToString());
                        item.SubItems.Add(reader["EmployeeName"].ToString());
                        item.SubItems.Add(reader["Role"].ToString());
                        item.SubItems.Add(reader["ContactInfo"].ToString());

                       
                        lvViewEmployee.Items.Add(item);
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

            if (lvViewEmployee.SelectedItems.Count > 0)
            {
                // Get the selected item
                var selectedItem = lvViewEmployee.SelectedItems[0];

                // Update value in ListView
                selectedItem.SubItems[0].Text = txtEmployeeID.Text;
                selectedItem.SubItems[1].Text = txtEmployeeName.Text;
                selectedItem.SubItems[2].Text = txtRole.Text;
                selectedItem.SubItems[3].Text = txtContactInfo.Text;

                
                string connectionString = "Data Source=MSI\\PHUONGVY;Initial Catalog=ABC_Store_Management;Integrated Security=True";

                string query = "UPDATE Employee SET EmployeeName = @EmployeeName, Role = @Role, ContactInfo = @ContactInfo WHERE EmployeeID = @EmployeeID";


                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, con);

                    // Add parameters
                    command.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);
                    command.Parameters.AddWithValue("@EmployeeName", txtEmployeeName.Text);
                    command.Parameters.AddWithValue("@Role", txtRole.Text);
                    command.Parameters.AddWithValue("@ContactInfo", txtContactInfo.Text);

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
            // Connection string
            string connectionString = "Data Source=MSI\\PHUONGVY;Initial Catalog=ABC_Store_Management;Integrated Security=True";

            // SQL statement to add data
            string query = "INSERT INTO Employee (EmployeeID, EmployeeName, Role, ContactInfo) VALUES (@EmployeeID, @EmployeeName, @Role, @ContactInfo)";



            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, con);

                // Add parameters
                command.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);
                command.Parameters.AddWithValue("@EmployeeName", txtEmployeeName.Text);
                command.Parameters.AddWithValue("@Role", txtRole.Text);
                command.Parameters.AddWithValue("@ContactInfo", txtContactInfo.Text);

                try
                {
                    con.Open();
                    command.ExecuteNonQuery();

                    
                    ListViewItem newItem = new ListViewItem(txtEmployeeID.Text);
                    newItem.SubItems.Add(txtEmployeeName.Text);
                    newItem.SubItems.Add(txtRole.Text);
                    newItem.SubItems.Add(txtContactInfo.Text);

                    lvViewEmployee.Items.Add(newItem);

                    MessageBox.Show("New addition successful!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                    txtEmployeeID.Clear();
                    txtEmployeeName.Clear();
                    txtRole.Clear();
                    txtContactInfo.Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding new: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (lvViewEmployee.SelectedItems.Count > 0)
            {
                // Get the selected item
                var selectedItem = lvViewEmployee.SelectedItems[0];
                string selectedEmployeeID = selectedItem.SubItems[0].Text;

                // Connection string
                string connectionString = "Data Source=MSI\\PHUONGVY;Initial Catalog=ABC_Store_Management;Integrated Security=True";

                // SQL statement to delete
                string query = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, con);

                    // Add parameters
                    command.Parameters.AddWithValue("@EmployeeID", selectedEmployeeID);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();

                        
                        lvViewEmployee.Items.Remove(selectedItem);

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

           
            string query = "SELECT EmployeeID, EmployeeName, Role, ContactInfo FROM Bill WHERE Employee LIKE @SearchKeyword";


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, con);

               
                command.Parameters.AddWithValue("@SearchKeyword", "%" + searchKeyword + "%");

                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                   
                    lvViewEmployee.Items.Clear();

                    while (reader.Read())
                    {
                        
                        ListViewItem item = new ListViewItem(reader["EmployeeID"].ToString());
                        item.SubItems.Add(reader["EmployeeName"].ToString());
                        item.SubItems.Add(reader["Role"].ToString());
                        item.SubItems.Add(reader["ContactInfo"].ToString());


                       
                        lvViewEmployee.Items.Add(item);
                    }

                    reader.Close();

                    // Display message if no results found
                    if (lvViewEmployee.Items.Count == 0)
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
