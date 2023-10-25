using Guessgame.Klassen_GameLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessgame.Klassen_Game.Math_Algorithm
{
    internal class CheckCompositeNumber : ICheckers
    {
        private string? MessageString;
        private readonly GameLanguages gameLanguages = new();
        private bool check = false;
        // Wir erstellen eine Instanz der Klasse CheckPrimeNumber, um später zu prüfen, ob eine Nummer eine Primzahl ist.
        private readonly CheckPrimeNumber returnprime = new();

        // Diese Funktion checkt, ob die gegebene Nummer eine zusammengesetzte Nummer ist.
        public bool GetCheckers(int NumberToCheck)
        {
            // Wir nutzen die Methode Prime der Klasse CheckPrimeNumber, um zu prüfen, ob die Nummer eine Primzahl ist.
            if (!returnprime.GetCheckers(NumberToCheck))
            {
                // Wenn die Nummer keine Primzahl ist, dann ist sie eine zusammengesetzte Nummer.
                check = true;
            }

            // Wir geben zurück, ob es eine zusammengesetzte Nummer ist oder nicht.
            return check;
        }

        // Diese Funktion gibt einen Text zurück, der sagt, ob es eine zusammengesetzte Nummer ist oder nicht.
        public override string ToString()
        {
            if (check == false)
            {
                MessageString = gameLanguages.SetTHMessageStrings("NotCompositeNumber","Tipps");
            }
            else
            {
                MessageString = gameLanguages.SetTHMessageStrings("CompositeNumber","Tipps");
            }
            return MessageString;
        }
    }
}