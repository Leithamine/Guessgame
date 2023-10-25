using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessgame.Klassen_Game.Game
{
    internal class RandomNumberGenerator
    {
        private readonly Random randomnumber = new();
        public int Generated_number { get; private set; }
        public int Random_number(int minvalue, int maxvalue)
        {
            return Generated_number = randomnumber.Next(minvalue, maxvalue + 1);
        }
    }
}
