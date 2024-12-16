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
    public partial class frmBillDetail : Form
    {
        public frmBillDetail()
        {
            InitializeComponent();
        }

        private void lvViewBillDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvViewBillDetail.SelectedItems.Count > 0)
            {
                // Get the selected item
                var selectedItem = lvViewBillDetail.SelectedItems[0];

                // Display data on TextBoxes
                txtBillDetailID.Text = selectedItem.SubItems[0].Text;
                txtBillID.Text = selectedItem.SubItems[1].Text;
                txtClothingID.Text = selectedItem.SubItems[2].Text;
                txtQuantity.Text = selectedItem.SubItems[3].Text;
                txtSelingPrice.Text = selectedItem.SubItems[4].Text;
                txtTotal.Text = selectedItem.SubItems[5].Text;

            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {

        }

        private void frmBillDetail_Load(object sender, EventArgs e)
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

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            txtBillDetailID.Clear();
            txtBillID.Clear();
            txtClothingID.Clear();
            txtQuantity.Clear();
            txtSelingPrice.Clear();
            txtTotal.Clear();

            txtBillDetailID.Focus();
        }

        private void frmBillDetail_Load_1(object sender, EventArgs e)
        {
            // SQL statement to get data
            string query = "SELECT BillDetailID, BillID, ClothingID, Quantity, SellingPrice, Total FROM BillDetail";

            // Delete old items in ListView
            lvViewBillDetail.Items.Clear();

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
                        ListViewItem item = new ListViewItem(reader["BillDetailID"].ToString());
                        item.SubItems.Add(reader["BillID"].ToString());
                        item.SubItems.Add(reader["ClothingID"].ToString());
                        item.SubItems.Add(reader["Quantity"].ToString());

                        // Format SellingPrice as VND
                        decimal selingPrice = Convert.ToDecimal(reader["SellingPrice"]);
                        string formattedSelingPrice = string.Format("{0:#,##0} VND", selingPrice);
                        item.SubItems.Add(formattedSelingPrice);

                        // Format Total as VND
                        decimal total = Convert.ToDecimal(reader["Total"]);
                        string formattedTotal = string.Format("{0:#,##0} VND", total);
                        item.SubItems.Add(formattedTotal);


                        // Add item to ListView
                        lvViewBillDetail.Items.Add(item);
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
            if (lvViewBillDetail.SelectedItems.Count > 0)
            {
                // Get the selected item
                var selectedItem = lvViewBillDetail.SelectedItems[0];

                // Update value in ListView
                selectedItem.SubItems[0].Text = txtBillDetailID.Text;
                selectedItem.SubItems[1].Text = txtBillID.Text;
                selectedItem.SubItems[2].Text = txtClothingID.Text;
                selectedItem.SubItems[3].Text = txtQuantity.Text;
                selectedItem.SubItems[4].Text = txtSelingPrice.Text;
                selectedItem.SubItems[5].Text = txtTotal.Text;

                // Update database
                string connectionString = "Data Source=MSI\\PHUONGVY;Initial Catalog=ABC_Store_Management;Integrated Security=True";

                string query = "UPDATE BillDetail SET BillID = @BillID, ClothingID = @ClothingID, Quantity = @Quantity, SellingPrice = @SellingPrice, Total = @Total WHERE BillDetailID = @BillDetailID";



                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, con);

                    // Add parameters
                    command.Parameters.AddWithValue("@BillDetailID", txtBillDetailID.Text);
                    command.Parameters.AddWithValue("@BillID", txtBillID.Text);
                    command.Parameters.AddWithValue("@ClothingID", txtClothingID.Text);
                    command.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                    command.Parameters.AddWithValue("@SellingPrice", txtSelingPrice.Text);
                    command.Parameters.AddWithValue("@Total", txtTotal.Text);

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

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            frmABCStoreManagement abcStoreManagementForm = new frmABCStoreManagement();
            abcStoreManagementForm.Show();
            this.Hide();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            // Connection string
            string connectionString = "Data Source=MSI\\PHUONGVY;Initial Catalog=ABC_Store_Management;Integrated Security=True";

            // SQL statement to add data
            string query = "INSERT INTO BillDetail (BillDetailID, BillID, ClothingID, Quantity, SellingPrice, Total) VALUES (@BillDetailID, @BillID, @ClothingID, @Quantity, @SellingPrice, @Total)";


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, con);

                // Add parameters
                command.Parameters.AddWithValue("@BillDetailID", txtBillDetailID.Text);
                command.Parameters.AddWithValue("@BillID", txtBillID.Text);
                command.Parameters.AddWithValue("@ClothingID", txtClothingID.Text);
                command.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                command.Parameters.AddWithValue("@SellingPrice", txtSelingPrice.Text);
                command.Parameters.AddWithValue("@Total", txtTotal.Text);


                try
                {
                    con.Open();
                    command.ExecuteNonQuery();

                    // Add to ListView
                    ListViewItem newItem = new ListViewItem(txtBillDetailID.Text);
                    newItem.SubItems.Add(txtBillID.Text);
                    newItem.SubItems.Add(txtClothingID.Text);
                    newItem.SubItems.Add(txtQuantity.Text);
                    newItem.SubItems.Add(txtSelingPrice.Text);
                    newItem.SubItems.Add(txtTotal.Text);


                    lvViewBillDetail.Items.Add(newItem);

                    MessageBox.Show("New addition successful!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Delete TextBoxes after adding
                    txtBillDetailID.Clear();
                    txtBillID.Clear();
                    txtClothingID.Clear();
                    txtQuantity.Clear();
                    txtSelingPrice.Clear();
                    txtTotal.Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error when adding new: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (lvViewBillDetail.SelectedItems.Count > 0)
            {
                // Get the selected item
                var selectedItem = lvViewBillDetail.SelectedItems[0];
                string selectedBillDetailID = selectedItem.SubItems[0].Text;

                // Connection string
                string connectionString = "Data Source=MSI\\PHUONGVY;Initial Catalog=ABC_Store_Management;Integrated Security=True";

                // SQL statement to delete
                string query = "DELETE FROM Employee WHERE BillDetailID = @BillDetailID";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, con);

                    // Add parameters
                    command.Parameters.AddWithValue("@BillDetailID", selectedBillDetailID);

                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();

                        // Remove from ListView
                        lvViewBillDetail.Items.Remove(selectedItem);

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

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            // Get search keyword
            string searchKeyword = txtSearch.Text.Trim();

            // Connection string
            string connectionString = "Data Source=MSI\\PHUONGVY;Initial Catalog=ABC_Store_Management;Integrated Security=True";

            // SQL statement to search by Bill name
            string query = "SELECT BillDetailID, BillID, ClothingID, Quantity, SellingPrice, Total FROM BillDetail WHERE Total LIKE @SearchKeyword";


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, con);

                // Add parameters with wildcard %
                command.Parameters.AddWithValue("@SearchKeyword", "%" + searchKeyword + "%");

                try
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    
                    lvViewBillDetail.Items.Clear();

                    while (reader.Read())
                    {
                        
                        ListViewItem item = new ListViewItem(reader["BillDetail"].ToString());
                        item.SubItems.Add(reader["BillDetailID"].ToString());
                        item.SubItems.Add(reader["BillID"].ToString());
                        item.SubItems.Add(reader["ClothingID"].ToString());
                        item.SubItems.Add(reader["Quantity"].ToString());
                        item.SubItems.Add(reader["SellingPrice"].ToString());
                        item.SubItems.Add(reader["Total"].ToString());



                        
                        lvViewBillDetail.Items.Add(item);
                    }

                    reader.Close();

               
                    if (lvViewBillDetail.Items.Count == 0)
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
