namespace ABC_Store
{
    partial class frmABCStoreManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClose = new System.Windows.Forms.Button();
            this.btnBillDetail = new System.Windows.Forms.Button();
            this.btnBill = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClothing = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.btnSaleReport = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Yellow;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(612, 476);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(123, 43);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Cancel";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnBillDetail
            // 
            this.btnBillDetail.BackColor = System.Drawing.Color.Yellow;
            this.btnBillDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBillDetail.Location = new System.Drawing.Point(89, 346);
            this.btnBillDetail.Name = "btnBillDetail";
            this.btnBillDetail.Size = new System.Drawing.Size(191, 49);
            this.btnBillDetail.TabIndex = 11;
            this.btnBillDetail.Text = "Manage Bill Detail";
            this.btnBillDetail.UseVisualStyleBackColor = false;
            this.btnBillDetail.Click += new System.EventHandler(this.btnBillDetail_Click);
            // 
            // btnBill
            // 
            this.btnBill.BackColor = System.Drawing.Color.Yellow;
            this.btnBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBill.Location = new System.Drawing.Point(89, 67);
            this.btnBill.Name = "btnBill";
            this.btnBill.Size = new System.Drawing.Size(191, 49);
            this.btnBill.TabIndex = 10;
            this.btnBill.Text = "Manage Bill";
            this.btnBill.UseVisualStyleBackColor = false;
            this.btnBill.Click += new System.EventHandler(this.btnBill_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackColor = System.Drawing.Color.Yellow;
            this.btnCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.Location = new System.Drawing.Point(89, 177);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(191, 53);
            this.btnCustomer.TabIndex = 9;
            this.btnCustomer.Text = "Manage Customer";
            this.btnCustomer.UseVisualStyleBackColor = false;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(300, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(598, 42);
            this.label1.TabIndex = 7;
            this.label1.Text = "ABC Clothing Store Management";
            // 
            // btnClothing
            // 
            this.btnClothing.BackColor = System.Drawing.Color.Yellow;
            this.btnClothing.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClothing.Location = new System.Drawing.Point(89, 122);
            this.btnClothing.Name = "btnClothing";
            this.btnClothing.Size = new System.Drawing.Size(191, 49);
            this.btnClothing.TabIndex = 14;
            this.btnClothing.Text = "Manage Clothing";
            this.btnClothing.UseVisualStyleBackColor = false;
            this.btnClothing.Click += new System.EventHandler(this.btnClothing_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.BackColor = System.Drawing.Color.Yellow;
            this.btnSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplier.Location = new System.Drawing.Point(89, 236);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(191, 49);
            this.btnSupplier.TabIndex = 15;
            this.btnSupplier.Text = "Manage Supplier";
            this.btnSupplier.UseVisualStyleBackColor = false;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.BackColor = System.Drawing.Color.Yellow;
            this.btnEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployee.Location = new System.Drawing.Point(89, 291);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(191, 49);
            this.btnEmployee.TabIndex = 16;
            this.btnEmployee.Text = "Manage Employee";
            this.btnEmployee.UseVisualStyleBackColor = false;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // btnSaleReport
            // 
            this.btnSaleReport.BackColor = System.Drawing.Color.Yellow;
            this.btnSaleReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaleReport.Location = new System.Drawing.Point(89, 409);
            this.btnSaleReport.Name = "btnSaleReport";
            this.btnSaleReport.Size = new System.Drawing.Size(191, 49);
            this.btnSaleReport.TabIndex = 17;
            this.btnSaleReport.Text = "Sale Report";
            this.btnSaleReport.UseVisualStyleBackColor = false;
            this.btnSaleReport.Click += new System.EventHandler(this.btnSaleResport_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Yellow;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(839, 476);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(136, 43);
            this.btnLogout.TabIndex = 18;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ABC_Store.Properties.Resources.Ảnh_chụp_màn_hình_2024_11_13_144242;
            this.pictureBox1.Location = new System.Drawing.Point(321, 100);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(667, 370);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // frmABCStoreManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 546);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnSaleReport);
            this.Controls.Add(this.btnEmployee);
            this.Controls.Add(this.btnSupplier);
            this.Controls.Add(this.btnClothing);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBillDetail);
            this.Controls.Add(this.btnBill);
            this.Controls.Add(this.btnCustomer);
            this.Controls.Add(this.label1);
            this.Name = "frmABCStoreManagement";
            this.Text = "frmABCStoreManagement";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnBillDetail;
        private System.Windows.Forms.Button btnBill;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClothing;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.Button btnSaleReport;
        private System.Windows.Forms.Button btnLogout;
    }
}

