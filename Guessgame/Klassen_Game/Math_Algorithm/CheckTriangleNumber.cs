using Guessgame.Klassen_GameLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessgame.Klassen_Game.Math_Algorithm
{
    internal class CheckTriangleNumber : ICheckers
    {
        private bool check = false;
        private string? MessageString;
        private readonly GameLanguages gameLanguages = new();
        // Diese Funktion checkt, ob die gegebene Nummer eine Dreieckszahl ist.
        public bool GetCheckers(int NumberToCheck)
        {
            // Wir verwenden die Formel für Dreieckszahlen: n*(n+1)/2 = NumberToCheck
            // Nach Umformung erhalten wir: n^2 + n - 2*NumberToCheck = 0
            // Die Diskriminante dieser quadratischen Gleichung ist: 1 + 8*NumberToCheck
            // Wenn die Quadratwurzel der Diskriminante eine ganze Zahl ist, dann ist NumberToCheck eine Dreieckszahl.
            if (Math.Pow((int)Math.Sqrt(NumberToCheck * 8 + 1), 2) == NumberToCheck * 8 + 1)
            {
                check = true;  // Wenn ja, ist es eine Dreieckszahl.
            }

            // Wir geben zurück, ob es eine Dreieckszahl ist oder nicht.
            return check;
        }

        // Diese Funktion gibt einen Text zurück, der sagt, ob es eine Dreieckszahl ist oder nicht.
        public override string ToString()
        {
            if (check == true)
            {
                MessageString = gameLanguages.SetTHMessageStrings("TriangleNumber","Tipps");
            }
            else
            {
                MessageString = gameLanguages.SetTHMessageStrings("NotTriangleNumber","Tipps");
            }
            return MessageString;
        }

    }
}
