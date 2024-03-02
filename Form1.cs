using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autici
{
    public partial class Form1 : Form
    {
        Panel[] panels = new Panel[6];
        Label[] labels = new Label[6]; 
        Button[] buttons = new Button[6];
        CustomTimer[] timers = new CustomTimer[6];

        int counter = 0;
        int counter2 = 0;
        int counter3 = 0;
        private int seconds = 600;

        public Form1()
        {
            InitializeComponent();

        }
        public void SetTime(int seconds)
        {
            this.seconds = seconds; 
        }
        private void Start(object sender, EventArgs e)
        {
            int index = Array.IndexOf(buttons, (Button)sender);

            if (index >= 0 && index < timers.Length)
            {
                timers[index].StartTimer();
            }

        }
        private void enterTime(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            List<Color> rgbColors = new List<Color>
            {
                Color.FromArgb(38, 70, 83),
                Color.FromArgb(42, 157, 143),
                Color.FromArgb(233, 196, 106),
                Color.FromArgb(244, 162, 97),
                Color.FromArgb(231, 111, 81),
                Color.FromArgb(236, 140, 116)
            };
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    //int[] color = new int[] { rnd.Next(255), rnd.Next(255), rnd.Next(255) };

                    Panel panel = new Panel();
                    panel.Width = this.ClientSize.Width / 3;
                    panel.Height = this.ClientSize.Height / 2;
                    panel.Top = panel.Height * i;
                    panel.Left = panel.Width * j;
                    panel.BackColor = rgbColors[counter];
                    this.Controls.Add(panel);
                    panels[counter] = panel;
                    counter++;
                }
            }
            counter = 0;
            foreach (Panel panel in panels)
            {
                counter++;
                Font font1 = new Font("Arial", 30, FontStyle.Bold);
                Label name = new Label();
                name.Text = $"Auto {counter}";
                name.Width = panel.Width;
                name.AutoSize = true;
                name.MaximumSize = new Size(panel.Width, 0);
                name.Font = font1;
                name.TextAlign = ContentAlignment.MiddleCenter;
                panel.Controls.Add(name);

                
                Font font2 = new Font("Arial", 50, FontStyle.Bold);
                Label label = new Label();
                label.Text = "10:00";
                label.Width = panel.Width;
                label.Height = panel.Height - 100;
                label.Font = font2;
                label.Click += enterTime;
                label.TextAlign = ContentAlignment.MiddleCenter;
                panel.Controls.Add(label);
                labels[counter2] = label;
                

                Button start = new Button();
                start.Text = $"Start";
                start.Width = panel.Width;
                start.AutoSize = true;
                start.MaximumSize = new Size(panel.Width / 2, 100);
                start.Top = panel.Height - 70;
                start.Left = panel.Width / 4;
                start.Font = font1;
                start.TextAlign = ContentAlignment.MiddleCenter;
                start.Cursor = Cursors.Hand;
                start.Click += Start;

                timers[counter3] = new CustomTimer(labels[counter2]  ,"bell.wav", name.Text);

                panel.Controls.Add(start);
                buttons[counter3] = start;

                counter3++; 
                counter2++;
            }
        }
    }
}
