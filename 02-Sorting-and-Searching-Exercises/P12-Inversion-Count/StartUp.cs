namespace P12_Inversion_Count
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

            //            int inversionsSimple = InversionCount.Simple(arr);
            //            Console.WriteLine(inversionsSimple);

            int inversionsComplex = InversionCount.Complex(arr);
            Console.WriteLine(inversionsComplex);
        }
    }

    public class InversionCount
    {
        private static int[] _aux;

        public static int Simple(int[] arr)
        {
            int inversions = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        inversions++;
                    }
                }
            }

            return inversions;
        }

        public static int Complex(int[] arr)
        {
            _aux = new int[arr.Length];
            return Sort(arr, 0, arr.Length - 1);
        }

        private static int Sort(int[] arr, int lo, int hi)
        {
            int inversions = 0;

            if (hi > lo)
            {
                int mid = (hi + lo) / 2;

                inversions = Sort(arr, lo, mid);
                inversions += Sort(arr, mid + 1, hi);
                inversions += Merge(arr, lo, mid + 1, hi);
            }

            return inversions;
        }

        private static int Merge(int[] arr, int lo, int mid, int hi)
        {
            int inversions = 0;
            int i = lo;
            int j = mid;
            int k = lo;

            while (i <= mid - 1 && j <= hi)
            {
                if (arr[i] <= arr[j])
                {
                    _aux[k++] = arr[i++];
                }
                else
                {
                    _aux[k++] = arr[j++];
                    inversions += mid - i;
                }
            }

            while (i <= mid - 1)
            {
                _aux[k++] = arr[i++];
            }

            while (j <= hi)
            {
                _aux[k++] = arr[j++];
            }

            for (int l = lo; l <= hi; l++)
            {
                arr[l] = _aux[l];
            }

            return inversions;
        }
    }
}