using Guessgame.Klassen_GameLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessgame.Klassen_Game.Math_Algorithm
{
    internal class CheckDeficientNumber : ICheckers
    {
        private bool check = false;
        private string? MessageString;
        private readonly GameLanguages gameLanguages = new();
        // Diese Funktion checkt, ob die gegebene Nummer eine defiziente Nummer ist.
        public bool GetCheckers(int NumberToCheck)
        {
            // Hier speichern wir die Summe der Teiler.
            int sumOfDivisors = 0;

            // Wir gehen alle Zahlen bis zur Hälfte der zu prüfenden Nummer durch.
            for (int i = 1; i <= NumberToCheck / 2; i++)
            {
                // Wenn i ein Teiler ist, addieren wir es zur Summe.
                if (NumberToCheck % i == 0)
                {
                    sumOfDivisors += i;
                }
            }

            // Wenn die Summe der Teiler kleiner ist als die Nummer, ist es eine defiziente Nummer.
            if (sumOfDivisors < NumberToCheck)
            {
                check = true;
            }

            // Wir geben zurück, ob es eine defiziente Nummer ist oder nicht.
            return check;
        }

        // Diese Funktion gibt einen Text zurück, der sagt, ob es eine defiziente Nummer ist oder nicht.
        public override string ToString()
        {
            if (check)
            {
                MessageString = gameLanguages.SetTHMessageStrings("DeficientNumber", "Tipps");
            }
            else
            {
                MessageString = gameLanguages.SetTHMessageStrings("NotDeficientNumber", "Tipps");
            }
            return MessageString;
        }
    }
}