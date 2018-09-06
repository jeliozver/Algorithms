namespace P04_Shell_Sort
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

            ShellSort.Sort(arr);
            Console.WriteLine(string.Join(" ", arr));
        }
    }

    public class ShellSort
    {
        public static void Sort(int[] arr)
        {
            int n = arr.Length;

            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = arr[i];
                    int j;

                    for (j = i; j >= gap && arr[j - gap] > temp; j -= gap)
                    {
                        arr[j] = arr[j - gap];
                    }

                    arr[j] = temp;
                }
            }
        }
    }
}