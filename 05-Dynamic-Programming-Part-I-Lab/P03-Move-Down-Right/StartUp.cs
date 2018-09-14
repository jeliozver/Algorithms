namespace P03_Move_Down_Right
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static readonly int Rows = int.Parse(Console.ReadLine());
        private static readonly int Cols = int.Parse(Console.ReadLine());
        private static readonly int[,] Matrix = new int[Rows, Cols];
        private static readonly int[,] Sums = new int[Rows, Cols];
        private static readonly List<string> Result = new List<string>();

        public static void Main()
        {
            FillMatrix();
            FillSums();
            ConstructPath();
            PrintResult();
        }

        private static void FillMatrix()
        {
            for (int row = 0; row < Rows; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < Cols; col++)
                {
                    Matrix[row, col] = currentRow[col];
                }
            }
        }

        private static void FillSums()
        {
            Sums[0, 0] = Matrix[0, 0];

            for (int row = 1; row < Rows; row++)
            {
                Sums[row, 0] = Sums[row - 1, 0] + Matrix[row, 0];
            }

            for (int col = 1; col < Cols; col++)
            {
                Sums[0, col] = Sums[0, col - 1] + Matrix[0, col];
            }

            for (int row = 1; row < Rows; row++)
            {
                for (int col = 1; col < Cols; col++)
                {
                    Sums[row, col] = Matrix[row, col] + Math.Max(Sums[row - 1, col], Sums[row, col - 1]);
                }
            }
        }

        private static void ConstructPath()
        {
            Result.Add(GetStep(Rows - 1, Cols - 1));

            int currentRow = Rows - 1;
            int currentCol = Cols - 1;

            while (currentRow != 0 || currentCol != 0)
            {
                int top = -1;
                int left = -1;

                if (currentRow - 1 >= 0)
                {
                    top = Sums[currentRow - 1, currentCol];
                }

                if (currentCol - 1 >= 0)
                {
                    left = Sums[currentRow, currentCol - 1];
                }

                if (top > left)
                {
                    Result.Add(GetStep(currentRow - 1, currentCol));
                    currentRow--;
                }
                else
                {
                    Result.Add(GetStep(currentRow, currentCol - 1));
                    currentCol--;
                }
            }

            Result.Reverse();
        }

        private static string GetStep(int row, int col)
        {
            return $"[{row}, {col}]";
        }

        private static void PrintResult()
        {
            Console.WriteLine(string.Join(" ", Result));
        }
    }
}