using Guessgame.Klassen_GameLanguages;
using System;

namespace Guessgame.Klassen_Game.Math_Algorithm
{
    internal class CheckHarshadNumber : ICheckers
    {
        private bool check = false;
        private string? MessageString;
        private readonly GameLanguages gameLanguages = new();
        // Diese Funktion checkt, ob die gegebene Nummer eine Harshad-Zahl ist.
        public bool GetCheckers(int NumberToCheck)
        {
            int sumOfDigits = 0;  // Hier speichern wir die Summe der Ziffern.
            int temp = NumberToCheck;  // Wir machen eine Kopie der Nummer, damit wir sie verändern können.

            // Wir addieren die Ziffern der Nummer.
            while (temp > 0)
            {
                sumOfDigits += temp % 10;  // Wir nehmen die letzte Ziffer und addieren sie zur Summe.
                temp /= 10;  // Wir entfernen die letzte Ziffer.
            }

            // Wenn die Nummer durch die Summe der Ziffern teilbar ist, ist es eine Harshad-Zahl.
            if (NumberToCheck % sumOfDigits == 0)
            {
                check = true;
            }

            // Wir geben zurück, ob es eine Harshad-Zahl ist oder nicht.
            return check;
        }

        // Diese Funktion gibt einen Text zurück, der sagt, ob es eine Harshad-Zahl ist oder nicht.
        public override string ToString()
        {
            if (check)
            {
                MessageString = gameLanguages.SetTHMessageStrings("HarshadNumber","Tipps");
            }
            else
            {
                MessageString = gameLanguages.SetTHMessageStrings("NotHarshadNumber","Tipps");
            }
            return MessageString;
        }
    }
}
