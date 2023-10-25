using Guessgame.Klassen_GameLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessgame.Klassen_Game.Math_Algorithm
{
    internal class CheckAutomorphicNumber : ICheckers
    {
        private bool check = false;
        private string? MessageString;
        private readonly GameLanguages gameLanguages = new();
        // Diese Funktion checkt, ob die gegebene Nummer eine automorphe Nummer ist.
        public bool GetCheckers(int NumberToCheck)
        {
            // Wir quadrieren die Nummer zuerst.
            int Result = NumberToCheck * NumberToCheck;

            // Dann machen wir die Nummer und das Quadrat zu Strings.
            string NumberIntoStr = NumberToCheck.ToString();
            string ResultStr = Result.ToString();

            // Jetzt schauen wir, ob das Quadrat mit der Nummer endet.
            if (ResultStr.EndsWith(NumberIntoStr))
            {
                // Wenn ja, dann ist es eine automorphe Nummer.
                check = true;
            }

            // Wir geben zurück, ob es eine automorphe Nummer ist oder nicht.
            return check;
        }

        // Diese Funktion gibt einen Text zurück, der sagt, ob es eine automorphe Nummer ist oder nicht.
        public override string ToString()
        {
            if (check)
            {
                MessageString = gameLanguages.SetTHMessageStrings("AutomorphicNumber", "Tipps");
            }
            else
            {
                MessageString = gameLanguages.SetTHMessageStrings("NotAutomorphicNumber", "Tipps");
            }
            return MessageString;
        }
    }
}
