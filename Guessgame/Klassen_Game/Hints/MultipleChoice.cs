using Guessgame.Klassen_GameLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessgame.Klassen_Game.Hints
{
    internal class MultipleChoice: IHint
    {
        // Wir haben drei Variablen für die Auswahlmöglichkeiten und eine Liste, um sie zu speichern.
        private int Choice1, Choice2, Choice3;
        private readonly List<int> Choice = new();
        readonly Random ran = new();
        private string? MessageString;
        private readonly GameLanguages gameLanguages = new();

        // Diese Methode generiert einen Hinweis für die zu erratende Nummer.
        public void GetHint(int NumberToGuess)
        {
            // Wir generieren zwei zufällige Zahlen zwischen 1 und 100.
            Choice1 = ran.Next(1, 100);
            Choice2 = ran.Next(1, 100);

            // Wir stellen sicher, dass die zufälligen Zahlen und die zu erratende Nummer alle unterschiedlich sind.
            while (true)
            {
                if (Choice1 != NumberToGuess && Choice2 != NumberToGuess && Choice1 != Choice2)
                {
                    // Wenn sie unterschiedlich sind, fügen wir sie zur Liste hinzu.
                    Choice.Add(Choice1);
                    Choice.Add(Choice2);
                    Choice.Add(NumberToGuess);
                    break;
                }
                else
                {
                    // Wenn sie nicht unterschiedlich sind, generieren wir neue zufällige Zahlen.
                    Choice1 = ran.Next(1, 500);
                    Choice2 = ran.Next(1, 500);
                }
            }

            // Wir mischen die Liste, um die Auswahlmöglichkeiten zufällig anzuordnen.
            Choice1 = Choice[ran.Next(0, Choice.Count)];
            Choice.Remove(Choice1);
            Choice2 = Choice[ran.Next(0, Choice.Count)];
            Choice.Remove(Choice2);
            Choice3 = Choice[ran.Next(0, Choice.Count)];
            Choice.Remove(Choice3);
        }

        // Diese Methode gibt die Auswahlmöglichkeiten als String zurück.
        public override string ToString()
        {
            MessageString = gameLanguages.SetTHMessageStrings("MultipleChoice","Hints");
            return MessageString + " a: " + Choice1.ToString() + " b: " + Choice2.ToString() + " c: " + Choice3.ToString();
        }

    }
}
