
namespace POS3
{
    partial class SplashScreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnltitle = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.pnlloading = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pnltitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnltitle
            // 
            this.pnltitle.BackColor = System.Drawing.Color.Transparent;
            this.pnltitle.Controls.Add(this.label2);
            this.pnltitle.Controls.Add(this.guna2PictureBox1);
            this.pnltitle.Controls.Add(this.label1);
            this.pnltitle.Location = new System.Drawing.Point(68, 67);
            this.pnltitle.Name = "pnltitle";
            this.pnltitle.Size = new System.Drawing.Size(10, 115);
            this.pnltitle.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(413, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "MAWD12A";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(0, 24);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(91, 74);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 1;
            this.guna2PictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(80, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(407, 66);
            this.label1.TabIndex = 0;
            this.label1.Text = "INSTA BURGER";
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.Controls.Add(this.pnlloading);
            this.guna2CustomGradientPanel1.Controls.Add(this.pnltitle);
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(12, 12);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.ShadowDecoration.BorderRadius = 20;
            this.guna2CustomGradientPanel1.ShadowDecoration.Depth = 12;
            this.guna2CustomGradientPanel1.ShadowDecoration.Enabled = true;
            this.guna2CustomGradientPanel1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(4, 4, 8, 8);
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(640, 248);
            this.guna2CustomGradientPanel1.TabIndex = 3;
            // 
            // pnlloading
            // 
            this.pnlloading.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(57)))), ((int)(((byte)(61)))));
            this.pnlloading.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(6)))), ((int)(((byte)(10)))));
            this.pnlloading.Location = new System.Drawing.Point(0, 239);
            this.pnlloading.Name = "pnlloading";
            this.pnlloading.Size = new System.Drawing.Size(10, 10);
            this.pnlloading.TabIndex = 3;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(8)))), ((int)(((byte)(12)))));
            this.ClientSize = new System.Drawing.Size(666, 273);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.Load += new System.EventHandler(this.SplashScreen_Load);
            this.pnltitle.ResumeLayout(false);
            this.pnltitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2GradientPanel pnltitle;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlloading;
        private System.Windows.Forms.Label label2;
    }
}