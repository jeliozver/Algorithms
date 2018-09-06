namespace P02_Nested_Loops
{
    using System;

    public class StartUp
    {
        private static int[] _loops;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            _loops = new int[n];

            NestedLoopsRecursive(n, 0);
        }

        public static void NestedLoopsRecursive(int n, int current)
        {
            if (current == n)
            {
                Print();
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                _loops[current] = i;
                NestedLoopsRecursive(n, current + 1);
            }
        }

        private static void Print()
        {
            Console.WriteLine(string.Join(" ", _loops));
        }
    }
}