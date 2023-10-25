using Guessgame.Klassen_Game.Game;
using Guessgame.Klassen_GameLanguages;
using Guessgame.Klassen_User.Klassen_Profil;
using Guessgame.ValidationClasses;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Guessgame
{
    public partial class UserProfil : Form
    {
        private readonly Gameuser gamer;
        private DrawChart? drawChart;
        private readonly DatabaseManager dbmanager = new();
        private readonly ValidationUtility validation = new();
        private List<int> years = new();
        private List<string> months = new();
        private List<object> Charts = new();
        private int SelectedId { get; set; }
        private readonly GameLanguages gameLanguages = new();
        private string? MessageString;
        private string? CultureString;
        private readonly GameLanguages homelanguage = new();
        private GameLanguage lang;

        public UserProfil(Gameuser gameuser, GameLanguage Culturelanguage)
        {
            InitializeComponent();
            textBox1.PasswordChar = '*';
            textBox2.PasswordChar = '*';
            textBox3.PasswordChar = '*';
            textBox4.PasswordChar = '*';
            gamer = gameuser;
            lang = Culturelanguage;
            CultureString = lang.SelectedCulture;
        }
        private void UserProfil_Load(object sender, EventArgs e)
        {
            if (CultureString != null)
            {
                gameLanguages.UpdateFormControls(this, CultureString);
            }
            Charts = ReturnChartList();
            ChartsName.DataSource = Charts;
            ChartsName.ValueMember = "ID";
            ChartsName.DisplayMember = "Name";
            ChartsName.SelectedIndex = 0;
            years = dbmanager.YearsPlayed(gamer.UserID);
            if (years.Count >= 1)
            {
                YearsListe.DataSource = years;
                YearsListe.SelectedIndex = 0;
            }
            else
            {
                YearsListe.Enabled = false;
                MonthsListe.Enabled = false;
            }
        }

        private void FilterShowOnChartName(int CharListID)
        {
            if (CharListID == 1 || CharListID == 2 || CharListID == 5 || CharListID == 7)
            {
                YearsListe.Visible = true;
                MonthsListe.Visible = true;
                YearsLabel.Visible = true;
                MonthLabel.Visible = true;
                if (YearsListe.Enabled)
                {
                    BTForShow.Enabled = true;
                }

            }
            else if (CharListID == 3 || CharListID == 4 || CharListID == 6 || CharListID == 8)
            {
                YearsListe.Visible = true;
                MonthsListe.Visible = false;
                YearsLabel.Visible = true;
                MonthLabel.Visible = false;
                if (YearsListe.Enabled)
                {
                    BTForShow.Enabled = true;
                }
            }
            else
            {
                YearsListe.Visible = false;
                MonthsListe.Visible = false;
                YearsLabel.Visible = false;
                MonthLabel.Visible = false;
            }
        }
        private static List<object> ReturnChartList()
        {
            List<object> chartList = new()
            {
                new {ID = 0 , Name = "Menu"},
                new {ID = 1 , Name = "Monthly game usage in Weeks"},
                new {ID = 2 , Name = "Monthly Score developement in weeks"},
                new {ID = 3 , Name = "Yearly game usage in month"},
                new {ID = 4 , Name = "Yearly score developement in month"},
                new {ID = 5 , Name = "Monthly usage Hints and Tries in Weeks"},
                new {ID = 6 , Name = "Yearly usage Hints and Tries in month"},
                new {ID = 7 , Name = "Monthly Stats in Weeks"},
                new {ID = 8 , Name = "Yearly Stats in Months"},
                //new {ID = 9 , Name = "LifeTime Stats"},
            };
            return chartList;
        }

        private void YearsListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            months = dbmanager.AllMonthsPlayed(gamer.UserID, int.Parse(YearsListe.Text));
            MonthsListe.DataSource = months;
            if (months.Count >= 1)
            {
                MonthsListe.SelectedIndex = 0;
            }
            else
            {
                MonthsListe.Enabled = false;
            }
        }

        private void ChartsName_SelectedIndexChanged(object sender, EventArgs e)
        {
            dynamic selectedItem = ChartsName.SelectedItem;
            this.SelectedId = selectedItem.ID;
            FilterShowOnChartName(SelectedId);
            //MessageBox.Show(selectedId.ToString());
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (years.Count >= 1 && months.Count >= 1)
            {
                drawChart = new DrawChart(FormChart, SelectedId, gamer.UserID, int.Parse(YearsListe.Text), DateTime.ParseExact(MonthsListe.Text, "MMMM", CultureInfo.InvariantCulture).Month);
                FormChart.Visible = true;
            }
        }


        private void Button4_Click(object sender, EventArgs e)
        {
            GBEditPassword.Visible = true;
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            if (gamer.HashPassword(textBox1.Text) != gamer.HashedPassword)
            {
                MessageString = gameLanguages.SetMessageStrings("IncorrectPassword");
                MessageBox.Show(MessageString);
                return;
            }
            else
            {
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                LForNewPassword.Enabled = true;
                LForNewPassword2.Enabled = true;
                BForEdit.Enabled = true;
                textBox2.Focus();
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (validation.PasswordCheck(textBox2.Text,this) && validation.PasswordCheck(textBox3.Text, this))
            {
                if (textBox2.Text != textBox3.Text)
                {
                    MessageString = gameLanguages.SetMessageStrings("PasswordNotMatch");
                    MessageBox.Show(MessageString);
                    textBox2.Focus();
                    return;
                }
                else
                {
                    gamer.HashedPassword = gamer.HashPassword(textBox2.Text);
                    if (dbmanager.UpdatePassword(gamer))
                    {
                        MessageString = gameLanguages.SetMessageStrings("PasswordChanged");
                        MessageBox.Show(MessageString);
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox2.Visible = false;
                        textBox3.Visible = false;
                        LForNewPassword.Visible = false;
                        LForNewPassword2.Visible = false;
                        GBEditPassword.Visible = false;
                    }
                    else
                    {
                        MessageString = gameLanguages.SetMessageStrings("PasswordChangeFailed");
                        MessageBox.Show(MessageString);
                    }
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            GBForDeletePassword.Visible = true;

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (gamer.HashPassword(textBox4.Text) != gamer.HashedPassword)
            {
                MessageString = gameLanguages.SetMessageStrings("IncorrectPassword");
                MessageBox.Show(MessageString);
                return;
            }
            else
            {
                if (CBForDelete.Checked)
                {
                    dbmanager.DeleteUser(gamer.Username);
                    MessageString = gameLanguages.SetMessageStrings("UserDeleted");
                    MessageBox.Show(MessageString);
                    GBForDeletePassword.Visible = false;
                }
                else
                {
                    MessageString = gameLanguages.SetMessageStrings("ConfirmDelete");
                    MessageBox.Show(MessageString);
                }
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            FormChart.Visible = false;
        }
    }
}
