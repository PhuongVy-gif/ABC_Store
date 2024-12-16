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
    public partial class frmSupplier : Form
    {
        public frmSupplier()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
           
        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            
        }

        private void lvViewSupplier_SelectedIndexChanged(object sender, EventArgs e)
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

        private void lvViewSupplier_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lvViewSupplier.SelectedItems.Count > 0)
            {
                // Get the selected item
                var selectedItem = lvViewSupplier.SelectedItems[0];

               
                txtSupplierID.Text = selectedItem.SubItems[0].Text;
                txtSupplierName.Text = selectedItem.SubItems[1].Text;
                txtAddress.Text = selectedItem.SubItems[2].Text;
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
            txtSupplierID.Clear();
            txtSupplierName.Clear();
            txtAddress.Clear();
            txtContactInfo.Clear();

            txtSupplierID.Focus();
        }

        private void frmSupplier_Load_1(object sender, EventArgs e)
        {
            // SQL statement to get data
            string query = "SELECT SupplierID, SupplierName, Address, ContactInfo FROM Supplier";

            
            lvViewSupplier.Items.Clear();

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
                       
                        ListViewItem item = new ListViewItem(reader["SupplierID"].ToString());
                        item.SubItems.Add(reader["SupplierName"].ToString());
                        item.SubItems.Add(reader["Address"].ToString());
                        item.SubItems.Add(reader["ContactInfo"].ToString());


                        
                        lvViewSupplier.Items.Add(item);
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
            if (lvViewSupplier.SelectedItems.Count > 0)
            {
                // Get the selected item
                var selectedItem = lvViewSupplier.SelectedItems[0];

                // Update value in ListView
                selectedItem.SubItems[0].Text = txtSupplierID.Text;
                selectedItem.SubItems[1].Text = txtSupplierName.Text;
                selectedItem.SubItems[2].Text = txtAddress.Text;
                selectedItem.SubItems[3].Text = txtContactInfo.Text;

               
                string connectionString = "Data Source=MSI\\PHUONGVY;Initial Catalog=ABC_Store_Management;Integrated Security=True";

                string query = "UPDATE Supplier SET SupplierName = @SupplierName, Address = @Address, ContactInfo = @ContactInfo WHERE SupplierID = @SupplierID";



                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, con);

                    // Add parameters
                    command.Parameters.AddWithValue("@SupplierID", txtSupplierID.Text);
                    command.Parameters.AddWithValue("@SupplierName", txtSupplierName.Text);
                    command.Parameters.AddWithValue("@Address", txtAddress.Text);
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
            string query = "INSERT INTO Supplier (SupplierID, SupplierName, Address, ContactInfo) VALUES (@SupplierID, @SupplierName, @Address, @ContactInfo)";


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, con);

                // Add parameters
                command.Parameters.AddWithValue("@SupplierID", txtSupplierID.Text);
                command.Parameters.AddWithValue("@SupplierName", txtSupplierName.Text);
                command.Parameters.AddWithValue("@Address", txtAddress.Text);
                command.Parameters.AddWithValue("@ContactInfo", txtContactInfo.Text);

                try
                {
                    con.Open();
                    command.ExecuteNonQuery();

                 
                    ListViewItem newItem = new ListViewItem(txtSupplierID.Text);
                    newItem.SubItems.Add(txtSupplierName.Text);
                    newItem.SubItems.Add(txtAddress.Text);
                    newItem.SubItems.Add(txtContactInfo.Text);


                    lvViewSupplier.Items.Add(newItem);

                    MessageBox.Show("New addition successful!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   
                    txtSupplierID.Clear();
                    txtSupplierName.Clear();
                    txtAddress.Clear();
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
            if (lvViewSupplier.SelectedItems.Count > 0)
            {
                // Get the selected item
                var selectedItem = lvViewSupplier.SelectedItems[0];
                string selectedSupplierID = selectedItem.SubItems[0].Text;

                // Connection string
                string connectionString = "Data Source=MSI\\PHUONGVY;Initial Catalog=ABC_Management;Integrated Security=True";

                // SQL statement to delete
                string query = "DELETE FROM Employee WHERE SupplierID = @SupplierID";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, con);

                   
                    command.Parameters.AddWithValue("@SupplierID", selectedSupplierID);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();

                        // Delete from ListView
                        lvViewSupplier.Items.Remove(selectedItem);

                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mục để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            // Get search keyword
            string searchKeyword = txtSearch.Text.Trim();

            // Connection string
            string connectionString = "Data Source=MSI\\PHUONGVY;Initial Catalog=ABC_Store_Management;Integrated Security=True";

            
            string query = "SELECT SupplierID, SupplierName, Address, ContactInfo FROM Supplier WHERE SupplierName LIKE @SearchKeyword";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, con);


                command.Parameters.AddWithValue("@SearchKeyword", "%" + searchKeyword + "%");

                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    
                    lvViewSupplier.Items.Clear();

                    while (reader.Read())
                    {
                        
                        ListViewItem item = new ListViewItem(reader["SupplierID"].ToString());
                        item.SubItems.Add(reader["SupplierName"].ToString());
                        item.SubItems.Add(reader["Address"].ToString());
                        item.SubItems.Add(reader["ContactInfo"].ToString());


                        lvViewSupplier.Items.Add(item);
                    }

                    reader.Close();

                    
                    if (lvViewSupplier.Items.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

