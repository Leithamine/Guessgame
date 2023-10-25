using Guessgame.Klassen_GameLanguages;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessgame.Klassen_Game.Math_Algorithm
{
    internal class CheckFibonacciNumber : ICheckers
    {
        private bool check = false;
        private int number1 = 0, number2 = 1, number3 = 0;
        private string? MessageString;
        private readonly GameLanguages gameLanguages = new();
        // Diese Funktion checkt, ob die gegebene Nummer eine Fibonacci-Zahl ist.
        public bool GetCheckers(int NumberToCheck)
        {
            // Wir starten mit den ersten beiden Fibonacci-Zahlen.
            number1 = 0;
            number2 = 1;
            number3 = 0;  // Diese Variable wird die nächste Fibonacci-Zahl speichern.

            // Wir berechnen die Fibonacci-Zahlen, bis wir eine finden, die gleich oder größer als die zu prüfende Nummer ist.
            while (number3 < NumberToCheck)
            {
                number3 = number1 + number2;  // Die nächste Fibonacci-Zahl ist die Summe der beiden vorherigen.
                number1 = number2;  // Jetzt wird die zweite Zahl zur ersten.
                number2 = number3;  // Und die neue Zahl wird zur zweiten.
            }

            // Wenn die gefundene Fibonacci-Zahl gleich der zu prüfenden Nummer ist, ist es eine Fibonacci-Zahl.
            if (number3 == NumberToCheck)
            {
                check = true;
            }

            // Wir geben zurück, ob es eine Fibonacci-Zahl ist oder nicht.
            return check;
        }

        // Diese Funktion gibt einen Text zurück, der sagt, ob es eine Fibonacci-Zahl ist oder nicht.
        public override string ToString()
        {
            if (check == true)
            {
                MessageString = gameLanguages.SetTHMessageStrings("FibonacciNumber","Tipps");
            }
            else
            {
                MessageString = gameLanguages.SetTHMessageStrings("NotFibonacciNumber","Tipps");
            }
            return MessageString;
        }
    }
}
