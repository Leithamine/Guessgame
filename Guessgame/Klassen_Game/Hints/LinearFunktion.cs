using Guessgame.Klassen_GameLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessgame.Klassen_Game.Hints
{
    internal class LinearFunktion:IHint
    {
        // Wir haben zwei Variablen a und b, die wir für den Hinweis verwenden werden.
        public int a, b;
        private string? MessageString;
        private readonly GameLanguages gameLanguages = new();

        // Diese Methode generiert einen Hinweis für die zu erratende Nummer.
        public void GetHint(int NumberToGuess)
        {
            // Wir erstellen ein neues Random-Objekt, um eine zufällige Zahl zu generieren.
            Random ran = new();

            // Wir setzen a auf eine zufällige Zahl zwischen 5 und 20.
            a = ran.Next(2, 9);

            // Wir setzen b gleich NumberToGuess multipliziert mit a.
            b = NumberToGuess * a;
        }

        // Diese Methode gibt den generierten Hinweis als String zurück.
        public override string ToString()
        {
            MessageString = gameLanguages.SetTHMessageStrings("LinearFunktion", "Hints");
            // Der Hinweis sagt, dass die zu erratende Nummer gleich b geteilt durch a ist.
            return MessageString + b.ToString() + " / " + a.ToString();
        }

    }
}
