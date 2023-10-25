using Guessgame.Klassen_Game.Game;
using System;
using System.Data;
using System.Data.SqlClient;


namespace Guessgame.Klassen_User.Klassen_Profil
{
    public class DatabaseManager
    {
        private string? ConnectionString { get; set; } = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GuessGameDB;Integrated Security=True;Connect Timeout=30;ApplicationIntent=ReadWrite";
        // The SqlConnection object to manage the database connection
        public SqlConnection? Con { get; set; }
        // An integer to store the GameStatID
        public int GameStatID { get; set; }
        // Constructor for the DatabaseManager class
        public DatabaseManager()
        {
            // Initialize the SqlConnection object with the connection string
            Con = new SqlConnection(ConnectionString);
            // Open the database connection
            OpenConnection();
        }
        // Methode um den Datenbank Verbindung zu öffnen
        public void OpenConnection()
        {
            try
            {
                if (Con?.State == ConnectionState.Closed)
                {
                    Con?.Open();
                    Con = this?.Con;
                }
            }
            catch (SqlException)
            {
                throw new Exception("Bitte überprüfe deine Verbindungszeichenfolge.");
            }
            catch (Exception ex)
            {
                throw new Exception("Ein unerwarteter Fehler ist aufgetreten: " + ex.Message);
            }
        }
        // Methode, um die Datenbankverbindung zu schließen
        public void CloseConnection()
        {
            // Versuche, die Verbindung zu schließen
            try
            {
                // Überprüfe, ob die Verbindung offen ist
                if (Con?.State == ConnectionState.Open)
                {
                    // Schließe die Verbindung
                    Con?.Close();
                }
            }
            // Fange SQL-Ausnahmen ab
            catch (SqlException)
            {
                throw new Exception("Die SQL-Verbindung konnte nicht geschlossen werden. Überprüfe, ob die Verbindung hergestellt ist.");
            }
            catch (Exception ex)
            {
                // Throw eine neue Ausnahme mit der Fehlermeldung
                throw new Exception("Ein unerwarteter Fehler ist beim Schließen der Verbindung aufgetreten: " + ex.Message);
            }
        }

        // Methode, um einen neuen Benutzer in der Datenbank zu erstellen
        public bool CreateUser(Gameuser user)
        {
            // Öffne die Datenbankverbindung
            OpenConnection();

            // Versuche, den neuen Benutzer in der Datenbank zu erstellen
            try
            {
                // SQL-Befehl zum Einfügen eines neuen Benutzers
                string sql = "INSERT INTO Users (Username, HashedPassword) VALUES (@username, @hashedPassword)";

                // Erstelle ein neues SqlCommand-Objekt
                using SqlCommand cmd = new(sql, Con);

                // Füge die Benutzerdaten als Parameter hinzu
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@hashedPassword", user.HashedPassword);

                // Führe den SQL-Befehl aus
                cmd.ExecuteNonQuery();

                // Schließe die Datenbankverbindung
                CloseConnection();

                // Gebe true zurück, um Erfolg zu signalisieren
                return true;
            }
            // Fange SQL-Ausnahmen ab
            catch (SqlException)
            {
                // Gebe false zurück, wenn ein Fehler auftritt
                return false;
            }
        }

