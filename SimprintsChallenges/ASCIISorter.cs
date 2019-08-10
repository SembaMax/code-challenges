using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace SimprintsChallenges
{
    public class ASCIISorter : BaseChallenge
    {
        List<string> PREDEFINED_VALUES = new List<string> {
            "Relentless Commitment to Impact",
            "Robust as Fudge",
            "Be Surprisingly Bold",
            "Get Back Up",
            "Make it Happen",
            "Don't be a Jerk",
            "Confront the Grey",
            "Laugh Together, Grow Together"
        };

        readonly Dictionary<string, int> valuesIndecesWithASCII = new Dictionary<string, int>();
        
        public ASCIISorter()
        {
            base.ReadInitialInput();
        }

        public override void DisplayOutput(object arg)
        {
            List<int> sortedList = (List<int>) arg;
            foreach (int ascii in sortedList)
            {
                var valueString = valuesIndecesWithASCII.SingleOrDefault(pair => pair.Value == ascii).Key;
                Console.WriteLine("\n");
                Console.WriteLine("{0} : {1}", ascii , valueString);
            }
        }

        public override void DoWork(object arg)
        {
            Dictionary<string, int> values = (Dictionary<string, int>) arg;
            CalculateASCIIForElements(values);
            List<int> sortedValuesAscii = SortValues(values.Values.ToList());
            DisplayOutput(sortedValuesAscii);
        }

        /// <summary>
        /// Using Collection.Sort() :
        /// * If the partition size is fewer than 16 elements, it uses an insertion sort algorithm.
        /// * If the number of partitions exceeds 2 log n, where n is the range of the input array, it uses a Heapsort algorithm.
        /// * Otherwise, it uses a Quicksort algorithm.
        /// </summary>
        /// <param name="list"> the complete list of all ascii codes for the entered values strings.</param>
        /// <returns></returns>
        private List<int> SortValues(List<int> list)
        {
            List<int> sortedList = list;
            list.Sort(new Comparison<int>(
                (i1, i2) => i2.CompareTo(i1))); //Using this Comparison object in order to make a descending sort.

            //sortedList = new QuickSort().DoQuickSort(list);  Using QuickSort that i implemented.
            //sortedList.Reverse();

            return sortedList;
        }

        /// <summary>
        /// Iterates on Values and calculate each string's ascii
        /// </summary>
        /// <param name="values">Dictionary that holds Values along with their initial asciis</param>
        private void CalculateASCIIForElements(Dictionary<string, int> values)
        {
            List<string> keys = new List<string>(values.Keys);
            foreach (string key in keys)
            {
                byte[] asciiBytes = Encoding.ASCII.GetBytes(key);
                int assciiCode = BitConverter.ToInt16(asciiBytes);
                values[key] = assciiCode;
            }
        }

        public override void RunWithDemoInput()
        {
            foreach(string value in PREDEFINED_VALUES)
            {
                valuesIndecesWithASCII[value] = 0;
            }
            DoWork(valuesIndecesWithASCII);
        }

        public override void RunWithUserInput()
        {
            //Get user's Values strings
            Console.WriteLine("\nPlease enter values, each in single line and when you're done type \"exit\" .");

            string input = Console.ReadLine();
            while (input.ToLower() != "exit")
            {
                valuesIndecesWithASCII[input] = 0;
                input = Console.ReadLine();
            }

            DoWork(valuesIndecesWithASCII);
        }

    }
}
