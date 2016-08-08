using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MelodyGame
{
    public partial class fGame : Form
    {
        Random rnd = new Random();

        public fGame()
        {
            InitializeComponent();
        }

        void MakeMusic()
        {
            int n = rnd.Next(0, GameClass.list.Count);
            WMP.URL = GameClass.list[n];
            // WMP.Ctlcontrols.play();
            GameClass.list.RemoveAt(n);
            lblSongCounter.Text = GameClass.list.Count.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            timer1.Start();
            MakeMusic();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            WMP.Ctlcontrols.pause();
        }

        private void fGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            WMP.Ctlcontrols.stop();
        }

        private void fGame_Load(object sender, EventArgs e)
        {

            lblSongCounter.Text = GameClass.list.Count.ToString();
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = GameClass.gameDuration;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value++;
            if(progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            timer1.Start();
            WMP.Ctlcontrols.play();
        }
    }
}
