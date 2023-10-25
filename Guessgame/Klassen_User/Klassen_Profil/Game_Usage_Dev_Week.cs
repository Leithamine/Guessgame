using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Guessgame.Klassen_User.Klassen_Profil;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Drawing;
using System.Data;

namespace Guessgame.Klassen_User.Klassen_Profil
{
    internal class Game_Usage_Dev_Week : IData
    {
        
        public List<Dictionary<string,object>> Data = new();

        public List<Dictionary<string, object>> GetData(SqlConnection? Con, int userId, int month, int year)
        {
            // Specify the stored procedure name and set the command type
            using SqlCommand cmd = new ("DailyGameUsageMonths", Con)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Add parameters
            cmd.Parameters.AddWithValue("@userID", userId);
            cmd.Parameters.AddWithValue("@month", month); // Assuming you have this property in Gameuser
            cmd.Parameters.AddWithValue("@year", year);  // Assuming you have this property in Gameuser

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Dictionary<string, object> row = new();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string colname = reader.GetName(i);
                    object value = reader.GetValue(i);
                    row.Add(colname, value);
                }
                Data.Add(row);
            }
            reader.Close();
            return Data;
        }
    }
}
