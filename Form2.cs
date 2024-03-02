using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autici
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] times = textBox1.Text.Split(':');

            int min = int.Parse(times[0]);
            int sec = int.Parse(times[1]) + min * 60;

            CustomTimer customTimer = new CustomTimer();
            customTimer.getTime(sec);
            this.Hide();

        }
    }
}
