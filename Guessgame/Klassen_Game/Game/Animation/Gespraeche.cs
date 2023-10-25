using EnvDTE;
using Guessgame.Klassen_GameLanguages;
using Guessgame.Klassen_User.Klassen_Profil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Guessgame.Klassen_Game.Game.Animation
{
    internal class Gespraeche
    {
        private readonly GameLanguages gameLanguages = new();
        // Liste der Sätze, die im Dialog angezeigt werden.
        private List<string> Sentences { get; set; } = new();

        // Methode, die den Dialog auf dem Bildschirm anzeigt.
        public void ShowDialog(PaintEventArgs e, int dialogIndex, List<string> Dialog)
        {
            // Überprüfung, ob der Dialogindex gültig ist.
            if (dialogIndex >= Dialog.Count) return;

            // Text und Position für die Anzeige festlegen.
            string text = Dialog[dialogIndex];
            Font font = new ("Verdana", 7, FontStyle.Bold);
            Point location = new (60, 70);

            // Create a RectangleF object and StringFormat object
            RectangleF drawRect = new (location, new SizeF(e.ClipRectangle.Width - 90, e.ClipRectangle.Height - 100)); // assuming 70 is x-position and 50 is y-position of the text
            StringFormat drawFormat = new ()
            {
                LineAlignment = StringAlignment.Near,  // Top of the rectangle
                Alignment = StringAlignment.Near,      // Left of the rectangle
                FormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip
            };

            // Text auf dem Bildschirm zeichnen.
            e.Graphics.DrawString(text, font, new SolidBrush(Color.Black), drawRect, drawFormat);
        }

        // Methode, die die Introduce dialoge zurückgibt.
        public List<string> Introduce(string? Username)
        {
            Sentences = new List<string>
            {
                string.Format(gameLanguages.SetTHMessageStrings("Introduce_Welcome", "Dialog"), Username),
                gameLanguages.SetTHMessageStrings("Introduce_DidYouKnow", "Dialog"),
                gameLanguages.SetTHMessageStrings("Introduce_Roles", "Dialog"),
                gameLanguages.SetTHMessageStrings("Introduce_KnownNumbers", "Dialog"),
                gameLanguages.SetTHMessageStrings("Introduce_OtherNumbers", "Dialog"),
                gameLanguages.SetTHMessageStrings("Introduce_LetMeGuide", "Dialog"),
                gameLanguages.SetTHMessageStrings("Introduce_LetsBegin", "Dialog")
            };
            return Sentences;
        }

        // Methode, die die Spiel-Dialoge zurückgibt.
        public List<string> GameDialog(int? GameStat, string? Username)
        {
            // Dialoge je nach Spielstatus festlegen.
            if (GameStat == 0)
            {
                Sentences = new List<string>
                {
                    string.Format(gameLanguages.SetTHMessageStrings("GameDialog_WelcomeToWorld", "Dialog"), Username),
                    gameLanguages.SetTHMessageStrings("GameDialog_ReadyForChallenge", "Dialog")
                };
            }
            else if (GameStat > 0)
            {
                Sentences = new List<string>
                {
                    string.Format(gameLanguages.SetTHMessageStrings("GameDialog_NiceToSeeYouAgain", "Dialog"), Username),
                    gameLanguages.SetTHMessageStrings("GameDialog_ReadyToTakeChallengeAgain", "Dialog")
                };
            }
            return Sentences;
        }

        // Methode, die den Startspiel-Dialog zurückgibt.
        public List<string> StartGame(string? Username)
        {
            // Startspiel-Dialoge festlegen.
            Sentences = new List<string>
            {
                string.Format(gameLanguages.SetTHMessageStrings("StartGame_WellDone", "Dialog"), Username),
                gameLanguages.SetTHMessageStrings("StartGame_NowYouCanProve", "Dialog"),
                gameLanguages.SetTHMessageStrings("StartGame_HaveFunPlaying", "Dialog"),
            };
            return Sentences;
        }
        public List<string> GameOver(string? Username, int score)
        {
            // GameOver-Dialoge festlegen.
            Sentences = new List<string>
            {
                string.Format(gameLanguages.SetTHMessageStrings("GameOver_Sorry", "Dialog"),Username, score),
                gameLanguages.SetTHMessageStrings("GameOver_DontGiveUp", "Dialog"),
                gameLanguages.SetTHMessageStrings("GameOver_HaveFunNextGame", "Dialog"),
            };
            return Sentences;
        }
    }
}
