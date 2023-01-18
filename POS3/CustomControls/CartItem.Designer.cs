
namespace POS3.CustomControls
{
    partial class CartItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CartItem));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblItemID = new System.Windows.Forms.Label();
            this.btnRemove = new Guna.UI2.WinForms.Guna2Button();
            this.lblPerItemPrice = new System.Windows.Forms.Label();
            this.lblItemPrice = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.btnQuantity = new Guna.UI2.WinForms.Guna2CircleButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblItemID);
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Controls.Add(this.lblPerItemPrice);
            this.panel1.Controls.Add(this.lblItemPrice);
            this.panel1.Controls.Add(this.lblItemName);
            this.panel1.Controls.Add(this.btnQuantity);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 66);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(8)))), ((int)(((byte)(12)))));
            this.label1.Location = new System.Drawing.Point(163, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "₱";
            // 
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.Location = new System.Drawing.Point(139, 9);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(0, 13);
            this.lblItemID.TabIndex = 12;
            this.lblItemID.Visible = false;
            // 
            // btnRemove
            // 
            this.btnRemove.BorderRadius = 10;
            this.btnRemove.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRemove.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRemove.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRemove.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRemove.FillColor = System.Drawing.Color.Transparent;
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.Image")));
            this.btnRemove.Location = new System.Drawing.Point(230, 18);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(27, 27);
            this.btnRemove.TabIndex = 11;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click_1);
            // 
            // lblPerItemPrice
            // 
            this.lblPerItemPrice.AutoSize = true;
            this.lblPerItemPrice.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerItemPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lblPerItemPrice.Location = new System.Drawing.Point(73, 33);
            this.lblPerItemPrice.Name = "lblPerItemPrice";
            this.lblPerItemPrice.Size = new System.Drawing.Size(36, 19);
            this.lblPerItemPrice.TabIndex = 10;
            this.lblPerItemPrice.Text = "Price";
            // 
            // lblItemPrice
            // 
            this.lblItemPrice.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(8)))), ((int)(((byte)(12)))));
            this.lblItemPrice.Location = new System.Drawing.Point(177, 21);
            this.lblItemPrice.Name = "lblItemPrice";
            this.lblItemPrice.Size = new System.Drawing.Size(80, 25);
            this.lblItemPrice.TabIndex = 9;
            this.lblItemPrice.Text = "Price Total";
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.lblItemName.Location = new System.Drawing.Point(72, 15);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(90, 23);
            this.lblItemName.TabIndex = 9;
            this.lblItemName.Text = "Item Name";
            // 
            // btnQuantity
            // 
            this.btnQuantity.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnQuantity.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnQuantity.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnQuantity.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnQuantity.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(8)))), ((int)(((byte)(12)))));
            this.btnQuantity.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuantity.ForeColor = System.Drawing.Color.White;
            this.btnQuantity.Location = new System.Drawing.Point(13, 11);
            this.btnQuantity.Name = "btnQuantity";
            this.btnQuantity.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnQuantity.Size = new System.Drawing.Size(47, 45);
            this.btnQuantity.TabIndex = 0;
            this.btnQuantity.Text = "1";
            this.btnQuantity.TextOffset = new System.Drawing.Point(1, 1);
            this.btnQuantity.Click += new System.EventHandler(this.btnQuantity_Click);
            // 
            // CartItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel1);
            this.Name = "CartItem";
            this.Size = new System.Drawing.Size(260, 66);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2CircleButton btnQuantity;
        private System.Windows.Forms.Label lblPerItemPrice;
        private System.Windows.Forms.Label lblItemPrice;
        private System.Windows.Forms.Label lblItemName;
        private Guna.UI2.WinForms.Guna2Button btnRemove;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.Label label1;
    }
}
