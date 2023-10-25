using Guessgame.Klassen_Game.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guessgame
{
    public partial class Languages : Form
    {
        private string? SelCulture;
        private GameLanguage lang = new();
        public Languages()
        {
            InitializeComponent();
        }

        private void Languages_Load(object sender, EventArgs e)
        {
            // Erstellung von Liste mit der Sprachen
            List<KeyValuePair<string, string>> sprachen = new()
            {
                new KeyValuePair<string, string>("Englisch", "en-US"),
                new KeyValuePair<string, string>("Deutsch", "de-DE")
            };

            // Bindung der Liste mit der ComboBox
            ComboSprache.DataSource = sprachen;
            ComboSprache.DisplayMember = "Key";
            ComboSprache.ValueMember = "Value";
        }

        private void ComboSprache_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectCulture = (KeyValuePair<string, string>)ComboSprache.SelectedItem;
            SelCulture = selectCulture.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Function to open HomeGameForm with the Parameter Culture
            if (SelCulture != null)
            {
                CultureInfo culture = new(SelCulture);
                lang.SelectedCulture = SelCulture;
                HomeGame home = new(lang);
                home.Show();
                Hide();
                home.FormClosed += (s, args) => Close();
            }
        }
    }
}
