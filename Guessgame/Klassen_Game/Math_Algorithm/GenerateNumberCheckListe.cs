using Guessgame.Klassen_GameLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Guessgame.Klassen_Game.Math_Algorithm
{
    internal class GenerateNumberCheckListe
    {
        // Wir haben hier zwei Listen. Eine für die Checker-Objekte und eine für die Ergebnisse.
        private readonly List<ICheckers> CheckListe = new();
        private readonly List<string> Checkers = new();
        // Im Konstruktor der Klasse füllen wir die Liste mit verschiedenen Checker-Objekten.
        public GenerateNumberCheckListe()
        {
            // Hier fügen wir alle Checker-Objekte zur Liste hinzu.
            // Jedes Objekt ist verantwortlich für die Überprüfung einer bestimmten Eigenschaft der Zahlen.
            CheckListe.Add(new CheckPrimeNumber());
            CheckListe.Add(new CheckPerfectNumber());
            CheckListe.Add(new CheckNarcissisticNumber());
            CheckListe.Add(new CheckFibonacciNumber());
            CheckListe.Add(new CheckCompositeNumber());
            CheckListe.Add(new CheckTriangleNumber());
            CheckListe.Add(new CheckSquareNumber());
            CheckListe.Add(new CheckFactorialNumber());
            CheckListe.Add(new CheckAbundantNumber());
            CheckListe.Add(new CheckDeficientNumber());
            CheckListe.Add(new CheckHarshadNumber());
            CheckListe.Add(new CheckHappyNumber());
            CheckListe.Add(new CheckAutomorphicNumber());
            CheckListe.Add(new CheckBellNumber());
            CheckListe.Add(new CheckPalindromeNumber());
            CheckListe.Add(new CheckSexyPrime());
            CheckListe.Add(new CheckSmithNumber());
        }

        // Diese Methode nimmt eine Nummer und prüft sie mit allen Checkern in der Liste.
        public List<string> ChecksForNumber(int Number)
        {
            // Wir gehen durch alle Checker in der Liste.
            foreach (var checker in CheckListe)
            {
                // Wir verwenden die GetCheckers-Methode jedes Checker-Objekts, um die Nummer zu prüfen.
                if (checker.GetCheckers(Number) == true)
                {
                    // Spezialfall für den CompositeNumber-Checker.
                    if (checker is CheckCompositeNumber)
                    {
                        if (checker.GetCheckers(Number) == false)
                        {
                            Checkers.Add(checker.ToString());
                        }
                    }
                    // Wir fügen das Ergebnis der Überprüfung zur Ergebnisliste hinzu.
                    Checkers.Add(checker.ToString());
                }
            }

            // Wir geben die Liste der Ergebnisse zurück.
            return Checkers;
        }

    }
}
