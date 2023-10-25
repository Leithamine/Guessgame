using Guessgame.Klassen_User.Klassen_Profil;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessgame.Klassen_User.Klassen_Profil
{
    internal interface IData
    {
        List<Dictionary<string, object>> GetData(SqlConnection? Con, int userId, int month, int year);

    }

}

