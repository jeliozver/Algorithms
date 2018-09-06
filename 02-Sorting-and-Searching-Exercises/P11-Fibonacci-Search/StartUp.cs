namespace P11_Fibonacci_Search
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int key = int.Parse(Console.ReadLine());

            int index = FibonacciSearch.IndexOf(arr, key);
            Console.WriteLine(index);
        }
    }

    public class FibonacciSearch
    {
        public static int IndexOf(int[] arr, int key)
        {
            int n = arr.Length;
            int fibMMm2 = 0;
            int fibMMm1 = 1;
            int fibM = fibMMm2 + fibMMm1;

            while (fibM < n)
            {
                fibMMm2 = fibMMm1;
                fibMMm1 = fibM;
                fibM = fibMMm2 + fibMMm1;
            }

            int offset = -1;

            while (fibM > 1)
            {
                int i = Math.Min(offset + fibMMm2, n - 1);

                if (arr[i] < key)
                {
                    fibM = fibMMm1;
                    fibMMm1 = fibMMm2;
                    fibMMm2 = fibM - fibMMm1;
                    offset = i;
                }
                else if (arr[i] > key)
                {
                    fibM = fibMMm2;
                    fibMMm1 = fibMMm1 - fibMMm2;
                    fibMMm2 = fibM - fibMMm1;
                }
                else
                {
                    return i;
                }
            }

            if (fibMMm1 == 1 && arr[offset + 1] == key)
            {
                return offset + 1;
            }

            return -1;
        }
    }
}