namespace P01_Selection_Sort
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

            SelectionSort.Sort(arr);
            Console.WriteLine(string.Join(" ", arr));
        }
    }

    public class SelectionSort
    {
        public static void Sort<T>(T[] arr) where T : IComparable<T>
        {
            for (int index = 0; index < arr.Length; index++)
            {
                int min = index;

                for (int current = index + 1; current < arr.Length; current++)
                {
                    if (Less(arr[current], arr[min]))
                    {
                        min = current;
                    }
                }

                Swap(arr, index, min);
            }
        }

        private static void Swap<T>(T[] arr, int from, int to) where T : IComparable<T>
        {
            T temp = arr[from];
            arr[from] = arr[to];
            arr[to] = temp;
        }

        private static bool Less<T>(T first, T second) where T : IComparable<T>
        {
            return first.CompareTo(second) < 0;
        }
    }
}