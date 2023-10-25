using Guessgame.Klassen_GameLanguages;
using System;


namespace Guessgame.Klassen_Game.Math_Algorithm
{

    internal class CheckSexyPrime : ICheckers
    {
        private bool check;
        private string? MessageString;
        private readonly GameLanguages gameLanguages = new();
        private readonly CheckPrimeNumber returnprime = new();

        // Diese Funktion checkt, ob die gegebene Nummer Teil eines Sexy-Prime-Paares ist.
        public bool GetCheckers(int NumberToCheck)
        {
            // wir prüfen erstmal, ob die Nummer ist überhaupt prime
            if (returnprime.GetCheckers(NumberToCheck))
            {
                //Wenn JA
                // Wir nutzen die GetCheckers-Funktion, um zu prüfen, ob die (Nummer + 6) oder die (Nummer - 6) beide Primzahlen sind.
                if (returnprime.GetCheckers(NumberToCheck + 6) || returnprime.GetCheckers(NumberToCheck - 6))
                {
                    // Wenn JA, dann ist diese Nummer Teil eines Sexy Prime-Paares.
                    check = true;
                }
                else
                {
                    check = false;
                }
            }
            // Wir geben zurück, ob die Nummer Teil eines Sexy-Prime-Paares ist oder nicht.
            return check;
        }

        // Diese Funktion gibt einen Text zurück, der sagt, ob die Nummer Teil eines Sexy-Prime-Paares ist oder nicht.
        public override string ToString()
        {
            if (check)
            {
                MessageString = gameLanguages.SetTHMessageStrings("SexyPrimeNumber","Tipps");
            }
            else
            {
                MessageString = gameLanguages.SetTHMessageStrings("NotSexyPrimeNumber","Tipps");
            }
            return MessageString;
        }

    }
}