        // Methode, um einen Benutzer aus der Datenbank zu lesen
        public Gameuser? ReadUser(string username)
        {
            // Öffne die Datenbankverbindung
            OpenConnection();

            // Erstelle ein neues Gameuser-Objekt
            Gameuser gameuser = new();

            // SQL-Befehl zum Auslesen eines Benutzers
            string sql = "SELECT * From Users where Username = @username";

            // Erstelle ein neues SqlCommand-Objekt
            using SqlCommand cmd = new(sql, Con);

            // Füge den Benutzernamen als Parameter hinzu
            cmd.Parameters.AddWithValue("@username", username);

            // Führe den SQL-Befehl aus und speichere das Ergebnis in einem SqlDataReader
            SqlDataReader reader = cmd.ExecuteReader();

            // Überprüfe, ob ein Datensatz gefunden wurde
            if (reader.Read())
            {
                // Lese die Benutzerdaten aus dem SqlDataReader
                gameuser.Username = (string)reader["Username"];
                gameuser.HashedPassword = (string)reader["HashedPassword"];
                gameuser.UserID = (int)reader["UserID"];

                // Schließe den SqlDataReader
                reader.Close();

                // Hole den Highscore des Benutzers
                gameuser.Highscore = GetHighscore(gameuser.UserID);

                // Schließe die Datenbankverbindung
                CloseConnection();

                // Gebe das Gameuser-Objekt zurück
                return gameuser;
            }
            else
            {
                // Schließe den SqlDataReader, wenn kein Datensatz gefunden wurde
                reader.Close();

                // Gebe null zurück, wenn der Benutzer nicht gefunden wurde
                return null;
            }
        }
        // Methode, um den höchsten Punktestand eines Benutzers zu erhalten
        public int GetHighscore(int UserID)
        {
            // Öffne die Datenbankverbindung
            OpenConnection();
            // Initialisiere den Highscore mit 0
            int Highscore = 0;
            // SQL-Befehl, um den höchsten Punktestand des Benutzers zu finden
            string Sql = "SELECT Max(G.Highscore) AS Highscore FROM Users AS U Inner Join GameStats AS G ON G.UserID = @UserID";
            // Erstelle ein neues SqlCommand-Objekt
            using SqlCommand cmd = new(Sql, Con);
            {
                // Füge die UserID als Parameter hinzu
                cmd.Parameters.AddWithValue("@UserID", UserID);
                // Führe den SQL-Befehl aus und speichere das Ergebnis in einem SqlDataReader
                SqlDataReader reader = cmd.ExecuteReader();

                // Überprüfe, ob ein Datensatz gefunden wurde und ob der Highscore nicht null ist
                if (reader.Read() && !reader.IsDBNull(reader.GetOrdinal("Highscore")))
                {
                    // Lese den Highscore aus dem SqlDataReader
                    Highscore = (int)reader["Highscore"];
                }
                // Schließe den SqlDataReader
                reader.Close();
                // Schließe die Datenbankverbindung
                CloseConnection();
            }
            // Gebe den Highscore zurück
            return Highscore;
        }


        // Methode, um den Highscore eines Benutzers zu aktualisieren
        public void UpdateHighscoreUser(Gameuser user, int score)
        {
            // Öffne die Datenbankverbindung
            OpenConnection();
            // SQL-Befehl, um den Highscore in der Tabelle "GameStats" zu aktualisieren
            string sql = "UPDATE GameStats SET Highscore = @highscore WHERE UserID = @UserID AND GameStatID = @gameStatID";
            // Erstelle ein neues SqlCommand-Objekt
            using SqlCommand cmd = new(sql, Con);
            {
                // Füge die UserID, den neuen Highscore und die GameStatID als Parameter hinzu
                cmd.Parameters.AddWithValue("@UserID", user.UserID);
                cmd.Parameters.AddWithValue("@highscore", score);
                cmd.Parameters.AddWithValue("@gameStatID", GameStatID);
                // Führe den SQL-Befehl aus
                cmd.ExecuteNonQuery();
                // Schließe die Datenbankverbindung
                CloseConnection();
            }
        }


