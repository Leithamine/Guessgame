using Guessgame.Klassen_GameLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessgame.Klassen_Game.Hints
{
    internal class SumeDigit : IHint
    {
        // Wir haben eine Variable namens sumdigit, die die Summe der Ziffern speichern wird.
        public int sumdigit = 0;
        private string? MessageString;
        private readonly GameLanguages gameLanguages = new();

        // Diese Methode berechnet die Summe der Ziffern der zu überprüfenden Nummer.
        public void GetHint(int NumberToCheck)
        {
            // Wir durchlaufen jede Ziffer der Nummer.
            foreach (char digit in NumberToCheck.ToString())
            {
                // Wir addieren den Wert der Ziffer zur sumdigit hinzu.
                sumdigit += Convert.ToInt32(digit.ToString());
            }
        }

        // Diese Methode gibt die Summe der Ziffern als String zurück.
        public override string ToString()
        {
            MessageString = gameLanguages.SetTHMessageStrings("SumeDigit", "Hints");
            return MessageString + " " + sumdigit.ToString();
        }

    }
}
