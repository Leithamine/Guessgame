using Guessgame.Klassen_User.Klassen_Profil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Guessgame.Klassen_Game.Game
{
    internal class GameRecords
    {
        public int Tries { get; set; }
        public int UsedHints { get; set; }
    }
}
