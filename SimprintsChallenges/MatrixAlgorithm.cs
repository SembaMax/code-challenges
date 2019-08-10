using System;
namespace SimprintsChallenges
{

    /// <summary>
    /// By investigating the 3 dataset samples i figured out that sample 2 elements are filled with totally a different pattern than sample 3.
    /// So the algorithm here is not about the pattern or the technique to fill the Matrix.
    /// Result: the output is depending on the following rule
    /// Sum(LeftDiagonal) + Sum(RightDiagonal) - SharedElement
    /// Note: Shred element only exists when => MatrixDimension % 2 != 0
    /// </summary>
    public class MatrixAlgorithm: BaseChallenge
    {
        readonly int[,] PREDEFINED_MATRIX_1 = {
            { -1 }
        };

        readonly int[,] PREDEFINED_MATRIX_5 = {
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 0 },
            { 1, 2, 3, 4, 5 },
            { 6, 7, 8, 9, 0 },
            { 1, 2, 3, 4, 5 }
        };

        readonly int[,] PREDEFINED_MATRIX_6 = {
            { 10, 2, 3, 4, 5, 10 },
            { 1, 20, 3, 4, 20, 6 },
            { 1, 2, 30, 30, 5, 6 },
            { 1, 2, 40, 40, 5, 6 },
            { 1, 50, 3, 4, 50, 6 },
            { 60, 2, 3, 4, 5, 60 }
        };


        public MatrixAlgorithm()
        {
            base.ReadInitialInput();
        }

        public override void DisplayOutput(object arg)
        {
            Console.WriteLine();
            Console.WriteLine("Output : " + (int)arg);
        }

        public override void DoWork(object arg)
        {
            int[,] matrix = (int[,]) arg;
            //Render Matrix on Console.
            DisplayMatrix(matrix);

            //This is the exceptional case of the algorithm, which having one element Matrix.
            if (matrix.GetLength(0) == 1)
            {
                DisplayOutput(matrix[0, 0]);
                return;
            }

            int output = RunMatrixAlgorithm(matrix);
            DisplayOutput(output);
        }

        /// <summary>
        /// Perform the mentioned equation that produces our output.
        /// Equation : Sum(LeftDiagonal) + Sum(RightDiagonal) - SharedElement
        /// </summary>
        /// <param name="matrix"> the input matrix</param>
        /// <returns></returns>
        private int RunMatrixAlgorithm(int[,] matrix)
        {
            int leftSum = GetSumOfLeftDiagonal(matrix);
            int rightSum = GetSumOfRightDiagonal(matrix);

            int indexCenter = (int)MathF.Floor(matrix.GetLength(0) / 2f);
            int sharedElement = (matrix.Length % 2 != 0) ? matrix[indexCenter, indexCenter] : 0;

            return leftSum + rightSum - sharedElement;
        }

        private int GetSumOfLeftDiagonal(int[,] matrix)
        {
            int sum = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
            }

            return sum;
        }

        private int GetSumOfRightDiagonal(int[,] matrix)
        {
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, matrix.GetLength(0) - i - 1];
            }

            return sum;
        }

        private void DisplayMatrix(int[,] matrix)
        {
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write( " {0} ", matrix[i, j]);
            }
        }

        public override void RunWithDemoInput()
        {
            //Just run the three samples like the document.
            DoWork(PREDEFINED_MATRIX_1);
            DoWork(PREDEFINED_MATRIX_5);
            DoWork(PREDEFINED_MATRIX_6);
        }

        public override void RunWithUserInput()
        {
            //Get the single dimension of the Matrix size
            Console.WriteLine("Enter Matrix Dimension : ");
            string input = Console.ReadLine();

            int.TryParse(input, out int dimension);

            if (dimension == 0)
            {
                Console.WriteLine("Wrong integer value.");
                base.ReadInitialInput();
                return;
            }  

            //Fill all elements bu user's input
            int[,] matrix = FillMatrixWithSize(dimension);
            DoWork(matrix);
        }

        private int[,] FillMatrixWithSize(int dimension)
        {
            int[,] matrix = new int[dimension, dimension];
            for (int i = 0; i < dimension; i++)
            {
                Console.WriteLine("Row " + (i + 1) + " : ");
                for (int j = 0; j < dimension; j++)
                {
                    int element = 0;
                    while (element == 0)
                    {
                        Console.WriteLine("Element " + (j + 1) + " : ");
                        string input = Console.ReadLine();
                        int.TryParse(input, out element);
                    }
                    matrix[i, j] = element;
                }
                Console.WriteLine();
            }

            return matrix;
        }
    }
}
