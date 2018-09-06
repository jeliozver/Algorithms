namespace P05_Merge_Sort
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

            MergeSort<int>.Sort(arr);
            Console.WriteLine(string.Join(" ", arr));
        }
    }

    public class MergeSort<T> where T : IComparable
    {
        private static T[] _aux;

        public static void Sort(T[] arr)
        {
            _aux = new T[arr.Length];
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Merge(T[] arr, int lo, int mid, int hi)
        {
            if (IsLess(arr[mid], arr[mid + 1]))
            {
                return;
            }

            for (int index = lo; index < hi + 1; index++)
            {
                _aux[index] = arr[index];
            }

            int i = lo;
            int j = mid + 1;

            for (int k = lo; k <= hi; k++)
            {
                if (i > mid)
                {
                    arr[k] = _aux[j++];
                }
                else if (j > hi)
                {
                    arr[k] = _aux[i++];
                }
                else if (IsLess(_aux[i], _aux[j]))
                {
                    arr[k] = _aux[i++];
                }
                else
                {
                    arr[k] = _aux[j++];
                }
            }
        }

        private static void Sort(T[] arr, int lo, int hi)
        {
            if (lo >= hi)
            {
                return;
            }

            int mid = lo + (hi - lo) / 2;

            Sort(arr, lo, mid);
            Sort(arr, mid + 1, hi);
            Merge(arr, lo, mid, hi);
        }

        private static bool IsLess(T first, T second)
        {
            return first.CompareTo(second) < 0;
        }
    }
}