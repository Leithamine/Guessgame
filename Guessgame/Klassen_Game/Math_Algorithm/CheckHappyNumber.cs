using Guessgame.Klassen_GameLanguages;
using System;
using System.Collections.Generic;

namespace Guessgame.Klassen_Game.Math_Algorithm
{
    internal class CheckHappyNumber : ICheckers
    {
        private bool check = false;
        private string? MessageString;
        private readonly GameLanguages gameLanguages = new();
        // Diese Funktion berechnet die Summe der Quadrate der Ziffern einer Nummer.
        private static int GetSum(int number)
        {
            int sum = 0;  // Hier speichern wir die Summe.
                          // Wir gehen durch jede Ziffer der Nummer.
            foreach (char digitChar in number.ToString())
            {
                int digit = int.Parse(digitChar.ToString());  // Wir machen die Ziffer zu einer Zahl.
                sum += digit * digit;  // Wir addieren das Quadrat der Ziffer zur Summe.
            }
            return sum;  // Wir geben die Summe zurück.
        }

        // Diese Funktion checkt, ob die gegebene Nummer eine glückliche Nummer ist.
        public bool GetCheckers(int NumberToCheck)
        {
            HashSet<int> NumbersListe = new();  // Wir machen eine Liste, um die Zahlen zu speichern, die wir schon hatten.

            // Wir machen weiter, bis wir entweder 1 erreichen oder eine Zahl wiederholen.
            while (NumberToCheck != 1 && !NumbersListe.Contains(NumberToCheck))
            {
                NumbersListe.Add(NumberToCheck);  // Wir fügen die aktuelle Nummer zur Liste hinzu.
                NumberToCheck = GetSum(NumberToCheck);  // Wir berechnen die neue Nummer als die Summe der Quadrate der Ziffern.
            }

            // Wenn wir 1 erreichen, ist es eine glückliche Nummer.
            if (NumberToCheck == 1)
            {
                check = true;
            }

            // Wir geben zurück, ob es eine glückliche Nummer ist oder nicht.
            return check;
        }

        // Diese Funktion gibt einen Text zurück, der sagt, ob es eine glückliche Nummer ist oder nicht.
        public override string ToString()
        {
            if (check == true)
            {
                MessageString = gameLanguages.SetTHMessageStrings("HappyNumber","Tipps");
            }
            else
            {
                MessageString = gameLanguages.SetTHMessageStrings("NotHappyNumber","Tipps");
            }
            return MessageString;
        }

    }
}
