using Guessgame.Klassen_GameLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessgame.Klassen_Game.Math_Algorithm
{
    internal class CheckFactorialNumber : ICheckers
    {
        private bool check = false;
        private string? MessageString;
        private readonly GameLanguages gameLanguages = new();
        // Diese Funktion checkt, ob die gegebene Nummer eine Fakultätszahl ist.
        public bool GetCheckers(int NumberToCheck)
        {
            // Wenn die Nummer 1 ist, ist sie definitiv eine Fakultätszahl.
            if (NumberToCheck == 1)
            {
                check = true;
                return check;
            }

            // Wir starten mit i=1 und der Fakultätszahl als 1.
            int i = 1;
            int FactorialNumber = 1;

            // Solange die Fakultätszahl kleiner ist als die zu prüfende Nummer, machen wir weiter.
            while (FactorialNumber < NumberToCheck)
            {
                i++;
                FactorialNumber *= i;  // Wir multiplizieren die Fakultätszahl mit i.

                // Wenn die Fakultätszahl größer wird als die zu prüfende Nummer, ist es keine Fakultätszahl.
                if (FactorialNumber > NumberToCheck)
                {
                    check = false;
                    return check;
                }
            }

            // Wenn die Fakultätszahl gleich der zu prüfenden Nummer ist, ist es eine Fakultätszahl.
            if (FactorialNumber == NumberToCheck)
            {
                check = true;
            }

            // Wir geben zurück, ob es eine Fakultätszahl ist oder nicht.
            return check;
        }

        // Diese Funktion gibt einen Text zurück, der sagt, ob es eine Fakultätszahl ist oder nicht.
        public override string ToString()
        {
            if (check)
            {
                MessageString = gameLanguages.SetTHMessageStrings("FactorialNumber","Tipps");
            }
            else
            {
                MessageString = gameLanguages.SetTHMessageStrings("NotFactorialNumber","Tipps");
            }
            return MessageString;
        }
    }
}
