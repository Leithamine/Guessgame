using Guessgame.Klassen_Game.Game;
using Guessgame.Klassen_Game.Game.MessageBoxClasses;
using Guessgame.Klassen_GameLanguages;
using Guessgame.Klassen_User.Klassen_Profil;
using Guessgame.ValidationClasses;
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

namespace Guessgame
{
    public partial class HomeGame : Form
    {
        private bool Linklabelclicked = false;
        private readonly ValidationUtility validation = new();
        private readonly DatabaseManager dbmanager = new();
        private readonly GameLanguages homelanguage = new();
        private GameLanguage lang;
        private Messages_Management MManagement = new();
        private string? MessageString;
        private string? CultureString;
        public Gameuser? gamer = new();
        private bool Checkclose = false;

        public HomeGame(GameLanguage Culturelanguage)
        {
            lang = Culturelanguage;
            CultureString = lang.SelectedCulture;
            // Constructor to get the Culture from the LanguageForm
            InitializeComponent();


        }

        //private void groupBox1_Enter(object sender, EventArgs e)
        //{

        //}

        private void Button1_Click(object sender, EventArgs e)
        {
            // check if the Length of the username 
            validation.CheckTextboxLength(textBox1, this);
            // check if the textbox is empty
            validation.CheckEmptyText(textBox1, this);
            // check if the user exists in the database
            gamer = dbmanager.ReadUser(textBox1.Text);
            if (gamer == null)
            {
                MessageString = homelanguage.SetMessageStrings("UserDoesNotExist");
                MManagement.ShowMessage(MessageString, this);
                //MessageBox.Show(MessageString);
                return;
            }
            //if user exists check if the password is correct
            // by hashing the input Password and comparing it to the hashed password in the database
            if (gamer.HashPassword(textBox2.Text) != gamer.HashedPassword)
            {
                MessageString = homelanguage.SetMessageStrings("WrongPassword");
                MManagement.ShowMessage(MessageString, this);
                //MessageBox.Show(MessageString);
                return;
            }
            //if the password is correct open the game
            if (dbmanager.GetGameStat(gamer.UserID) == 0)
            {
                Hide();
                Learn lernen = new(gamer, lang);
                Game newgame = new(gamer, lang);
                lernen.FormClosed += (s, args) => newgame.Show();
                lernen.Show();
            }
            else if (dbmanager.GetGameStat(gamer.UserID) > 0)
            {
                Hide();
                Game newgame = new(gamer, lang);
                newgame.FormClosed += (s, args) => Show();
                newgame.Show();
            }
        }

        private void Conection_Click(object sender, EventArgs e)
        {
            GBAnmeldung.Visible = true;
        }

        private void Register_Click(object sender, EventArgs e)
        {
            GBRegistrierung.Visible = true;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //Check ob den LinkLabel geöffnet wurde und Check Box is gescheckt
            if (checkBox2.Checked && Linklabelclicked)
            {
                //register ein neuer user
                //check the lenght of the username
                validation.CheckTextboxLength(textBox3, this);
                // check if the textbox is empty
                validation.CheckEmptyText(textBox3, this);
                // erstmal checken, ob Passwort erfüllt die Voraussetzungen
                if (!validation.PasswordCheck(textBox4.Text, this /*&& !validation.PasswordCheck(textBox5.Text)*/))
                {
                    return;
                }
                // Wenn Passwort erfüllt die Voraussetzungen, checken ob die Passwörter gleich sind
                else if (textBox5.Text != textBox4.Text)
                {
                    MessageString = homelanguage.SetMessageStrings("UnmatchPassword");
                    MManagement.ShowMessage(MessageString, this);
                    //MessageBox.Show(MessageString);
                    return;
                }
                //checken ob der Username schon existiert
                gamer = dbmanager.ReadUser(textBox3.Text);
                // wenn der Username schon existiert, dann eine Meldung zeigen
                if (gamer != null)
                {
                    MessageString = homelanguage.SetMessageStrings("UserDoesExist");
                    MManagement.ShowMessage(MessageString, this);
                    //MessageBox.Show(MessageString);
                    textBox3.Focus();
                    return;
                }
                // wenn der Username nicht existiert, dann einen neuen User erstellen
                gamer = new Gameuser
                {
                    Username = textBox3.Text
                };
                gamer.HashedPassword = gamer.HashPassword(textBox4.Text);
                gamer.Highscore = 0;

                if (dbmanager.CreateUser(gamer))
                {
                    MessageString = homelanguage.SetMessageStrings("ProfilCreated");
                    MManagement.ShowMessage(MessageString, this);
                    //MessageBox.Show(MessageString);
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear(); checkBox2.Checked = false; checkBox2.Enabled = false; checkBox3.Checked = false; Linklabelclicked = false;
                    ACSPasswort.Checked = false;
                    GBRegistrierung.Visible = false;
                }
                else
                {
                    MessageString = homelanguage.SetMessageStrings("ProfilNotCreated");
                    MManagement.ShowMessage(MessageString, this);
                    //MessageBox.Show(MessageString);
                }
            }
            else
            {
                MessageString = homelanguage.SetMessageStrings("Terms");
                MManagement.ShowMessage(MessageString, this);
                //MessageBox.Show(MessageString);
            }
            //RegisterBox.Visible = false;
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageString = homelanguage.SetMessageStrings("TermsOfUse");
            MManagement.ShowMessage(MessageString, this);
            //MessageBox.Show(MessageString);
            checkBox2.Checked = true;
            //checkBox2.Enabled = true;
            Linklabelclicked = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //diese Function prüft ob Eingabe der benutzername glütig während der Eingabe
            validation.CheckUsernameInput(textBox1, e, this);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //diese Function prüft ob Eingabe der benutzername glütig während der Eingabe
            validation.CheckUsernameInput(textBox3, e, this);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // hier wird gescheckt ob das Passwort soll angezeigt werden  durch den CheckBox
            if (ACSPasswort.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            // hier wird gescheckt ob das Passwort soll angezeigt werden durch den CheckBox
            if (checkBox3.Checked)
            {
                textBox4.PasswordChar = '\0';
                textBox5.PasswordChar = '\0';
            }
            else
            {
                textBox4.PasswordChar = '*';
                textBox5.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GBAnmeldung.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GBRegistrierung.Visible = false;
        }

        private void HomeGame_Load(object sender, EventArgs e)
        {
            //Call the Function from GameLanguages to set the Language with the Culture
            if (CultureString != null)
            {
                homelanguage.UpdateFormControls(this, CultureString);
            }
        }


    }
}
