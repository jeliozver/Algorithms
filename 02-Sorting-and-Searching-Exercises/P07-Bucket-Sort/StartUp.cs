namespace P07_Bucket_Sort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            BucketSort.Sort(arr);
            Console.WriteLine(string.Join(" ", arr));
        }
    }

    public class BucketSort
    {
        public static void Sort(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return;
            }

            int maxValue = arr[0];
            int minValue = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > maxValue)
                {
                    maxValue = arr[i];
                }

                if (arr[i] < minValue)
                {
                    minValue = arr[i];
                }
            }

            List<int>[] bucket = new List<int>[maxValue - minValue + 1];

            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }

            foreach (var t in arr)
            {
                bucket[t - minValue].Add(t);
            }

            int k = 0;

            foreach (var t in bucket)
            {
                if (t.Count > 0)
                {
                    foreach (var t1 in t)
                    {
                        arr[k] = t1;
                        k++;
                    }
                }
            }
        }
    }
}