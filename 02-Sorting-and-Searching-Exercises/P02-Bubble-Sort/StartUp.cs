namespace P02_Bubble_Sort
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

            BubbleSort.Sort(arr);
            Console.WriteLine(string.Join(" ", arr));
        }
    }

    public class BubbleSort
    {
        public static void Sort<T>(T[] arr) where T : IComparable<T>
        {
            int n = arr.Length;

            while (true)
            {
                bool isSwapped = false;

                for (int index = 1; index < n; index++)
                {
                    if (Less(arr[index - 1], arr[index]))
                    {
                        Swap(arr, index - 1, index);
                        isSwapped = true;
                    }
                }

                n -= 1;

                if (!isSwapped)
                {
                    break;
                }
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
            return first.CompareTo(second) > 0;
        }
    }
}