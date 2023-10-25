using Guessgame.Klassen_Game;
using Guessgame.Klassen_User.Klassen_Profil;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Guessgame.Klassen_User.Klassen_Profil
{
    internal class DrawChart
    {
        private readonly static DatabaseManager dbManager = new();
        private readonly SqlConnection? Con = dbManager.Con;

        public DrawChart(FormsPlot form, int ChartID, int userId, int year, int Month)
        {
            switch (ChartID)
            {
                case 1:
                    Game_Usage_Dev_Week(form, userId, year, Month);
                    break;

                case 2:
                    Score_Dev_Week(form, userId, year, Month);
                    break;

                case 3:
                    Game_Usage_Dev_Month(form, userId, year, Month);
                    break;

                case 4:
                    Score_Dev_Month(form, userId, year, Month);
                    break;

                case 5:
                    Hints_Tries_Dev_Week(form, userId, year, Month);
                    break;

                case 6:
                    Hints_Tries_Dev_Month(form, userId, year, Month);
                    break;

                case 7:
                    Weekly_Round_Statistics(form, userId, year, Month);
                    break;
                case 8:
                    Monthly_Round_Stats(form, userId, year, Month);
                    break;
            }
        }
        private void Hints_Tries_Dev_Week(FormsPlot form, int userId, int year, int Month)
        {
            // Methode für die Darstellung der Hinweise und Versuche pro Woche

            // Datenanbieter-Objekt erstellen
            IData dataProvider = new Hints_Tries_Dev_Week();

            // Daten aus der Datenbank abrufen
            List<Dictionary<string, object>> gameDataList = dataProvider.GetData(Con, userId, Month, year);

            // Listen für die verschiedenen Datenpunkte erstellen
            List<string> dayofweek = new();
            List<double> hints = new();
            List<double> tries = new();
            List<DateTime> date = new();

            // Alle Zeilen der abgerufenen Daten durchgehen
            foreach (var row in gameDataList)
            {
                // Überprüfen, ob die notwendigen Schlüssel vorhanden sind
                if (row.ContainsKey("TotalTries") && row.ContainsKey("TotalHints") && row.ContainsKey("WeekStartDate"))
                {
                    // Daten zu den jeweiligen Listen hinzufügen
                    dayofweek.Add(row.ContainsKey("DayOfWeek") ? row["DayOfWeek"]?.ToString() ?? "Keine Daten" : "Schlüssel fehlt");
                    hints.Add(Convert.ToDouble(row["TotalHints"]));
                    tries.Add(Convert.ToDouble(row["TotalTries"]));
                    date.Add(Convert.ToDateTime(row["WeekStartDate"]));
                }
            }

            // Listen in Arrays umwandeln
            double[] hintsArray = hints.ToArray();
            double[] triesArray = tries.ToArray();
            DateTime[] DateArray = date.ToArray();
            double[] DateArrayOADate = DateArray.Select(d => d.ToOADate()).ToArray();
            string[] DateAndDayLabels = DateArray.Select(date => $"{date:ddd}.\n{date:dd}.\n{date:MM}").ToArray();

            // Diagramm initialisieren
            form.Plot.Clear();
            _ = form.Plot.AddScatter(DateArrayOADate, hintsArray).Color = System.Drawing.Color.Blue;
            _ = form.Plot.AddScatter(DateArrayOADate, triesArray).Color = System.Drawing.Color.Red;
            _ = form.Plot.AddScatter(DateArrayOADate, triesArray).Label = "Benutzte Versuche";
            _ = form.Plot.AddScatter(DateArrayOADate, hintsArray).Label = "Benutzte Hinweise";
            form.Plot.XLabel("Wochen");
            form.Plot.YLabel("Anzahl");
            form.Plot.XTicks(DateArrayOADate, DateAndDayLabels.Select(w => w.ToString()).ToArray());
            form.Plot.Legend(location: Alignment.UpperLeft);

            // Diagramm rendern
            form.Render();

            // Anwendung aktualisieren
            Application.DoEvents();
        }


        public void Weekly_Round_Statistics(FormsPlot form, int userId, int year, int Month)
        {
            /// --------------------------------------
            /// Weekly_Round_Statistics(Done Done Done Done)
            /// --------------------------------------

            IData dataProvider = new Weekly_Round_Statistics();
            List<Dictionary<string, object>> gameDataList = dataProvider.GetData(Con, userId, Month, year);

            List<double> OnlyHints = new();
            List<double> MoreTries = new();
            List<double> TriesAndHints = new();
            List<double> NoHintsAndTries = new();
            List<double> Weeks = new();
            List<string> StartDayOfWeek = new();
            List<DateTime> WeekStartDate = new();
            foreach (var row in gameDataList)
            {
                if (row.ContainsKey("Week") && row.ContainsKey("PercentageOnlyHints") && row.ContainsKey("PercentageMoreThanOneTry") && row.ContainsKey("PercentageBothHintsAndTries") && row.ContainsKey("PercentageNoHintsOrTries"))
                {
                    Weeks.Add(Convert.ToDouble(row["Week"]));
                    OnlyHints.Add(Convert.ToDouble(row["PercentageOnlyHints"]));
                    MoreTries.Add(Convert.ToDouble(row["PercentageMoreThanOneTry"]));
                    TriesAndHints.Add(Convert.ToDouble(row["PercentageBothHintsAndTries"]));
                    NoHintsAndTries.Add(Convert.ToDouble(row["PercentageNoHintsOrTries"]));
                    StartDayOfWeek.Add(row.ContainsKey("WeekStartDay") ? row["WeekStartDay"]?.ToString() ?? "No Data" : "Key Missing");
                    WeekStartDate.Add(Convert.ToDateTime(row["WeekStartDate"]));
                }
            }
            double[] weeksArray = Weeks.ToArray();
            double[] OnlyhintsArray = OnlyHints.ToArray();
            double[] OnlytriesArray = MoreTries.ToArray();
            double[] TriesAndHintsArray = TriesAndHints.ToArray();
            double[] NoHintsAndTriesArray = NoHintsAndTries.ToArray();
            form.Plot.Clear();
            string[] groupLabels = WeekStartDate.Zip(StartDayOfWeek, (date, day) => $"{day[..2]}.\n{date:dd}.\n{date:MM}").ToArray();
            string[] seriesLabels = new string[] { "Only Hints", "Only Tries", "Tries & Hints", "No Hints & Tries" };
            double[][] ys = new double[][] { OnlyhintsArray, OnlytriesArray, TriesAndHintsArray, NoHintsAndTriesArray };
            var barPlots = form.Plot.AddBarGroups(groupLabels, seriesLabels, ys, null);
            form.Plot.XLabel("\n\n\n\n Weeks");
            form.Plot.YLabel("Percentage");
            barPlots[0].FillColor = Color.Red;
            barPlots[0].Label = "Only Hints";
            barPlots[1].FillColor = System.Drawing.Color.Blue;
            barPlots[1].Label = "Only Tries";
            barPlots[2].FillColor = System.Drawing.Color.Green;
            barPlots[2].Label = "Tries & Hints";
            barPlots[3].FillColor = System.Drawing.Color.Purple;
            barPlots[3].Label = "No Hints & No Tries";
            form.Plot.Legend(location: Alignment.UpperLeft);
            // Render the plot
            form.Render();
            // Update UI
            Application.DoEvents();
        }
        private void Hints_Tries_Dev_Month(FormsPlot form, int userId, int year, int Month)
        {
            //---------------------------
            //Hints_Tries_Dev_Month  Done Done Done Done
            //---------------------------


            IData dataProvider = new Hints_Tries_Dev_Month();
            List<Dictionary<string, object>> gameDataList = dataProvider.GetData(Con, userId, Month, year);

            List<string> LMonth = new();
            List<double> hints = new();
            List<double> tries = new();

            foreach (var row in gameDataList)
            {
                if (row.ContainsKey("GameMonth") && row.ContainsKey("TotalTries") && row.ContainsKey("TotalHints"))
                {
                    LMonth.Add(row.ContainsKey("GameMonth") ? row["GameMonth"]?.ToString() ?? "No Data" : "Key Missing");
                    hints.Add(Convert.ToDouble(row["TotalHints"]));
                    tries.Add(Convert.ToDouble(row["TotalTries"]));
                }
            }

            string[] MonthArray = LMonth.ToArray();
            double[] hintsArray = hints.ToArray();
            double[] triesArray = tries.ToArray();

            form.Plot.Clear();
            double[] MonthAsDoubleArray = LMonth.Select(m => Convert.ToDouble(DateTime.ParseExact(m, "MMMM", CultureInfo.InvariantCulture).Month)).ToArray();

            _ = form.Plot.AddScatter(MonthAsDoubleArray, hintsArray).Color = System.Drawing.Color.Blue;
            _ = form.Plot.AddScatter(MonthAsDoubleArray, triesArray).Color = System.Drawing.Color.Red;
            _ = form.Plot.AddScatter(MonthAsDoubleArray, triesArray).Label = "Used Tries";
            _ = form.Plot.AddScatter(MonthAsDoubleArray, hintsArray).Label = "Used Hints";
            form.Plot.XLabel("Months");
            form.Plot.YLabel("Counts");
            string[] MonthLabels = MonthAsDoubleArray.Select(m => DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName((int)m)).ToArray();
            form.Plot.XTicks(MonthAsDoubleArray, MonthLabels.Select(m => m.ToString()).ToArray());
            form.Plot.Legend(location: Alignment.UpperLeft);
            form.Render();
            Application.DoEvents();
        }

        private void Score_Dev_Month(FormsPlot form, int userId, int year, int Month)
        {
            //---------------------------
            //Score_Dev_Month (Done Done Done)
            //---------------------------

            IData dataProvider = new Score_Dev_Month();
            List<Dictionary<string, object>> gameDataList = dataProvider.GetData(Con, userId, Month, year);

            List<double> score = new();
            List<string> GameMonth = new();
            List<DateTime> GameDate = new();

            foreach (var row in gameDataList)
            {
                if (row.ContainsKey("HighScore") && row.ContainsKey("GameMonth"))
                {
                    score.Add(Convert.ToDouble(row["HighScore"]));
                    GameMonth.Add(row.ContainsKey("GameMonth") ? row["GameMonth"]?.ToString() ?? "No Data" : "Key Missing");
                }
            }

            double[] MonthAsDoubleArray = GameMonth.Select(m => Convert.ToDouble(DateTime.ParseExact(m, "MMMM", CultureInfo.InvariantCulture).Month)).ToArray();

            double[] ScoreArray = score.ToArray();
            string[] MonthAndDateLabels = MonthAsDoubleArray.Zip(GameMonth, (date, month) => $"{month}").ToArray();

            form.Plot.Clear();

            var scatterPlot = form.Plot.AddScatter(MonthAsDoubleArray, ScoreArray);
            scatterPlot.Color = System.Drawing.Color.Blue;
            scatterPlot.Label = "Score";

            form.Plot.XLabel("Months");
            form.Plot.YLabel("Score");
            form.Plot.XTicks(MonthAsDoubleArray, MonthAndDateLabels);
            form.Plot.Legend(location: Alignment.UpperLeft);
            form.Render();
            Application.DoEvents();
        }

        private void Score_Dev_Week(FormsPlot form, int userId, int year, int Month)
        {
            //---------------------------
            //Score_Dev_Week (Done Done Done)
            //---------------------------


            IData dataProvider = new Score_Dev_Week();
            List<Dictionary<string, object>> gameDataList = dataProvider.GetData(Con, userId, Month, year);

            List<double> score = new();

            List<string> startDayOfWeek = new();
            List<DateTime> weekStartDate = new();

            foreach (var row in gameDataList)
            {
                if (row.ContainsKey("HighScore") && row.ContainsKey("StartDayOfWeek"))
                {
                    score.Add(Convert.ToDouble(row["HighScore"]));
                    startDayOfWeek.Add(row.ContainsKey("StartDayOfWeek") ? row["StartDayOfWeek"]?.ToString() ?? "No Data" : "Key Missing");
                    weekStartDate.Add(Convert.ToDateTime(row["WeekStartDate"]));
                }
            }
            double[] ScoreArray = score.ToArray();
            DateTime[] WeekStartDateArray = weekStartDate.ToArray();
            double[] DateArrayOADate = WeekStartDateArray.Select(d => d.ToOADate()).ToArray();
            string[] WeekAndDayLabels = WeekStartDateArray.Zip(startDayOfWeek, (date, day) => $"{day[..2]}.\n{date:dd}.\n{date:MM}").ToArray();

            form.Plot.Clear();

            var scatterPlot = form.Plot.AddScatter(DateArrayOADate, ScoreArray);
            scatterPlot.Color = System.Drawing.Color.Blue;
            scatterPlot.Label = "Score";
            form.Plot.XLabel("Weeks");
            form.Plot.YLabel("Score");
            form.Plot.XTicks(DateArrayOADate, WeekAndDayLabels);
            form.Plot.Legend(location: Alignment.UpperLeft);
            form.Render();
            Application.DoEvents();
        }
        private void Game_Usage_Dev_Week(FormsPlot form, int userId, int year, int Month)
        {
            //---------------------------
            //Game_Usage_Dev_Week (DONE DONE DONE)
            //---------------------------

            IData dataProvider = new Game_Usage_Dev_Week();
            List<Dictionary<string, object>> gameDataList = dataProvider.GetData(Con, userId, Month, year);
            List<double> playedrounds = new();
            List<string> dayofweek = new();
            List<DateTime> date = new();
            foreach (var row in gameDataList)
            {
                if (row.ContainsKey("PlayedRounds") && row.ContainsKey("DayOfWeek") && row.ContainsKey("Date"))
                {
                    playedrounds.Add(Convert.ToDouble(row["PlayedRounds"]));
                    dayofweek.Add(row.ContainsKey("DayOfWeek") ? row["DayOfWeek"]?.ToString() ?? "No Data" : "Key Missing");
                    date.Add(Convert.ToDateTime(row["Date"]));
                }
            }
            string[] DayOfWeekArray = dayofweek.ToArray();
            double[] GamePlayedArray = playedrounds.ToArray();
            DateTime[] DateArray = date.ToArray();
            form.Plot.Clear();

            double[] DateArrayOADate = DateArray.Select(d => d.ToOADate()).ToArray();
            string[] DateAndDayLabels = DateArray.Zip(dayofweek, (date, day) => $"{day[..2]}.\n{date:dd}.\n{date:MM}").ToArray();
            var scatterPlot = form.Plot.AddScatter(DateArrayOADate, GamePlayedArray);
            scatterPlot.Color = System.Drawing.Color.Blue;
            scatterPlot.Label = "Game Played";
            form.Plot.XTicks(DateArrayOADate, DateAndDayLabels); scatterPlot.Color = System.Drawing.Color.Blue;
            scatterPlot.Label = "Game Played";
            form.Plot.XLabel("\n\n\nWeeks");
            form.Plot.YLabel("GamePlayed");
            form.Plot.Legend(location: Alignment.UpperLeft);
            form.Render();
            Application.DoEvents();
        }

        private void Game_Usage_Dev_Month(FormsPlot form, int userId, int year, int Month)
        {
            ////---------------------------------------------------------------------------------------------------------------------------
            ////---------------------------
            ////Game_Usage_Dev_Month    (DONE DONE DONE)
            ////----------------------------

            IData dataProvider = new Game_Usage_Dev_Month();
            List<Dictionary<string, object>> gameDataList = dataProvider.GetData(Con, userId, Month, year);
            List<double> GamePlayed = new();
            List<string> LMonth = new();


            foreach (var row in gameDataList)
            {
                if (row.ContainsKey("GamesPlayed") && row.ContainsKey("GameMonth"))
                {
                    LMonth.Add(row.ContainsKey("GameMonth") ? row["GameMonth"]?.ToString() ?? "No Data" : "Key Missing");
                    GamePlayed.Add(Convert.ToDouble(row["GamesPlayed"]));
                }
            }
            double[] GamePlayedArray = GamePlayed.ToArray();
            double[] MonthAsDoubleArray = LMonth.Select(m => Convert.ToDouble(DateTime.ParseExact(m, "MMMM", CultureInfo.InvariantCulture).Month)).ToArray();
            form.Plot.Clear(); 
            var scatterPlot = form.Plot.AddScatter(MonthAsDoubleArray, GamePlayedArray);
            scatterPlot.Color = System.Drawing.Color.Blue;
            scatterPlot.Label = "Game Played";
            form.Plot.XLabel("Month");
            form.Plot.YLabel("GamePlayed");
            string[] MonthLabels = MonthAsDoubleArray.Select(m => DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName((int)m)).ToArray();
            form.Plot.XTicks(MonthAsDoubleArray, MonthLabels);
            form.Plot.Legend(location: Alignment.UpperLeft);
            form.Render();
            Application.DoEvents();
        }
        private void Monthly_Round_Stats(FormsPlot form, int userId, int year, int Month)
        {
            ////------------------------------------------------------------------------------------------------------
            ///// --------------------------------------
            ///// Monthly_Round_Statistics
            ///// --------------------------------------
            IData dataProvider = new Monthly_Round_Statistics();
            List<Dictionary<string, object>> gameDataList = dataProvider.GetData(Con, userId, Month, year);
            List<double> OnlyHints = new();
            List<double> MoreTries = new();
            List<double> TriesAndHints = new();
            List<double> NoHintsAndTries = new();
            List<double> Months = new();
            List<string> Monthname = new();
            foreach (var row in gameDataList)
            {
                if (row.ContainsKey("Month") && row.ContainsKey("MonthName") && row.ContainsKey("PercentageOnlyHints") && row.ContainsKey("PercentageMoreThanOneTry") && row.ContainsKey("PercentageBothHintsAndTries") && row.ContainsKey("PercentageNoHintsOrTries"))
                {
                    Months.Add(Convert.ToDouble(row["Month"]));
                    OnlyHints.Add(Convert.ToDouble(row["PercentageOnlyHints"]));
                    MoreTries.Add(Convert.ToDouble(row["PercentageMoreThanOneTry"]));
                    TriesAndHints.Add(Convert.ToDouble(row["PercentageBothHintsAndTries"]));
                    NoHintsAndTries.Add(Convert.ToDouble(row["PercentageNoHintsOrTries"]));
                    Monthname.Add((string)row["MonthName"]);
                }
            }
            string[] Monthsnamearray = Monthname.ToArray();
            double[] OnlyhintsArray = OnlyHints.ToArray();
            double[] OnlytriesArray = MoreTries.ToArray();
            double[] TriesAndHintsArray = TriesAndHints.ToArray();
            double[] NoHintsAndTriesArray = NoHintsAndTries.ToArray();
            form.Plot.Clear();
            string[] seriesLabels = new string[] { "Only Hints", "Only Tries", "Tries & Hints", "No Hints & Tries" };
            double[][] ys = new double[][] { OnlyhintsArray, OnlytriesArray, TriesAndHintsArray, NoHintsAndTriesArray };
            var barPlots = form.Plot.AddBarGroups(Monthsnamearray, seriesLabels, ys, null);
            form.Plot.XLabel("Months");
            form.Plot.YLabel("Rounds Percentage");
            barPlots[0].FillColor = System.Drawing.Color.Red;
            barPlots[0].Label = "Only Hints";
            barPlots[1].FillColor = System.Drawing.Color.Blue;
            barPlots[1].Label = "Only Tries";
            barPlots[2].FillColor = System.Drawing.Color.Green;
            barPlots[2].Label = "Tries & Hints";
            barPlots[3].FillColor = System.Drawing.Color.Purple;
            barPlots[3].Label = "No Hints & No Tries";
            form.Plot.Legend(location: Alignment.UpperLeft);
            form.Render();
            Application.DoEvents();
        }
    }
}
