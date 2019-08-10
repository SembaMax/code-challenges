using System;
using System.Collections.Generic;
namespace SimprintsChallenges
{
    public class CharactersOccurrencesHistogram : BaseChallenge
    {
        readonly string PREDEFINED_CV_INPUT = 
"I'm Mohamed Salah, I have been working as a Mobile Developer for four years with a proven experience in the field." + 
"i've been working on large scale projects on both platforms Android and IOS, developing with the latest technologies such as Kotlin, Swift and Flutter. also by some powerful patterns and tools such as Jetpack, Retrofit, Dagger, Kotlin Coroutines, MVVM, MVP, Reactive Programming (RX) and Kodein." +
"Also i published many apps on Google and Apple stores which are in use by very satisfied clients and customers." +
"I got an experience with Games, VR, Web and other software fields as well." +
"I thrive in an innovative environment and I know that I have the skills, experience, and attitude to excel in this position." +
"I would love to meet and discuss what I can bring to this role.I can be reached at semba.max@gmail.com" +
"Thanks.";

        public CharactersOccurrencesHistogram()
        {
            base.ReadInitialInput();
        }

        public override void DisplayOutput(object arg)
        {
            var occurrences = (Dictionary<char, string>) arg;
            foreach (KeyValuePair<char, string> pair in occurrences)
            {
                Console.WriteLine("\n{0} : {1}", pair.Key, pair.Value);
            }
        }

        public override void DoWork(object arg)
        {
            string parameter = (string)arg;
            //In order for saving time, we construct the histogram's bars while calculating the occurrences. we could save space and cache them as integers. but we would consume more time while rendering them in return.
            Dictionary<char, string> histogram = new Dictionary<char, string>();

            foreach (char letter in parameter)
            {
                char lowerLetter = Char.ToLower(letter);
                histogram.TryGetValue(lowerLetter, out string existingValue);
                histogram[lowerLetter] = existingValue + " -";
            }
            DisplayOutput(histogram);
        }

        public override void RunWithDemoInput()
        {
            DoWork(PREDEFINED_CV_INPUT);
        }

        public override void RunWithUserInput()
        {
            Console.WriteLine("\nImporting pdf files is not implemented in this challenge because this is not relevant to the challenge purpose. \n" +
                "but in case we want to implement this part, we would use \"IText7\" third party lib at \"https://github.com/itext/itext7-dotnet\" .");
            base.ReadInitialInput();
        }

    }
}
