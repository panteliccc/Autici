using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autici
{
    public class CustomTimer
    {
        private Timer timer;
        private Label label;
        private int remainingTime;
        private SoundPlayer soundPlayer;
        private string name;
        private int time = 600;

        public int getTime(int time)
        {
            this.time = time;  
            return this.time;
        }
        public CustomTimer() { }
        public CustomTimer(Label label, string soundFileName, string name)
        {
            this.label = label;
            this.name = name;

            if(time != 600) this.remainingTime = time;
            else this.remainingTime = 600;

            int minutes = remainingTime / 60;
            int seconds = remainingTime % 60;

            label.Text = $"{minutes:00}:{seconds:00}";

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;

            string executableDirectory = Application.StartupPath;
            string soundFilePath = System.IO.Path.Combine(executableDirectory, soundFileName);

            soundPlayer = new SoundPlayer(soundFilePath);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            int minutes = remainingTime / 60;
            int seconds = remainingTime % 60;

            label.Text = $"{minutes:00}:{seconds:00}";
            remainingTime--;

            if (remainingTime < 0)
            {
                timer.Stop(); 
                soundPlayer.Play();
                DialogResult result = MessageBox.Show($"Vreme isteklo za {name}", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    label.Text = "10:00";
                    remainingTime = 10 * 60 ; 
                }
            }
        }

        public void StartTimer()
        {
            timer.Start();
        }
    }
}
