using Guessgame.Klassen_Game.Game;
using Guessgame.Klassen_Game.Game.Animation;
using Guessgame.Klassen_User.Klassen_Profil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guessgame
{
    public partial class Learn : Form
    {
        private DescriptionManager DManager;
        private readonly DatabaseManager DbManager = new();
        int Dindex = 0;
        private readonly Gameuser gamer;
        private readonly Gespraeche Dialog = new();
        private int dialogIndex = 0;
        private List<string> sentences = new();
        private bool check = false, Checkclose = false;
        private readonly GameLanguage? lang;

        public Learn(Gameuser gameuser, GameLanguage CultureLanguage)
        {
            lang = CultureLanguage;
            DManager = new DescriptionManager(lang);
            InitializeComponent();
            gamer = gameuser;
        }

        private void Learn_Load(object sender, EventArgs e)
        {
            if (DbManager.GetGameStat(gamer.UserID) == 0)
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                listBox1.Visible = false;
                sentences = Dialog.Introduce(gamer.Username);
                timer1.Start();
                DManager.GenerateDescription(listBox1, 0);
                Dindex = 0;
            }
            else if (DbManager.GetGameStat(gamer.UserID) > 0)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                button1.Visible = false;
                button2.Visible = true;
                button3.Visible = true;
                listBox1.Visible = true;
                DManager.GenerateDescription(listBox1, 1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dindex++;
            // Check if we can go to the next index
            if (Dindex <= DManager.Indices.Count)
            {
                DManager.GenerateDescription(listBox1, Dindex);
            }
            // Show or hide buttons based on the current index
            button1.Visible = Dindex > 1;
            button2.Visible = Dindex < DManager.Indices.Count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dindex--;
            // Check if we can go to the previous index
            if (Dindex >= 1)
            {
                DManager.GenerateDescription(listBox1, Dindex);
            }
            // Show or hide buttons based on the current index
            button1.Visible = Dindex > 1;
            button2.Visible = Dindex < DManager.Indices.Count;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            dialogIndex++;  // Move to the next sentence

            if (dialogIndex >= sentences.Count && !check)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                //button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                listBox1.Visible = true;
                timer1.Stop();
            }
            else if (dialogIndex >= sentences.Count && check)
            {
                Checkclose = true;
                Close();
                //Game game = new(gamer);
                //game.Show();
            }

            pictureBox2.Invalidate();  // Force the PictureBox to repaint
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            Dialog.ShowDialog(e, dialogIndex, sentences);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            check = true;
            dialogIndex = 0;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            listBox1.Visible = false;
            button3.Visible = false;
            sentences = Dialog.StartGame(gamer?.Username);
            timer1.Start();
        }

        private void Learn_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !Checkclose)
            {
                e.Cancel = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Checkclose = true;
            //Game game = new(gamer);
            //game.Show();
            Close();
        }
    }
}
