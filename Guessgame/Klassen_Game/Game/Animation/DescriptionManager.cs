using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using ScottPlot;
using ScottPlot.Statistics;
using System.Windows.Forms;

namespace Guessgame.Klassen_Game.Game.Animation
{
    // Diese Klasse verwaltet die Beschreibungen für das Spiel.
    internal class DescriptionManager
    {
        // Der Pfad zur Textdatei, die die Beschreibungen enthält.
        private string? FilePath;

        // Eine Liste der Indizes für die verschiedenen Beschreibungen.
        public List<int> Indices { get; private set; }
        private GameLanguage lang = new();
        // Variable für die aktuelle Beschreibung.
        private string? description;

        // Konstruktor, der die Liste der Indizes initialisiert.
        public DescriptionManager(GameLanguage langCul)
        {
            lang = langCul;
            Indices = Enumerable.Range(0, 16).ToList();  // Liste mit Zahlen von 0 bis 17.
        }

        // Methode, die eine Beschreibung anhand eines Index zurückgibt.
        public string GetDescription(int index)
        {
            FilePath = GetPathDescription(lang);
            // Überprüfung, ob der Index gültig ist.
            if (index < 0 || index > 16)
            {
                throw new ArgumentOutOfRangeException("Index sollte zwischen 0 und 16 liegen.");
            }

            // Versuch, die Beschreibung aus der Datei zu lesen.
            try
            {
                using StreamReader sr = new(FilePath);
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.StartsWith($"{index}:"))
                    {
                        List<string> descriptionLines = new();

                        // Lese die Zeilen bis zur nächsten gestrichelten Linie oder zum Ende der Datei.
                        while ((line = sr.ReadLine()) != null && !line.StartsWith("---"))
                        {
                            descriptionLines.Add(line);
                        }

                        return string.Join(Environment.NewLine, descriptionLines);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ein Fehler ist aufgetreten: {ex.Message}");
            }

            return "Beschreibung nicht gefunden.";
        }

        // Methode, die die Beschreibung in einer ListBox anzeigt.
        public void GenerateDescription(ListBox listBox, int index)
        {
            listBox.Items.Clear();
            description = GetDescription(index);
            var descriptionLines = description.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (var descLine in descriptionLines)
            {
                listBox.Items.Add(descLine);
            }
        }

        // Methode, die die Anzahl der verfügbaren Beschreibungen zurückgibt.
        public int DLength()
        {
            return Indices.Count;
        }
        public string GetPathDescription(GameLanguage lang)
        {
            if(lang.SelectedCulture == "de-DE")
            {
                return Path.Combine(Directory.GetCurrentDirectory(), "Klassen_Game", "Game", "Animation", "Beschreibungen.txt");
            }
            else /*if(lang.SelectedCulture == "en-US")*/
            {
                return Path.Combine(Directory.GetCurrentDirectory(), "Klassen_Game", "Game", "Animation", "Description.txt");  
            }
        }
    }
}
