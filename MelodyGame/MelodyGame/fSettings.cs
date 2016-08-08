using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MelodyGame
{
    public partial class fSettings : Form
    {
        public fSettings()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            GameClass.foldersInclude = cbInclude.Checked;
            GameClass.gameDuration = Convert.ToInt32(cbGameDuration.Text);
            GameClass.musicDuration = Convert.ToInt32(cbMusicDuration.Text);
            GameClass.randomStart = cbRandomStart.Checked;
            GameClass.playerOne = tbPlayer1.Text;
            GameClass.playerTwo = tbPlayer2.Text;
            GameClass.WriteParam();
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Set();
            this.Hide();
        }

        void Set()
        {
            cbInclude.Checked = GameClass.foldersInclude;
            cbGameDuration.Text = GameClass.gameDuration.ToString();
            cbMusicDuration.Text = GameClass.musicDuration.ToString();
            cbRandomStart.Checked = GameClass.randomStart;
            tbPlayer1.Text = GameClass.playerOne;
            tbPlayer2.Text = GameClass.playerTwo;
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog() == DialogResult.OK)
            {
                string[] music_list = Directory.GetFiles(fbd.SelectedPath, "*.mp3", cbInclude.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                GameClass.lastFolder = fbd.SelectedPath;
                listBox1.Items.Clear();
                listBox1.Items.AddRange(music_list);
                GameClass.list.Clear();
                GameClass.list.AddRange(music_list);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void fSettings_Load(object sender, EventArgs e)
        {
            Set();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(GameClass.list.ToArray());
        }

        private void cbRandomStart_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lbPlayer2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbPlayer1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
