namespace P03_Recursive_Drawing
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            PrintFigure(n);
            Console.ReadLine();
        }

        private static void PrintFigure(int n)
        {
            if (n <= 0)
            {
                return;
            }

            Console.WriteLine(new string('*', n));
            PrintFigure(n - 1);
            Console.WriteLine(new string('#', n));
        }
    }
}