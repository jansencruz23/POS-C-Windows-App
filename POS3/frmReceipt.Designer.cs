
namespace POS3
{
    partial class frmReceipt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReceipt));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblCash = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalPriceReceipt = new System.Windows.Forms.Label();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.btnprint = new Guna.UI2.WinForms.Guna2Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Poppins", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(104, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 42);
            this.label2.TabIndex = 0;
            this.label2.Text = "INSTA BURGER";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Customer Receipt";
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(111, 79);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(159, 23);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cashier Name: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(142, 139);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(48, 23);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(30, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(329, 2);
            this.label6.TabIndex = 5;
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.Location = new System.Drawing.Point(28, 179);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(32, 23);
            this.lblQty.TabIndex = 4;
            this.lblQty.Text = "Qty";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.Location = new System.Drawing.Point(93, 179);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(61, 23);
            this.lblItemName.TabIndex = 4;
            this.lblItemName.Text = "Product";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.Location = new System.Drawing.Point(204, 179);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(42, 23);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "Price";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPrice.Location = new System.Drawing.Point(282, 179);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(77, 23);
            this.lblTotalPrice.TabIndex = 4;
            this.lblTotalPrice.Text = "Total Price";
            this.lblTotalPrice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 28);
            this.label7.TabIndex = 10;
            this.label7.Text = "Total Price :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label17
            // 
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label17.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(23, 112);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(329, 2);
            this.label17.TabIndex = 20;
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(140, 121);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(106, 28);
            this.label18.TabIndex = 9;
            this.label18.Text = "THANK YOU!";
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(23, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(329, 2);
            this.label8.TabIndex = 19;
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(23, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 23);
            this.label11.TabIndex = 11;
            this.label11.Text = "Cash : ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(23, 71);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 23);
            this.label14.TabIndex = 12;
            this.label14.Text = "Change :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCash
            // 
            this.lblCash.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCash.Location = new System.Drawing.Point(276, 47);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(76, 23);
            this.lblCash.TabIndex = 13;
            this.lblCash.Text = "0";
            // 
            // lblChange
            // 
            this.lblChange.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.Location = new System.Drawing.Point(276, 71);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(83, 23);
            this.lblChange.TabIndex = 14;
            this.lblChange.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(243, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 23);
            this.label13.TabIndex = 15;
            this.label13.Text = "₱";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(243, 71);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(20, 23);
            this.label15.TabIndex = 16;
            this.label15.Text = "₱";
            this.label15.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(242, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 28);
            this.label9.TabIndex = 17;
            this.label9.Text = "₱";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTotalPriceReceipt
            // 
            this.lblTotalPriceReceipt.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPriceReceipt.Location = new System.Drawing.Point(274, 17);
            this.lblTotalPriceReceipt.Name = "lblTotalPriceReceipt";
            this.lblTotalPriceReceipt.Size = new System.Drawing.Size(100, 30);
            this.lblTotalPriceReceipt.TabIndex = 18;
            this.lblTotalPriceReceipt.Text = "0";
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.Controls.Add(this.label7);
            this.guna2CustomGradientPanel1.Controls.Add(this.lblTotalPriceReceipt);
            this.guna2CustomGradientPanel1.Controls.Add(this.label17);
            this.guna2CustomGradientPanel1.Controls.Add(this.label9);
            this.guna2CustomGradientPanel1.Controls.Add(this.label18);
            this.guna2CustomGradientPanel1.Controls.Add(this.label15);
            this.guna2CustomGradientPanel1.Controls.Add(this.label8);
            this.guna2CustomGradientPanel1.Controls.Add(this.label13);
            this.guna2CustomGradientPanel1.Controls.Add(this.label11);
            this.guna2CustomGradientPanel1.Controls.Add(this.lblChange);
            this.guna2CustomGradientPanel1.Controls.Add(this.label14);
            this.guna2CustomGradientPanel1.Controls.Add(this.lblCash);
            this.guna2CustomGradientPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(0, 218);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(386, 178);
            this.guna2CustomGradientPanel1.TabIndex = 21;
            // 
            // btnprint
            // 
            this.btnprint.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnprint.BorderRadius = 5;
            this.btnprint.BorderThickness = 1;
            this.btnprint.CheckedState.BorderColor = System.Drawing.Color.Transparent;
            this.btnprint.CheckedState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnprint.CheckedState.FillColor = System.Drawing.Color.Transparent;
            this.btnprint.CheckedState.ForeColor = System.Drawing.Color.Transparent;
            this.btnprint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnprint.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnprint.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnprint.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnprint.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnprint.FillColor = System.Drawing.Color.Transparent;
            this.btnprint.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnprint.ForeColor = System.Drawing.Color.White;
            this.btnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.Image")));
            this.btnprint.Location = new System.Drawing.Point(329, 12);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(45, 35);
            this.btnprint.TabIndex = 22;
            this.btnprint.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // frmReceipt
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(386, 396);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReceipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmReceipt";
            this.Load += new System.EventHandler(this.frmReceipt_Load);
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblCash;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTotalPriceReceipt;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2Button btnprint;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}