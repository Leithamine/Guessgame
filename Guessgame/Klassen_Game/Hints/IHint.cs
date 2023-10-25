using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessgame.Klassen_Game.Hints
{
    internal interface IHint
    {
        void GetHint(int NumberToCheck);
        string ToString();
    }
}
