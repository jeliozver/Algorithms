namespace P03_Insertion_Sort
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

            InsertionSort.Sort(arr);
            // InsertionSort.SortRecursive(arr, arr.Length - 1);
            Console.WriteLine(string.Join(" ", arr));
        }
    }

    public class InsertionSort
    {
        public static void Sort<T>(T[] arr) where T : IComparable<T>
        {
            int i = 1;

            while (i < arr.Length)
            {
                T x = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j].CompareTo(x) > 0)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }

                arr[j + 1] = x;
                i = i + 1;
            }
        }

        // Gets StackOverflow with 100k+ elements
        public static void SortRecursive<T>(T[] arr, int n) where T : IComparable<T>
        {
            if (n > 0)
            {
                SortRecursive(arr, n - 1);
                T x = arr[n];
                int j = n - 1;

                while (j >= 0 && arr[j].CompareTo(x) > 0)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }

                arr[j + 1] = x;
            }
        }
    }
}