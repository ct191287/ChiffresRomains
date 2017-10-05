using System;

namespace DecimalToRoman
{
    public class Program
    {
        /// <summary>
        /// Nombre maximum qu'on peut convertir en chiffre Romain
        /// </summary>
        private const int MaxNumber = 4999;

        public static void Main(string[] args)
        {
            Console.WriteLine("Convertion en chiffres Romains ! (par Cédric Testevuide)");
            var entryValue = string.Empty;

            while (entryValue != null && !(entryValue.Equals("Q") || entryValue.Equals("q")))
            {
                Console.WriteLine("Entrez une valeur en décimal (comprise entre 1 et {0}) ou \"Q\" pour quitter l'application :", MaxNumber);
                entryValue = Console.ReadLine();
                int inputNumber;

                if (!int.TryParse(entryValue, out inputNumber) || inputNumber > MaxNumber || inputNumber <= 0)
                {
                    Console.WriteLine("Saisie incorrecte, veuillez recommencer...");
                }
                else
                {
                    Console.WriteLine("Résultat : {0}", ToRoman(inputNumber));
                }
            }
        }

        /// <summary>
        /// Converti un nombre décimal en un nombre Romain
        /// </summary>
        /// <param name="inputNumber">Nombre décimal</param>
        /// <returns>Nombre Romain</returns>
        private static string ToRoman(int inputNumber)
        {
            var convertedNumber = string.Empty;
            string[] lstRoman = {"M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"};
            int[] lstDecimal = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

            for (var i = 0; i < lstDecimal.Length; i++)
            {
                while (lstDecimal[i] <= inputNumber)
                {
                    convertedNumber += lstRoman[i];
                    inputNumber -= lstDecimal[i];
                }
            }

            return convertedNumber;
        }
    }
}
