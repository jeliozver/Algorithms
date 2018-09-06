namespace P08_Fisher_Yates_Shuffle
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

            FisherYatesShuffle.Shuffle(arr);
            Console.WriteLine(string.Join(" ", arr));
        }
    }

    public class FisherYatesShuffle
    {
        public static void Shuffle<T>(T[] source) where T : IComparable<T>
        {
            Random rnd = new Random();

            for (int i = 0; i < source.Length; i++)
            {
                int r = i + rnd.Next(0, source.Length - i);

                Swap(source, i, r);
            }
        }

        private static void Swap<T>(T[] arr, int from, int to) where T : IComparable<T>
        {
            T temp = arr[from];
            arr[from] = arr[to];
            arr[to] = temp;
        }
    }
}