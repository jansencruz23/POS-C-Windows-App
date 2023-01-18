using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SplashScreen;
using System.Threading;

namespace POS3
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            TopMost = true;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            pnlloading.Width += 4;
            pnltitle.Width += 3;

            if (pnlloading.Width >= 660 && pnltitle.Width >= 480)
            {
                timer1.Stop();
                new frmLogin().Show();
                this.Hide();
                
                
            }
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
