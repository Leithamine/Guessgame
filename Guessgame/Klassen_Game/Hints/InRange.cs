using Guessgame.Klassen_GameLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessgame.Klassen_Game.Hints
{
    internal class InRange: IHint
    {
        // Wir haben zwei Variablen für die untere und obere Grenze des Hinweises.
        public int Lower, high;
        private string? MessageString;
        private readonly GameLanguages gameLanguages = new();

        // Wir erstellen ein Random-Objekt, um zufällige Zahlen zu generieren.
        readonly Random ran = new();

        // Diese Methode generiert einen Hinweis für die zu erratende Nummer.
        public void GetHint(int NumberToGuess)
        {
            // Wenn die Nummer kleiner als 50 ist, setzen wir die Grenzen entsprechend.
            if (NumberToGuess < 50)
            {
                // Wir stellen sicher, dass die untere und obere Grenze nicht gleich sind.
                while (Lower == high)
                {
                    Lower = ran.Next(1, NumberToGuess);
                    high = ran.Next(NumberToGuess, 50);
                }
            }
            else  // Wenn die Nummer 50 oder größer ist, setzen wir andere Grenzen.
            {
                // Wir stellen wieder sicher, dass die untere und obere Grenze nicht gleich sind.
                while (Lower == high)
                {
                    Lower = ran.Next(50, NumberToGuess);
                    high = ran.Next(NumberToGuess, 100);
                }
            }
        }

        // Diese Methode gibt den generierten Hinweis als String zurück.
        public override string ToString()
        {
            MessageString = gameLanguages.SetTHMessageStrings("InRange","Hints");
            return MessageString + " " + Lower.ToString() + " and " + high.ToString();
        }

    }
}
