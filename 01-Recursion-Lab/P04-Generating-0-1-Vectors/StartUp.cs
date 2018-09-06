namespace P04_Generating_0_1_Vectors
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] vector = new int[n];
            Gen01(0, vector);
        }

        private static void Gen01(int index, int[] vector)
        {
            if (index >= vector.Length)
            {
                Print(vector);
            }
            else
            {
                for (int i = 0; i <= 1; i++)
                {
                    vector[index] = i;
                    Gen01(index + 1, vector);
                }
            }
        }

        private static void Print(int[] vector)
        {
            Console.WriteLine(string.Join("", vector));
        }
    }
}