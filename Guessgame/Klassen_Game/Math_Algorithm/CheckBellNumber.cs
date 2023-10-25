using Guessgame.Klassen_GameLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessgame.Klassen_Game.Math_Algorithm
{
    internal class CheckBellNumber : ICheckers
    {
        private bool check = false;
        private string? MessageString;
        private readonly GameLanguages gameLanguages = new();
        // Diese Funktion gibt die Bell-Nummer für eine gegebene Position aus.
        public static int BellNumber(int n)
        {
            // Erstellen eines 2D-Arrays für die Bell-Nummern
            // Wir verwenden ein Array, weil Bell-Nummern auf einem Bell-Dreieck basieren.
            // Das Array speichert dieses Dreieck.
            int[,] bell = new int[n + 1, n + 1];
            bell[0, 0] = 1;  // Die erste Bell-Nummer ist immer 1
            // Schleifen, um die Bell-Nummern zu berechnen
            for (int i = 1; i <= n; i++)
            {
                // Die nächste Bell-Nummer ist die letzte in der vorherigen Zeile
                bell[i, 0] = bell[i - 1, i - 1];
                for (int j = 1; j <= i; j++)
                {
                    // Bell-Nummern durch Addition der vorherigen Werte berechnen
                    bell[i, j] = bell[i - 1, j - 1] + bell[i, j - 1];
                }
            }
            // Die n-te Bell-Nummer zurückgeben
            return bell[n, 0];
        }

        // Methode, die prüft, ob die gegebene Nummer eine Bell-Nummer ist
        public bool GetCheckers(int NumberToCheck)
        {
            int i = 0;
            while (true)
            {
                // Die i-te Bell-Nummer berechnen
                int bell = BellNumber(i);
                if (bell == NumberToCheck)
                {
                    // Wenn die Nummer gefunden wird, setzen wir 'check' auf true und brechen die Schleife ab
                    check = true;
                    break;
                }
                else if (bell > NumberToCheck)
                {
                    // Wenn die Bell-Nummer größer ist, brechen wir die Schleife ab
                    break;
                }
                i++;
            }
            // Wert von 'check' zurückgeben
            return check;
        }

        // Methode, die einen String zurückgibt, der angibt, ob die Nummer eine Bell-Nummer ist oder nicht
        public override string ToString()
        {
            if (check)
            {
                MessageString = gameLanguages.SetTHMessageStrings("BellNumber", "Tipps");
            }
            else
            {
                MessageString = gameLanguages.SetTHMessageStrings("NotBellNumber", "Tipps");
            }
            return MessageString;
        }
    }
}