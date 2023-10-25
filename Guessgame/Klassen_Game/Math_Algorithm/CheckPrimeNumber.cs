using Guessgame.Klassen_GameLanguages;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessgame.Klassen_Game.Math_Algorithm
{
    internal class CheckPrimeNumber : ICheckers
    {
        private bool check = true;
        private string? MessageString;
        private readonly GameLanguages gameLanguages = new();
        
        // Diese Funktion checkt, ob die gegebene Nummer eine Primzahl ist.
        public bool Prime(int NumberToCheck)
        {
            // Wir gehen alle Zahlen von 2 bis zur Hälfte der zu prüfenden Nummer durch.
            for (int i = 2; i <= (NumberToCheck / 2); i++)
            {
                // Wenn i ein Teiler ist, ist die Nummer keine Primzahl.
                if (NumberToCheck % i == 0)
                {
                    check = false;
                    break;
                }
                else
                {
                    check = true;
                }
            }
            // Wir geben zurück, ob es eine Primzahl ist oder nicht.
            return check;
        }

        // Diese Funktion ist eigentlich das gleiche wie die Funktion Prime.
        // Es checkt auch, ob die gegebene Nummer eine Primzahl ist.
        public bool GetCheckers(int NumberToCheck)
        {
            // Wir gehen alle Zahlen von 2 bis zur Hälfte der zu prüfenden Nummer durch.
            for (int i = 2; i <= (NumberToCheck / 2); i++)
            {
                // besonderer Fall 1
                if (NumberToCheck == 1)
                {
                    check = true;
                    break;
                }
                // Wenn i ein Teiler ist, ist die Nummer keine Primzahl.
                if (NumberToCheck % i == 0)
                {
                    check = false;
                    break;
                }
                else
                {
                    check = true;
                }
            }
            // Wir geben zurück, ob es eine Primzahl ist oder nicht.
            return check;
        }

        // Diese Funktion gibt einen Text zurück, der sagt, ob es eine Primzahl ist oder nicht.
        public override string ToString()
        {
            if (check == true)
            {
                MessageString = gameLanguages.SetTHMessageStrings("PrimeNumber","Tipps");
            }
            else
            {
                MessageString = gameLanguages.SetTHMessageStrings("NotPrimeNumber","Tipps");
            }
            return MessageString;
        }

    }
}