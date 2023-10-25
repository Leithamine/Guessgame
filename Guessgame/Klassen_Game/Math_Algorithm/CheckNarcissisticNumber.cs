using Guessgame.Klassen_GameLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Guessgame.Klassen_Game.Math_Algorithm
{
    internal class CheckNarcissisticNumber : ICheckers
    {
        private bool check = false;
        private string? MessageString;
        private readonly GameLanguages gameLanguages = new();
        // Diese Funktion checkt, ob die gegebene Nummer eine narzisstische Zahl ist.
        public bool GetCheckers(int NumberToCheck)
        {
            string NumberToString = NumberToCheck.ToString();  // Wir machen die Nummer zu einem String.

            int len = NumberToString.Length;  // Wir finden heraus, wie viele Ziffern die Nummer hat.

            int sum = 0;  // Hier speichern wir die Summe.

            // Wir gehen durch jede Ziffer der Nummer.
            foreach (char Character in NumberToString)
            {
                int CharToInt = int.Parse(Character.ToString());  // Wir machen die Ziffer zu einer Zahl.

                // Wir addieren die Ziffer hoch die Anzahl der Ziffern zur Summe.
                sum += (int)Math.Pow(CharToInt, len);
            }

            // Wenn die Summe gleich der ursprünglichen Nummer ist, ist es eine narzisstische Zahl.
            if (NumberToCheck == sum)
            {
                check = true;
            }

            // Wir geben zurück, ob es eine narzisstische Zahl ist oder nicht.
            return check;
        }

        // Diese Funktion gibt einen Text zurück, der sagt, ob es eine narzisstische Zahl ist oder nicht.
        public override string ToString()
        {
            if (check == true)
            {
                MessageString = gameLanguages.SetTHMessageStrings("NarrcissisticNumber", "Tipps");
            }
            else
            {
                MessageString = gameLanguages.SetTHMessageStrings("NotNarrcissisticNumber", "Tipps");
            }
            return MessageString;
        }
    }
}
