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
    internal class Hints_Tries_Dev_Week : IData
    {

        public List<Dictionary<string, object>> Data = new();

        public List<Dictionary<string, object>> GetData(SqlConnection? Con, int userId, int Month, int year)
        {
            // Liste für die gesammelten Daten
            List<Dictionary<string, object>> Data = new();

            // SqlCommand-Objekt für die gespeicherte Prozedur erstellen
            using SqlCommand cmd = new("WeeklyTriesAndHintsSummary", Con)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Parameter für die gespeicherte Prozedur setzen
            cmd.Parameters.AddWithValue("@UserID", userId);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@month", Month);
            // SQL-Anfrage ausführen und Ergebnisse lesen
            SqlDataReader reader = cmd.ExecuteReader();
            // Alle Zeilen im Ergebnis lesen
            while (reader.Read())
            {
                // Ein Dictionary für jede Zeile erstellen
                Dictionary<string, object> row = new();
                // Alle Spalten in der aktuellen Zeile durchgehen
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    // Spaltenname und Wert abrufen
                    string colname = reader.GetName(i);
                    object value = reader.GetValue(i);
                    // Spaltenname und Wert zum Dictionary hinzufügen
                    row.Add(colname, value);
                }
                // Das Dictionary zur Datenliste hinzufügen
                Data.Add(row);
            }
            // Den Reader schließen
            reader.Close();
            // Die gesammelten Daten zurückgeben
            return Data;
        }
    }
}