        // Methode, um einen neuen Spieldatensatz in der Tabelle "GameStats" hinzuzufügen
        public int AddNewGameStat(int userId)
        {
            // Öffne die Datenbankverbindung
            OpenConnection();
            // SQL-Befehl, um einen neuen Eintrag in der Tabelle "GameStats" zu erstellen und die GameStatID zurückzugeben
            string query = "INSERT INTO GameStats (UserID, GameDate, Highscore) OUTPUT INSERTED.GameStatID VALUES (@userId, @gameDate, @highscore)";
            // Erstelle ein neues SqlCommand-Objekt
            using SqlCommand command = new(query, Con);
            {
                // Füge die UserID, das aktuelle Datum und den Highscore als Parameter hinzu
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@gameDate", DateTime.Now.Date);
                command.Parameters.AddWithValue("@highscore", 0);
                // Führe den SQL-Befehl aus und speichere die zurückgegebene GameStatID
                GameStatID = (int)command.ExecuteScalar();
                // Schließe die Datenbankverbindung
                CloseConnection();
            }
            // Gebe die GameStatID zurück
            return GameStatID;
        }


        // Methode, um mehrere Spielrunden in der Datenbank zu speichern
        internal void InsertRounds(List<GameRecords> rounds)
        {
            // Öffne die Datenbankverbindung
            OpenConnection();
            // Gehe durch jede Runde in der Liste der Spielrunden
            foreach (GameRecords round in rounds)
            {
                // SQL-Befehl, um eine neue Runde in der Tabelle "GameRounds" zu erstellen
                string sql = "INSERT INTO GameRounds (GameStatID, UsedHints, Tries) VALUES (@gameStatID, @usedHints, @tries)";
                // Erstelle ein neues SqlCommand-Objekt
                using SqlCommand cmd = new(sql, Con);
                {
                    // Füge die GameStatID, die Anzahl der verwendeten Hinweise und die Anzahl der Versuche als Parameter hinzu
                    cmd.Parameters.AddWithValue("@gameStatID", GameStatID);
                    cmd.Parameters.AddWithValue("@usedHints", round.UsedHints);
                    cmd.Parameters.AddWithValue("@tries", round.Tries);
                    // Führe den SQL-Befehl aus
                    cmd.ExecuteNonQuery();
                }
            }
            // Schließe die Datenbankverbindung
            CloseConnection();
        }
        // Methode, um das Passwort eines Benutzers zu aktualisieren
        public bool UpdatePassword(Gameuser user)
        {
            try
            {
                // Öffne die Datenbankverbindung
                OpenConnection();
                // SQL-Befehl zum Aktualisieren des Passworts für einen bestimmten Benutzer
                string sql = "UPDATE Users SET HashedPassword = @hashedPassword WHERE UserID = @userID";
                // Erstelle ein neues SqlCommand-Objekt
                using SqlCommand cmd = new(sql, Con);
                {
                    // Füge die UserID und das neue gehashte Passwort als Parameter hinzu
                    cmd.Parameters.AddWithValue("@userID", user.UserID);
                    cmd.Parameters.AddWithValue("@hashedPassword", user.HashedPassword);
                    // Führe den SQL-Befehl aus
                    cmd.ExecuteNonQuery();
                    // Schließe die Datenbankverbindung
                    CloseConnection();
                    // Rückgabe true, wenn das Update erfolgreich war
                    return true;
                }
            }
            catch (SqlException)
            {
                // Rückgabe false, wenn ein SQL-Fehler auftritt
                return false;
            }
        }
        // Methode, um einen Benutzer aus der Datenbank zu löschen
        public void DeleteUser(string? username)
        {
            OpenConnection();
            // SQL-Befehl zum Löschen eines Benutzers mit einem bestimmten Benutzernamen
            string sql = "DELETE FROM Users WHERE Username = @username";
            // Erstelle ein neues SqlCommand-Objekt
            using SqlCommand cmd = new(sql, Con);
            {
                // Füge den Benutzernamen als Parameter hinzu
                cmd.Parameters.AddWithValue("@username", username);
                // Führe den SQL-Befehl aus
                cmd.ExecuteNonQuery();
                // Schließe die Datenbankverbindung
                CloseConnection();
            }
        }

