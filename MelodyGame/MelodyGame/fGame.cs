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
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            MakeMusic();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void fGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            WMP.Ctlcontrols.stop();
        }
    }
}
