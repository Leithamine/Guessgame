using Guessgame.Klassen_GameLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessgame.Klassen_Game.Math_Algorithm
{
    internal class CheckPerfectNumber : ICheckers
    {
        private bool check = false;
        private string? MessageString;
        private readonly GameLanguages gameLanguages = new();
        // Diese Funktion checkt, ob die gegebene Nummer eine vollkommene Zahl ist.
        public bool GetCheckers(int NumberToCheck)
        {
            int sum = 0;  // Hier speichern wir die Summe der Teiler.

            // Wir gehen alle Zahlen bis zur Hälfte der zu prüfenden Nummer durch.
            for (int i = 1; i <= NumberToCheck / 2; i++)
            {
                // Wenn i ein Teiler ist, addieren wir es zur Summe.
                if (NumberToCheck % i == 0)
                {
                    sum += i;
                }
            }

            // Wenn die Summe der Teiler gleich der Nummer ist, ist es eine vollkommene Zahl.
            if (sum == NumberToCheck)
            {
                check = true;
            }

            // Wir geben zurück, ob es eine vollkommene Zahl ist oder nicht.
            return check;
        }

        // Diese Funktion gibt einen Text zurück, der sagt, ob es eine vollkommene Zahl ist oder nicht.
        public override string ToString()
        {
            if (check == true)
            {
                MessageString = gameLanguages.SetTHMessageStrings("PerfectNumber", "Tipps");
            }
            else
            {
                MessageString = gameLanguages.SetTHMessageStrings("NotPerfectNumber", "Tipps");
            }
            return MessageString;
        }

    }
}
