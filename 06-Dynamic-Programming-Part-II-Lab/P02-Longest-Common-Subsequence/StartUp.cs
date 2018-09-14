namespace P02_Longest_Common_Subsequence
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            string firstSeq = Console.ReadLine();
            string secondSeq = Console.ReadLine();

            int[,] lcs = CalcLcs(firstSeq, secondSeq);
            int maxLength = GetLength(lcs);

            Console.WriteLine(maxLength);

            // PrintLcs(firstSeq, secondSeq, lcs);
        }

        private static int[,] CalcLcs(string firstSeq, string secondSeq)
        {
            int[,] lcs = new int[firstSeq.Length + 1, secondSeq.Length + 1];

            for (int row = 1; row < lcs.GetLength(0); row++)
            {
                for (int col = 1; col < lcs.GetLength(1); col++)
                {
                    int up = lcs[row - 1, col];
                    int left = lcs[row, col - 1];

                    int result = Math.Max(up, left);

                    if (firstSeq[row - 1] == secondSeq[col - 1])
                    {
                        result = Math.Max(lcs[row - 1, col - 1] + 1, result);
                    }

                    lcs[row, col] = result;
                }
            }

            return lcs;
        }

        private static int GetLength(int[,] lcs)
        {
            return lcs[lcs.GetLength(0) - 1, lcs.GetLength(1) - 1];
        }

        private static void PrintLcs(string firstSeq, string secondSeq, int[,] lcs)
        {
            int currentRow = firstSeq.Length;
            int currentCol = secondSeq.Length;

            List<char> result = new List<char>();

            while (currentRow > 0 && currentCol > 0)
            {
                if (firstSeq[currentRow - 1] == secondSeq[currentCol - 1] &&
                    lcs[currentRow, currentCol] - 1 == lcs[currentRow - 1, currentCol - 1])
                {
                    result.Add(firstSeq[currentRow - 1]);
                    currentRow--;
                    currentCol--;
                }
                else if (lcs[currentRow - 1, currentCol] == lcs[currentRow, currentCol])
                {
                    currentRow--;
                }
                else
                {
                    currentCol--;
                }
            }

            result.Reverse();
            Console.WriteLine(string.Join("", result));
        }
    }
}