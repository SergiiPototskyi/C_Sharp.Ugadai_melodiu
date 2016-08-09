using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace MelodyGame
{
    public partial class fGame : Form
    {
        Random rnd = new Random();
        int musicDuration = GameClass.musicDuration;

        public fGame()
        {
            InitializeComponent();
        }

        void MakeMusic()
        {
            if (GameClass.list.Count == 0) EndGame();
            else
            {
                musicDuration = GameClass.musicDuration;
                int n = rnd.Next(0, GameClass.list.Count);
                WMP.URL = GameClass.list[n];
                GameClass.answer = WMP.URL;
                // WMP.Ctlcontrols.play();
                GameClass.list.RemoveAt(n);
                lblSongCounter.Text = GameClass.list.Count.ToString();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            timer1.Start();
            MakeMusic();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GamePause();
        }

        private void fGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
            WMP.Ctlcontrols.stop();
        }

        private void fGame_Load(object sender, EventArgs e)
        {

            lblSongCounter.Text = GameClass.list.Count.ToString();
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = GameClass.gameDuration;
            lblPlayer1.Text = GameClass.playerOne;
            lblPlayer2.Text = GameClass.playerTwo;
        }

        void EndGame()
        {
            timer1.Stop();
            WMP.Ctlcontrols.stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value++;
            musicDuration--;
            lblMusicDuration.Text = musicDuration.ToString();
            if(progressBar1.Value == progressBar1.Maximum)
            {
                EndGame();
                return;
            }
            if (musicDuration == 0)MakeMusic();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            GamePlay();
        }

        void GamePause()
        {
            timer1.Stop();
            WMP.Ctlcontrols.pause();
        }

        void GamePlay()
        {
            timer1.Start();
            WMP.Ctlcontrols.play();
        }

        private void fGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (!timer1.Enabled) return;
            if(e.KeyData == Keys.Q)
            {
                GamePause();
                fMessage fm = new fMessage();
                fm.lblMessage.Text = GameClass.playerOne;
                SoundPlayer sp = new SoundPlayer("Resources\\1.wav");
                sp.PlaySync();
                if (fm.ShowDialog() == DialogResult.Yes)
                {
                    lblCounter1.Text = Convert.ToString(Convert.ToInt32(lblCounter1.Text) + 1);
                    MakeMusic();
                }
                else
                {
                    lblCounter1.Text = Convert.ToString(Convert.ToInt32(lblCounter1.Text) - 1);
                }
                GamePlay();
            }
            if (e.KeyData == Keys.P)
            {
                GamePause();
                fMessage fm = new fMessage();
                fm.lblMessage.Text = GameClass.playerTwo;
                SoundPlayer sp = new SoundPlayer("Resources\\2.wav");
                sp.PlaySync();
                if (fm.ShowDialog() == DialogResult.Yes)
                {
                    lblCounter2.Text = Convert.ToString(Convert.ToInt32(lblCounter2.Text) + 1);
                    MakeMusic();
                }
                else
                {
                    lblCounter2.Text = Convert.ToString(Convert.ToInt32(lblCounter2.Text) - 1);
                }
                GamePlay();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblPlayer2_Click(object sender, EventArgs e)
        {

        }

        private void WMP_OpenStateChange(object sender, AxWMPLib._WMPOCXEvents_OpenStateChangeEvent e)
        {
            if (GameClass.randomStart)
                if (WMP.openState == WMPLib.WMPOpenState.wmposMediaOpen)
                    WMP.Ctlcontrols.currentPosition = rnd.Next(0, (int)WMP.currentMedia.duration / 2);
        }

        private void lblCounter1_Click(object sender, EventArgs e)
        {

        }
    }
}
