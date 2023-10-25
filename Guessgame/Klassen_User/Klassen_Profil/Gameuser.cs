using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Guessgame.Klassen_User.Klassen_Profil
{
    public class Gameuser
    {
        public string? Username { get; set; }
        public string? HashedPassword { get; set; }
        public int Highscore { get; set; }
        public int UserID { get; set; }


        public string HashPassword(string password)
        {
            byte[] BytesList = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new();
            for (int i = 0; i < BytesList.Length; i++)
            {
                builder.Append(BytesList[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}