        // Methode, um alle Jahre zu erhalten, in denen der Benutzer gespielt hat
        public List<int> YearsPlayed(int userId)
        {
            OpenConnection();
            // Erstelle eine neue Liste, um die Jahre zu speichern
            List<int> years = new();
            // Erstelle ein neues SqlCommand-Objekt für die gespeicherte Prozedur "GetAllYearsPlayed"
            using SqlCommand cmd = new("GetAllYearsPlayed", Con);
            {
                // Setze den Befehlstyp auf gespeicherte Prozedur
                cmd.CommandType = CommandType.StoredProcedure;
                // Füge die Benutzer-ID als Parameter hinzu
                cmd.Parameters.AddWithValue("@UserID", userId);
                // Führe den Befehl aus und erhalte einen SqlDataReader
                SqlDataReader reader = cmd.ExecuteReader();
                // Lese alle Zeilen aus dem SqlDataReader
                while (reader.Read())
                {
                    // Füge das Jahr zur Liste hinzu
                    years.Add((int)reader["Year"]);
                }
                // Schließe den SqlDataReader
                reader.Close();
                CloseConnection();
            }
            // Gebe die Liste der Jahre zurück
            return years;
            
        }
        // Methode, um alle Monate zu erhalten, in denen der Benutzer in einem bestimmten Jahr gespielt hat
        public List<string> AllMonthsPlayed(int userId, int year)
        {
            // Überprüfe, ob die Verbindung geschlossen ist. Wenn ja, öffne sie.
            if (Con?.State == ConnectionState.Closed)
            {
                OpenConnection();
            }
            // Erstelle eine neue Liste, um die Monate zu speichern
            List<string> months = new();
            // Erstelle ein neues SqlCommand-Objekt für die gespeicherte Prozedur "GetAllMonthsPlayed"
            using SqlCommand cmd = new("GetAllMonthsPlayed", Con);
            {
                // Setze den Befehlstyp auf gespeicherte Prozedur
                cmd.CommandType = CommandType.StoredProcedure;
                // Füge die Benutzer-ID und das Jahr als Parameter hinzu
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@Year", year);
                // Führe den Befehl aus und erhalte einen SqlDataReader
                SqlDataReader reader = cmd.ExecuteReader();
                // Lese alle Zeilen aus dem SqlDataReader
                while (reader.Read())
                {
                    // Füge den Monat zur Liste hinzu
                    months.Add((string)reader["Month"]);
                }
                // Schließe den SqlDataReader
                reader.Close();
                // Schließe die Verbindung
                CloseConnection();
            }
            // Gebe die Liste der Monate zurück
            return months;
        }


        // Methode, um den Spielstatus eines Benutzers zu erhalten
        public int GetGameStat(int userId)
        {
            // Initialisiere die Variable für die Anzahl der Spiele
            int games = 0;

            // Überprüfe, ob die Verbindung geschlossen ist. Wenn ja, öffne sie.
            if (Con?.State == ConnectionState.Closed)
            {
                OpenConnection();
            }

            // Erstelle ein neues SqlCommand-Objekt für die gespeicherte Prozedur "GetGameStatus"
            using SqlCommand cmd = new("GetGameStatus", Con);
            {
                // Setze den Befehlstyp auf gespeicherte Prozedur
                cmd.CommandType = CommandType.StoredProcedure;
                // Füge die Benutzer-ID als Parameter hinzu
                cmd.Parameters.AddWithValue("UserID", userId);
                // Führe den Befehl aus und erhalte einen SqlDataReader
                SqlDataReader reader = cmd.ExecuteReader();
                // Lese die erste Zeile aus dem SqlDataReader
                if (reader.Read())
                {
                    // Speichere die Anzahl der gesamten Spiele in der Variable "games"
                    games = (int)reader["GesamteSpiele"];
                }
                // Schließe den SqlDataReader
                reader.Close();
                // Schließe die Verbindung
                CloseConnection();
            }
            // Gebe die Anzahl der Spiele zurück
            return games;
        }
    }
}

