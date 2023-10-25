using Guessgame.Klassen_GameLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessgame.Klassen_Game.Math_Algorithm
{
    internal class CheckPalindromeNumber : ICheckers
    {
        private bool check = false;
        private string? MessageString;
        private readonly GameLanguages gameLanguages = new();
        // Diese Funktion checkt, ob die gegebene Nummer eine Palindromzahl ist.
        public bool GetCheckers(int NumberToCheck)
        {
            int remainder, sum = 0, temporary;  // Wir brauchen diese Variablen für die Berechnung.
            temporary = NumberToCheck;  // Wir speichern die ursprüngliche Nummer, um sie später zu vergleichen.

            // Wir drehen die Nummer um.
            while (NumberToCheck > 0)
            {
                remainder = NumberToCheck % 10;  // Wir nehmen die letzte Ziffer der Nummer.
                sum = (sum * 10) + remainder;  // Wir fügen die Ziffer zur umgedrehten Nummer hinzu.
                NumberToCheck /= 10;  // Wir entfernen die letzte Ziffer.
            }

            // Wenn die umgedrehte Nummer gleich der ursprünglichen Nummer ist, ist es eine Palindromzahl.
            if (temporary == sum)
            {
                check = true;
            }

            // Wir geben zurück, ob es eine Palindromzahl ist oder nicht.
            return check;
        }

        // Diese Funktion gibt einen Text zurück, der sagt, ob es eine Palindromzahl ist oder nicht.
        public override string ToString()
        {
            if (check == true)
            {
                MessageString = gameLanguages.SetTHMessageStrings("PalindromeNumber","Tipps");
            }
            else
            {
                MessageString = gameLanguages.SetTHMessageStrings("NotPalindromeNumber","Tipps");
            }
            return MessageString;
        }

    }
}

