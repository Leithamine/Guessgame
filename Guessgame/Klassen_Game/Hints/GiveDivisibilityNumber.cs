using Guessgame.Klassen_Game.Math_Algorithm;
using Guessgame.Klassen_GameLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessgame.Klassen_Game.Hints
{
    internal class GiveDivisibilityNumber : IHint
    {
        private static readonly List<int> divisor = new();
        private string? MessageString;
        private readonly GameLanguages gameLanguages = new();
        // Diese Methode gibt Hinweise, indem sie die Teiler der gegebenen Nummer findet.
        public void GetHint(int NumberToCheck)
        {
            // Wir leeren die Liste der Teiler zuerst, falls sie schon gefüllt ist.
            divisor.Clear();

            // Wir suchen nach Teilern bis zur Quadratwurzel der Nummer.
            for (int i = 2; i <= Math.Sqrt(NumberToCheck); i++)
            {
                // Wenn die Nummer durch i teilbar ist, fügen wir i und NumberToCheck/i zur Liste hinzu.
                if (NumberToCheck % i == 0)
                {
                    if (i == (NumberToCheck / i))
                    {
                        divisor.Add(i);  // Nur einmal hinzufügen, wenn i und NumberToCheck/i gleich sind.
                    }
                    else
                    {
                        divisor.Add(i);
                        divisor.Add(NumberToCheck / i);
                    }
                }
                else
                {
                    continue;  // Wenn nicht teilbar, dann weiter zur nächsten Iteration.
                }
            }
        }

        // Diese Methode gibt die Liste der Teiler zurück.
        public static List<int> GetDivisor()
        {
            return divisor;
        }

        // Diese Methode gibt einen zufälligen Hinweis zurück, indem sie einen zufälligen Teiler auswählt.
        public override string ToString()
        {
            MessageString = gameLanguages.SetTHMessageStrings("DivisibilityNumber", "Hints");
            Random randomHint = new();
            int hint = randomHint.Next(0, divisor.Count - 1);
            return MessageString + " " + divisor[hint].ToString();
        }

    }
}
