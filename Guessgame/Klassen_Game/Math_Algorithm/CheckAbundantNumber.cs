using Guessgame.Klassen_GameLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessgame.Klassen_Game.Math_Algorithm
{
    internal class CheckAbundantNumber : ICheckers
    {
        private string? MessageString;
        private readonly GameLanguages gameLanguages = new();      
        private bool check = false;
        // Diese Funktion checkt, ob die gegebene Nummer eine Überflusszahl ist.
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

            // Wenn die Summe der Teiler größer ist als die Nummer, ist es eine Überflusszahl.
            if (sum > NumberToCheck)
            {
                check = true;
            }

            // Wir geben zurück, ob es eine Überflusszahl ist oder nicht.
            return check;
        }

        // Diese Funktion gibt einen Text zurück, der sagt, ob es eine Überflusszahl ist oder nicht.
        public override string ToString()
        {
            if (check)
            {
                MessageString = gameLanguages.SetTHMessageStrings("AbundantNumber","Tipps");
            }
            else
            {
                MessageString = gameLanguages.SetTHMessageStrings("NotAbundantNumber", "Tipps");
            }
            return MessageString;
        }
    }
}