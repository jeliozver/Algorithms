namespace P07_N_Choose_K_Count
{
    using System;
    using System.Numerics;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            BigInteger result = CalcFactorial(n) / (CalcFactorial(n - k) * CalcFactorial(k));
            Console.WriteLine(result);
        }

        public static BigInteger CalcFactorial(int number)
        {
            BigInteger factorial = 1;

            while (number > 1)
            {
                factorial *= number;
                number--;
            }

            return factorial;
        }
    }
}