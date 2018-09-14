namespace P03_Subset_Sum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static readonly Dictionary<int, int> Result = new Dictionary<int, int>();
        private static readonly int TargetSum = 9;

        public static void Main()
        {
            int[] numbers = { 3, 5, 1, 4, 2 };
            CalcSums(numbers);
            PrintResult();
        }

        private static void CalcSums(int[] numbers)
        {
            Result.Add(0, 0);

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];

                foreach (var num in Result.Keys.ToList())
                {
                    int sum = num + currentNumber;

                    if (!Result.ContainsKey(sum))
                    {
                        Result.Add(sum, currentNumber);
                    }
                }
            }
        }

        private static void PrintResult()
        {
            if (Result.ContainsKey(TargetSum))
            {
                Console.WriteLine("Sum was reached!");
                int sum = TargetSum;
                List<int> sums = new List<int>();

                while (sum != 0)
                {
                    int number = Result[sum];
                    sum -= number;
                    sums.Add(number);
                }

                sums.Reverse();
                Console.WriteLine(string.Join(" ", sums));
            }
            else
            {
                Console.WriteLine("Sum was not reached!");
            }
        }
    }
}