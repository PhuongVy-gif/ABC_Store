namespace ABC_Store
{
    partial class frmRevenueReport
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnRevenueReport = new System.Windows.Forms.Button();
            this.btnInventoryReport = new System.Windows.Forms.Button();
            this.lvViewRevenueReport = new System.Windows.Forms.ListView();
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.totalRevenue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(445, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "Revenue Report";
            // 
            // btnRevenueReport
            // 
            this.btnRevenueReport.BackColor = System.Drawing.Color.Yellow;
            this.btnRevenueReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRevenueReport.Location = new System.Drawing.Point(48, 169);
            this.btnRevenueReport.Name = "btnRevenueReport";
            this.btnRevenueReport.Size = new System.Drawing.Size(146, 54);
            this.btnRevenueReport.TabIndex = 2;
            this.btnRevenueReport.Text = "Revenue Report";
            this.btnRevenueReport.UseVisualStyleBackColor = false;
            this.btnRevenueReport.Click += new System.EventHandler(this.btnRevenueReport_Click);
            // 
            // btnInventoryReport
            // 
            this.btnInventoryReport.BackColor = System.Drawing.Color.Yellow;
            this.btnInventoryReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventoryReport.Location = new System.Drawing.Point(48, 229);
            this.btnInventoryReport.Name = "btnInventoryReport";
            this.btnInventoryReport.Size = new System.Drawing.Size(146, 62);
            this.btnInventoryReport.TabIndex = 3;
            this.btnInventoryReport.Text = "Inventory Report";
            this.btnInventoryReport.UseVisualStyleBackColor = false;
            this.btnInventoryReport.Click += new System.EventHandler(this.btnInventoryReport_Click);
            // 
            // lvViewRevenueReport
            // 
            this.lvViewRevenueReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lvViewRevenueReport.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Date,
            this.totalRevenue});
            this.lvViewRevenueReport.HideSelection = false;
            this.lvViewRevenueReport.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lvViewRevenueReport.Location = new System.Drawing.Point(211, 98);
            this.lvViewRevenueReport.Name = "lvViewRevenueReport";
            this.lvViewRevenueReport.Size = new System.Drawing.Size(824, 360);
            this.lvViewRevenueReport.TabIndex = 7;
            this.lvViewRevenueReport.UseCompatibleStateImageBehavior = false;
            this.lvViewRevenueReport.View = System.Windows.Forms.View.Details;
            this.lvViewRevenueReport.SelectedIndexChanged += new System.EventHandler(this.lvViewRevenueReport_SelectedIndexChanged);
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.Width = 300;
            // 
            // totalRevenue
            // 
            this.totalRevenue.Text = "Total Revenue";
            this.totalRevenue.Width = 300;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Yellow;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(577, 464);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(123, 43);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Cancel";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmRevenueReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 524);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvViewRevenueReport);
            this.Controls.Add(this.btnInventoryReport);
            this.Controls.Add(this.btnRevenueReport);
            this.Controls.Add(this.label1);
            this.Name = "frmRevenueReport";
            this.Text = "frmRevenueReport";
            this.Load += new System.EventHandler(this.frmRevenueReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRevenueReport;
        private System.Windows.Forms.Button btnInventoryReport;
        private System.Windows.Forms.ListView lvViewRevenueReport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader totalRevenue;
    }
}