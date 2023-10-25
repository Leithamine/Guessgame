using Guessgame.Klassen_Game.Game;
using Guessgame.Klassen_Game.Game.Animation;
using Guessgame.Klassen_Game.Game.MessageBoxClasses;
using Guessgame.Klassen_Game.Hints;
using Guessgame.Klassen_Game.Math_Algorithm;
using Guessgame.Klassen_GameLanguages;
using Guessgame.Klassen_User.Klassen_Profil;
using Guessgame.ValidationClasses;

namespace Guessgame
{
    public partial class Game : Form
    {
        private readonly DatabaseManager dbmanager = new();
        private readonly ValidationUtility validation = new();
        private readonly GameLanguages GameLanguages = new();
        private readonly RandomNumberGenerator randomNumber = new();
        private readonly Messages_Management MM = new();
        private Gameuser gameuser;
        private List<string> stringListe = new();
        private readonly List<GameRecords> roundsList = new();
        private readonly Gespraeche Dialog = new();
        private int dialogIndex = 0;
        private GameLanguage lang;
        private List<string> sentences = new();
        public int NumberToGuess { get; private set; }
        public int Tries, score, ScoreCounter, RoundNumberToPlay, UsedHints, UsedTries, GamesPlayed;
        public bool Checkclose = false;
        private string? MessageString;
        private string? CultureString;
        public Game(Gameuser gamer, GameLanguage CultureLanguage)
        {
            InitializeComponent();
            gameuser = gamer;
            SubmitButton.Enabled = false;
            lang = CultureLanguage;
            CultureString = lang.SelectedCulture;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            if (CultureString != null)
            {
                GameLanguages.UpdateFormControls(this, CultureString);
            }
            else
            {
                CultureString = "en-US";
            }
            GameLanguages.UpdateFormControls(this, CultureString);
            Gamer_Information(gameuser);
            GamesPlayed = dbmanager.GetGameStat(gameuser.UserID);
            LabelForHasGameScore.Text = "0";
            sentences = Dialog.GameDialog(GamesPlayed, gameuser.Username);
            timer1.Start();
        }

        private void RecordRound(int usedHints, int tries)
        {
            roundsList.Add(new GameRecords { UsedHints = usedHints, Tries = tries });
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // Überprüfung, ob noch Versuche übrig sind
            if (Tries > 0)
            {
                // Überprüfung, ob die eingegebene Nummer korrekt ist
                //Wenn nicht
                if (NumberToGuess != int.Parse(InputGuessedNumber.Text))
                {
                    MessageString = GameLanguages.SetMessageStrings("WrongNumber");
                    MM.ShowMessage(MessageString,this);
                    ScoreCounter += 2; // Erhöhung dem Punktezähler
                    Tries -= 1; // Verringerung der Anzahl der Versuche
                    InputGuessedNumber.Clear(); // Löschung den Inhalt des Eingabefelds
                    UsedTries++; // Erhöhung der Anzahl der benutzten Versuche
                    SubmitButton.Enabled = false; // Deaktivierung dem Submit-Button
                    GBGame.Focus(); // Setzt den Fokus auf groupBox1
                }
                else
                {
                    // Wenn die Antwort korrekt ist
                    score += (10 - ScoreCounter); // Aktualisierung dem Punktestand
                    LabelForHasGameScore.Text = score.ToString(); // Anzeige den neuen Punktestand
                    Tries = 3; ScoreCounter = 0; // Setzung von Versuche und Punktezähler zurück
                    MessageString = GameLanguages.SetMessageStrings("CorrectNumber");
                    MM.ShowMessage(MessageString, this);
                    RecordRound(UsedHints, UsedTries); // Speicherung der Runde
                    HasTipps.Items.Clear(); // Löschung alle Eigenschaften und Hinweise
                    InputGuessedNumber.Clear(); // Löschung den Inhalt des Eingabefelds
                    RoundNumberToPlay++; // Erhöhung der Runde
                    UsedHints = 0; // Setzung den Anzahl der benutzten Hinweise zurück
                    UsedTries = 0; // Setzung den Anzahl der benutzten Versuche zurück
                    GetCheckersAndHints(); // Holt neue Hinweise und Überprüfungen für den nächsten Nummber
                    BTTipps.Enabled = true; // Aktivierung button1(Hinweise)
                    SubmitButton.Enabled = false; // Deaktivierung den Submit-Button
                }
            }

            // Wenn keine Versuche mehr übrig sind
            if (Tries == 0)
            {
                SubmitButton.Enabled = false; // Deaktivierung den Submit-Button
                dbmanager.UpdateHighscoreUser(gameuser, score); // Aktualisierung den Score des Spieles
                RecordRound(UsedHints, UsedTries); // Speicherung die Runde
                dbmanager.InsertRounds(roundsList); //hinzufügen die Runden zur Datenbank 
                dialogIndex = 0;// Startet den Dialog
                sentences = Dialog.GameOver(gameuser.Username, score);
                timer1.Start();
                GBGame.Visible = false;
                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                Checkclose = true;
            }
            // Aktualisiert die Anzeige für die Rundennummer und die verbleibenden Versuche
            LabelForGetRoundsNumber.Text = RoundNumberToPlay.ToString();
            LabelForSettingRemainingTries.Text = Tries.ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (UsedHints == 0)
            {
                MessageString = GameLanguages.SetMessageStrings("Hints");
                HasTipps.Items.Add(MessageString);
            }
            if (stringListe.Count >= 1)
            {
                var random = new Random();
                var position = random.Next(0, stringListe.Count);
                HasTipps.Items.Add(stringListe[position]);
                stringListe.RemoveAt(position);
                ScoreCounter++;
                UsedHints++;
            }
            else
            {
                BTTipps.Enabled = false;
            }
        }

