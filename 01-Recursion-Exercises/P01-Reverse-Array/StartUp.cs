namespace P01_Reverse_Array
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

            Reverse(arr, 0, arr.Length - 1);
            Console.WriteLine(string.Join(" ", arr));
        }

        public static void Reverse(int[] arr, int lo, int hi)
        {
            if (hi + 1 - lo < 1)
            {
                return;
            }

            Swap(arr, lo, hi);
            Reverse(arr, ++lo, --hi);
        }

        private static void Swap(int[] arr, int first, int second)
        {
            int temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }
    }
}