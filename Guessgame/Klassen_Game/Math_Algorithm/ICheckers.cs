using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessgame.Klassen_Game.Math_Algorithm
{
    // Dies ist ein Interface ICheckers.
    // Klassen, die dieses Interface implementieren, müssen die Methoden GetCheckers und ToString haben.
    internal interface ICheckers
    {
        // Diese Methode nimmt eine Nummer als Parameter und gibt zurück, ob sie eine spezielle Eigenschaft hat oder nicht.
        // Zum Beispiel, ob es eine Primzahl, eine Quadratzahl usw. ist.
        bool GetCheckers(int NumberToCheck);

        // Diese Methode gibt einen String zurück, der die Eigenschaft der Nummer beschreibt.
        // Zum Beispiel: "Diese Nummer ist eine Primzahl" oder "Diese Nummer ist keine Quadratzahl".
        string ToString();
    }

}
