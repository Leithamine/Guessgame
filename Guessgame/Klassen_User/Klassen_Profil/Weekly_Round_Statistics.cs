using System.Data.SqlClient;
using System.Data;

namespace Guessgame.Klassen_User.Klassen_Profil
{
    internal class Weekly_Round_Statistics : IData
    {

        public List<Dictionary<string, object>> Data = new();

        public List<Dictionary<string, object>> GetData(SqlConnection? Con, int userId, int month, int year )
        {
            using SqlCommand cmd = new("GetWeeklyStats", Con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@UserID", userId);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@month", month);
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