        private void InputGuessedNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (validation.CheckNumberInput(e, this))
            {
                SubmitButton.Enabled = true;
            }
        }
        private void Gamer_Information(Gameuser gamer)
        {
            LabelForGetRoundsNumber.Text = RoundNumberToPlay.ToString();
            LabelForHasUserName.Text = gamer.Username;
            LabelForHasUserHighScore.Text = dbmanager.GetHighscore(gamer.UserID).ToString();
            LabelForSettingRemainingTries.Text = Tries.ToString();
            LabelForHasGameScore.Text = "0";
        }
        private void EndButton_Click(object sender, EventArgs e)
        {
            dialogIndex = 0;
            dbmanager.UpdateHighscoreUser(gameuser, score);
            dbmanager.InsertRounds(roundsList);
            GBGame.Visible = false;
            sentences = Dialog.GameOver(gameuser.Username, score);
            GBGame.Visible = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            timer1.Start();
            Checkclose = true;
        }

        private void PRofilButton_Click(object sender, EventArgs e)
        {
            Checkclose = true;
            UserProfil profil = new(gameuser, lang);
            profil.Show();
            profil.FormClosed += (s, args) => this.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            BTStart.Visible = false;
            roundsList.Clear();
            Tries = 3; score = 0; ScoreCounter = 0; RoundNumberToPlay = 1; UsedHints = 0; UsedTries = 0;
            Gamer_Information(gameuser);
            GetCheckersAndHints();
            dbmanager.AddNewGameStat(gameuser.UserID);
            GBGame.Visible = true;
        }

        private void GetCheckersAndHints()
        {
            HasTipps.Items.Clear();
            NumberToGuess = randomNumber.Random_number(1, 100);
            GenerateHintList hintListe = new(NumberToGuess);
            stringListe = hintListe.GenerateHints(NumberToGuess);
            LabelForHasGeneratedRandomNumber.Text = NumberToGuess.ToString();
            GenerateNumberCheckListe CheckForNumbers = new();
            MessageString = GameLanguages.SetMessageStrings("Properties");
            HasTipps.Items.Add(MessageString);
            foreach (string item in CheckForNumbers.ChecksForNumber(NumberToGuess))
            {
                HasTipps.Items.Add(item);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Dialog.ShowDialog(e, dialogIndex, sentences);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            dialogIndex++;
            if (dialogIndex >= sentences.Count)
            {
                BTStart.Visible = true;
            }
            pictureBox1.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Checkclose = true;
            Learn lernen = new(gameuser, lang);
            lernen.FormClosed += (s, args) => Show();
            lernen.Show();
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && Checkclose)
            {
                GBGame.Visible = false;
                MessageString = GameLanguages.SetMessageStrings("CloseGame");
                MM.ShowMessage(MessageString, this);
            }
        }
    }
}