using System;

namespace SimprintsChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            RenderUI();
        }

        /// <summary>
        /// Static function that runs UI for the three challenges.
        /// </summary>
        static void RenderUI()
        {
            while (true)
            {
                Console.WriteLine("Challenges");
                Console.WriteLine("1- Characters Occurrences Histogram. \n2- Matrix Algorithm. \n3- ASCII Sorter.");
                string input = Console.ReadLine();

                short.TryParse(input, out short choise);

                switch (choise)
                {
                    case 1:
                        _ = new CharactersOccurrencesHistogram();
                        break;
                    case 2:
                        _ = new MatrixAlgorithm();
                        break;
                    case 3:
                        _ = new ASCIISorter();
                        break;
                    default:
                        Console.WriteLine("Your choise is not supported, Please try again.");
                        break;
                }

                Console.WriteLine("\n-----------------------------------------------\n");
            }
        }
    }
}
