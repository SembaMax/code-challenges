using System;
namespace SimprintsChallenges
{

    /// <summary>
    /// Base abstract class of the challenges.
    /// </summary>
    public abstract class BaseChallenge
    {

        /// <summary>
        /// Getting the initial user's choise between the two avaialble input modes.
        /// </summary>
        public void ReadInitialInput()
        {
            Console.WriteLine("\n1- Run with predefined input \n2- Enter the input manually");
            string userInput = Console.ReadLine();
            CheckAndMatchUserInput(userInput);
        }

        /// <summary>
        /// Checking which selection that user has done. then execute the corresponding function depending on the input.
        /// </summary>
        /// <param name="input"> It's the initial user input of picking a specific way to enter the program's input </param>
        private void CheckAndMatchUserInput(string input)
        {
            short.TryParse(input, out short choise);

            switch (choise)
            {
                case 1:
                    RunWithDemoInput();
                    break;
                case 2:
                    RunWithUserInput();
                    break;
                default:
                    Console.WriteLine("Your choise is not supported, Please try again.");
                    ReadInitialInput();
                    break;
            }

        }

        /// <summary>
        /// Provides a hardcoded input for the program.
        /// </summary>
        public abstract void RunWithDemoInput();

        /// <summary>
        /// Allow user to enter the program's input manually.
        /// </summary>
        public abstract void RunWithUserInput();

        /// <summary>
        /// Execute the intended Algorithm and produce the results.
        /// </summary>
        public abstract void DoWork(object arg);

        /// <summary>
        /// Shows the results on UI.
        /// </summary>
        public abstract void DisplayOutput(object arg);
    }
}
