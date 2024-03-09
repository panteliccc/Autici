using System;
using System.Media;
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
        private int initialTime = 600;

        public CustomTimer() { }

        public CustomTimer(Label label, string soundFileName, string name, int initialTime)
        {
            this.label = label;
            this.name = name;
            SetInitialTime(initialTime);

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;

            string executableDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string soundFilePath = System.IO.Path.Combine(executableDirectory, "Resources", soundFileName);
            soundPlayer = new SoundPlayer(soundFilePath);
        }

        public void SetInitialTime(int newInitialTime)
        {
            this.initialTime = newInitialTime;
            this.remainingTime = this.initialTime;
            UpdateLabel();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            remainingTime--;

            if (remainingTime >= 0)
            {
                UpdateLabel();
            }
            else
            {
                timer.Stop();
                soundPlayer.Play();
                DialogResult result = MessageBox.Show($"Vreme isteklo za {name}", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    SetInitialTime(initialTime);
                }
            }
        }

        private void UpdateLabel()
        {
            int minutes = remainingTime / 60;
            int seconds = remainingTime % 60;

            label.Text = $"{minutes:00}:{seconds:00}";
        }

        public void StartTimer()
        {
            timer.Start();
        }
    }
}
