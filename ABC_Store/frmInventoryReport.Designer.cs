namespace ABC_Store
{
    partial class frmInventoryReport
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.btnInventoryReport = new System.Windows.Forms.Button();
            this.btnRevenueReport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lvViewStock = new System.Windows.Forms.ListView();
            this.clothingName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stockQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnInventoryReport
            // 
            this.btnInventoryReport.BackColor = System.Drawing.Color.Yellow;
            this.btnInventoryReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventoryReport.Location = new System.Drawing.Point(78, 236);
            this.btnInventoryReport.Name = "btnInventoryReport";
            this.btnInventoryReport.Size = new System.Drawing.Size(129, 52);
            this.btnInventoryReport.TabIndex = 5;
            this.btnInventoryReport.Text = "Inventory Report";
            this.btnInventoryReport.UseVisualStyleBackColor = false;
            this.btnInventoryReport.Click += new System.EventHandler(this.btnInventoryReport_Click);
            // 
            // btnRevenueReport
            // 
            this.btnRevenueReport.BackColor = System.Drawing.Color.Yellow;
            this.btnRevenueReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRevenueReport.Location = new System.Drawing.Point(78, 159);
            this.btnRevenueReport.Name = "btnRevenueReport";
            this.btnRevenueReport.Size = new System.Drawing.Size(129, 49);
            this.btnRevenueReport.TabIndex = 4;
            this.btnRevenueReport.Text = "Revenue Report";
            this.btnRevenueReport.UseVisualStyleBackColor = false;
            this.btnRevenueReport.Click += new System.EventHandler(this.btnRevenueReport_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Yellow;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(564, 483);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(123, 43);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Cancel";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lvViewStock
            // 
            this.lvViewStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lvViewStock.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clothingName,
            this.Price,
            this.stockQuantity});
            this.lvViewStock.HideSelection = false;
            this.lvViewStock.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lvViewStock.Location = new System.Drawing.Point(245, 117);
            this.lvViewStock.Name = "lvViewStock";
            this.lvViewStock.Size = new System.Drawing.Size(824, 360);
            this.lvViewStock.TabIndex = 14;
            this.lvViewStock.UseCompatibleStateImageBehavior = false;
            this.lvViewStock.View = System.Windows.Forms.View.Details;
            this.lvViewStock.SelectedIndexChanged += new System.EventHandler(this.lvViewRevenueReport_SelectedIndexChanged);
            // 
            // clothingName
            // 
            this.clothingName.Text = "Clothing Name";
            this.clothingName.Width = 200;
            // 
            // Price
            // 
            this.Price.Text = "Price";
            this.Price.Width = 200;
            // 
            // stockQuantity
            // 
            this.stockQuantity.Text = "Stock Quantity";
            this.stockQuantity.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(468, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 42);
            this.label1.TabIndex = 15;
            this.label1.Text = "Inventory Report";
            // 
            // frmInventoryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 557);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvViewStock);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnInventoryReport);
            this.Controls.Add(this.btnRevenueReport);
            this.Name = "frmInventoryReport";
            this.Text = "frmInventoryReport";
            this.Load += new System.EventHandler(this.frmInventoryReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnInventoryReport;
        private System.Windows.Forms.Button btnRevenueReport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView lvViewStock;
        private System.Windows.Forms.ColumnHeader clothingName;
        private System.Windows.Forms.ColumnHeader stockQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader Price;
    }
}