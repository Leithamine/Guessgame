using Guessgame.Klassen_Game.Hints;
using Guessgame.Klassen_GameLanguages;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Guessgame.Klassen_Game.Math_Algorithm
{
    internal class CheckSmithNumber : ICheckers
    {
        private bool check = false;
        private readonly CheckCompositeNumber returncomposite = new();
        private static List<int> PFactors = new();
        private string? MessageString;
        private readonly GameLanguages gameLanguages = new();
        // Diese Funktion checkt, ob die gegebene Nummer eine Smith-Zahl ist.
        public bool GetCheckers(int NumberToCheck)
        {
            // Zuerst prüfen wir, ob die Nummer eine zusammengesetzte Zahl ist.
            if (returncomposite.GetCheckers(NumberToCheck))
            {
                // Wir holen die Primfaktoren der Nummer.
                PFactors = GetPrimeFactors(NumberToCheck);

                // Wir berechnen die Quersumme der Nummer und der Primfaktoren.
                int sumOfDigits = SumOfDigits(NumberToCheck);
                int sumOfFactorsDigits = SumOfFactorsDigits(PFactors);

                // Wenn die beiden Quersummen gleich sind, ist es eine Smith-Zahl.
                if (sumOfDigits == sumOfFactorsDigits)
                {
                    check = true;
                }
            }
            else
            {
                check = false;
            }

            // Wir geben zurück, ob es eine Smith-Zahl ist oder nicht.
            return check;
        }

        // Diese Funktion berechnet die Quersumme einer Zahl.
        private static int SumOfDigits(int num)
        {
            int sum = 0;
            foreach (char digit in num.ToString())
            {
                sum += int.Parse(digit.ToString());
            }
            return sum;
        }

        // Diese Funktion berechnet die Quersumme der Primfaktoren.
        private static int SumOfFactorsDigits(List<int> Factors)
        {
            int sum = 0;
            foreach (var factor in Factors)
            {
                sum += SumOfDigits(factor);
            }
            return sum;
        }

        // Diese Funktion findet die Primfaktoren einer Zahl.
        private static List<int> GetPrimeFactors(int number)
        {
            PFactors = new();
            // Wir teilen die Nummer so oft wie möglich durch 2.
            while (number % 2 == 0)
            {
                PFactors.Add(2);
                number /= 2;
            }

            // Wir teilen die Nummer durch alle ungeraden Zahlen bis zur Quadratwurzel der Nummer.
            for (int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                while (number % i == 0)
                {
                    PFactors.Add(i);
                    number /= i;
                }
            }

            // Wenn die Nummer jetzt größer als 2 ist, fügen wir sie auch hinzu.
            if (number > 2)
            {
                PFactors.Add(number);
            }
            return PFactors;
        }

        // Diese Funktion gibt einen Text zurück, der sagt, ob es eine Smith-Zahl ist oder nicht.
        public override string ToString()
        {
            if (check)
            {
                MessageString = gameLanguages.SetTHMessageStrings("SmithNumber" , "Tipps");
            }
            else
            {
                MessageString = gameLanguages.SetTHMessageStrings("NotSmithNumber" , "Tipps");
            }
            return MessageString;
        }

    }
}
