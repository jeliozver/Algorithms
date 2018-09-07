namespace P05_Combinations_Without_Repetition
{
    using System;

    public class StartUp
    {
        private static int[] _loops;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            _loops = new int[k];
            CombinationsWithoutRepetition(n, k, 0, 1);
        }

        public static void CombinationsWithoutRepetition(int n, int k, int current, int loopStart)
        {
            if (current == k)
            {
                Print();
                return;
            }

            for (int i = loopStart; i <= n; i++)
            {
                _loops[current] = i;
                CombinationsWithoutRepetition(n, k, current + 1, i + 1);
            }
        }

        private static void Print()
        {
            Console.WriteLine(string.Join(" ", _loops));
        }
    }
}