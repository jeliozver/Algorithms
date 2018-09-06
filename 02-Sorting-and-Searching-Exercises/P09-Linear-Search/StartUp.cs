namespace P09_Linear_Search
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

            int index = LinearSearch.IndexOf(arr, key);
            Console.WriteLine(index);
        }
    }

    public class LinearSearch
    {
        public static int IndexOf(int[] arr, int key)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == key)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}