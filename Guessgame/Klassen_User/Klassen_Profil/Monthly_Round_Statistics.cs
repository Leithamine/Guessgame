using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
//using Guessgame.Klassen_GameHome;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Drawing;
using Microsoft.VisualBasic.ApplicationServices;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Data;

namespace Guessgame.Klassen_User.Klassen_Profil
{
    internal class Monthly_Round_Statistics : IData
    {

        public List<Dictionary<string, object>> Data = new();
        public List<Dictionary<string, object>> GetData(SqlConnection? Con, int userID, int month, int year)
        {
            using SqlCommand cmd = new("GetMonthlyStats", Con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@UserID", userID);
            cmd.Parameters.AddWithValue("@Year", year);
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
