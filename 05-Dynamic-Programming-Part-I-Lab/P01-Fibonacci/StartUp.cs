namespace P01_Fibonacci
{
    using System;

    public class StartUp
    {
        private static int[] _numbers;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            _numbers = new int[n + 1];

            Console.WriteLine(FibonacciRecursiveOptimized(n));
            // Console.WriteLine(FibonacciIterative(n));
            // Console.WriteLine(FibonacciRecursive(n));
        }

        private static int FibonacciRecursive(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }

            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }

        private static int FibonacciRecursiveOptimized(int n)
        {
            if (_numbers[n] != 0)
            {
                return _numbers[n];
            }

            if (n == 1 || n == 2)
            {
                return 1;
            }

            int result = FibonacciRecursiveOptimized(n - 1) + FibonacciRecursiveOptimized(n - 2);
            _numbers[n] = result;

            return result;
        }

        private static int FibonacciIterative(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return 1;
            }

            int prevPrev = 0;
            int prev = 1;
            int result = 0;

            for (int i = 2; i <= n; i++)
            {
                result = prev + prevPrev;
                prevPrev = prev;
                prev = result;
            }

            return result;
        }
    }
}