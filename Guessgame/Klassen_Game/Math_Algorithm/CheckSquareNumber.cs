using Guessgame.Klassen_GameLanguages;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessgame.Klassen_Game.Math_Algorithm
{

    internal class CheckSquareNumber : ICheckers
    {
        private bool check = false;
        private string? MessageString;
        private readonly GameLanguages gameLanguages = new();
        // Diese Funktion checkt, ob die gegebene Nummer eine Quadratzahl ist.
        public bool GetCheckers(int NumberToCheck)
        {
            // Wir nehmen die Quadratwurzel der Nummer und prüfen, ob das Ergebnis eine ganze Zahl ist.
            if (Math.Sqrt(NumberToCheck) % 1 == 0)
            {
                check = true;  // Wenn ja, ist es eine Quadratzahl.
            }

            // Wir geben zurück, ob es eine Quadratzahl ist oder nicht.
            return check;
        }

        // Diese Funktion gibt einen Text zurück, der sagt, ob es eine Quadratzahl ist oder nicht.
        public override string ToString()
        {
            if (check == true)
            {
                MessageString = gameLanguages.SetTHMessageStrings("SquareNumber","Tipps");
            }
            else
            {
                MessageString = gameLanguages.SetTHMessageStrings("NotSquareNumber","Tipps");
            }
            return MessageString;
        }

    }
}
