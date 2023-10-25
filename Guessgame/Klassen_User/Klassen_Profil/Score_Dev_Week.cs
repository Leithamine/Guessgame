using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Guessgame.Klassen_User.Klassen_Profil;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Drawing;
using Microsoft.VisualBasic.ApplicationServices;
using System.Windows.Forms;
using System.Data;

namespace Guessgame.Klassen_User.Klassen_Profil
{
    internal class Score_Dev_Week : IData
    {
        public List<Dictionary<string, object>> Data = new();
        public List<Dictionary<string, object>> GetData(SqlConnection? Con, int userId, int Month, int year)
        {
            using SqlCommand cmd = new("MonthlyScoreDevelopment", Con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@UserID", userId);
            cmd.Parameters.AddWithValue("@month", Month);
            cmd.Parameters.AddWithValue("@year", year);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Dictionary<string, object> row = new();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string columnName = reader.GetName(i);
                    object value = reader.GetValue(i);
                    row[columnName] = value;
                }
                Data.Add(row);
            }
            reader.Close();
            return Data;
        }
    }
}

