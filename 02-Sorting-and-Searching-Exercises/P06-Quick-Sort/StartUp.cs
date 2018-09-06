namespace P06_Quick_Sort
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

            QuickSort.Sort(arr);
            Console.WriteLine(string.Join(" ", arr));
        }
    }

    public class QuickSort
    {
        public static void Sort<T>(T[] arr) where T : IComparable<T>
        {
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort<T>(T[] arr, int lo, int hi) where T : IComparable<T>
        {
            if (lo >= hi)
            {
                return;
            }

            int pivot = Partition(arr, lo, hi);
            Sort(arr, lo, pivot - 1);
            Sort(arr, pivot + 1, hi);
        }

        private static int Partition<T>(T[] arr, int lo, int hi) where T : IComparable<T>
        {
            if (lo >= hi)
            {
                return lo;
            }

            int i = lo;
            int j = hi + 1;

            while (true)
            {
                while (Less(arr[++i], arr[lo]))
                {
                    if (i == hi)
                    {
                        break;
                    }
                }

                while (Less(arr[lo], arr[--j]))
                {
                    if (j == lo)
                    {
                        break;
                    }
                }

                if (i >= j)
                {
                    break;
                }

                Swap(arr, i, j);
            }

            Swap(arr, lo, j);
            return j;
        }

        private static bool Less<T>(T first, T second) where T : IComparable<T>
        {
            return first.CompareTo(second) < 0;
        }

        private static void Swap<T>(T[] arr, int first, int second) where T : IComparable<T>
        {
            T temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }
    }
}