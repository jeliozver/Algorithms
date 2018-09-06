namespace P02_Recursive_Factorial
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            long factorial = Factorial(n);
            Console.WriteLine(factorial);
        }

        private static long Factorial(int n)
        {
            if (n == 1)
            {
                return n;
            }

            return n * Factorial(n - 1);
        }
    }
}