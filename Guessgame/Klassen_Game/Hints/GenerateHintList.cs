using Guessgame.Klassen_Game.Math_Algorithm;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Guessgame.Klassen_Game.Hints
{
    internal class GenerateHintList
    {
        // Wir haben Listen für die Hinweise und die zugehörigen Strings.
        private readonly List<IHint> HintListe = new();
        private readonly List<string> StringHints = new();

        // Wir haben ein Random-Objekt und ein CheckPrimeNumber-Objekt.
        private readonly Random ran = new();
        private readonly CheckPrimeNumber prime = new();

        // Der Konstruktor füllt die Liste mit verschiedenen Arten von Hinweisen.
        public GenerateHintList(int Number)
        {
            // Wir fügen verschiedene Hinweisarten zur Liste hinzu.
            HintListe.Add(new MultipleChoice());

            // Wenn die Nummer keine Primzahl ist, fügen wir einen weiteren Hinweistyp hinzu.
            if (!prime.GetCheckers(Number))
            {
                HintListe.Add(new GiveDivisibilityNumber());
            }

            // Wir fügen weitere Hinweisarten hinzu.
            HintListe.Add(new SumeDigit());
            HintListe.Add(new LinearFunktion());
            HintListe.Add(new InRange());
            HintListe.Add(new SumeDigit());
        }

        // Diese Methode generiert eine Liste von Hinweisen.
        public List<string> GenerateHints(int Number)
        {
            // Wir wählen zufällig drei Hinweise aus der Liste aus.
            for (int i = 0; i < 3; i++)
            {
                int index = ran.Next(0, HintListe.Count - 1);
                IHint selectedHint = HintListe[index];

                // Wir generieren den Hinweis.
                selectedHint.GetHint(Number);

                // Wir fügen den Hinweis zur Liste der String-Hinweise hinzu.
                StringHints.Add(selectedHint.ToString());

                // Wir entfernen den ausgewählten Hinweis aus der Liste, damit er nicht wieder ausgewählt wird.
                HintListe.RemoveAt(index);
            }

            // Wir geben die Liste der generierten Hinweise zurück.
            return StringHints;
        }

    }
}
