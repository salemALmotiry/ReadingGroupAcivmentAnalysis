using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagingReading
{
    public partial class Start : Form
    {

        Thread th;
        public Start()
        {
            InitializeComponent();
        }

   
        private void timer1_Tick_1(object sender, EventArgs e)
        {

            panel2.Width += 10;

            if (panel2.Width >= 1191)
            {

                timer1.Stop();
                DashBoard f = new DashBoard();

                f.Show();
                this.Close();
                th = new Thread(opnenewform);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();

            }
        }

        private void opnenewform()
        {
            Application.Run(new DashBoard());
        }
    }
}
