namespace P05_Generating_Combinations
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] set = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int limit = int.Parse(Console.ReadLine());

            int[] vector = new int[limit];

            GenCombinations(set, vector, 0, 0);
        }

        private static void GenCombinations(int[] set, int[] vector, int index, int border)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
            }
            else
            {
                for (int i = border; i < set.Length; i++)
                {
                    vector[index] = set[i];
                    GenCombinations(set, vector, index + 1, i + 1);
                }
            }
        }
    }
}