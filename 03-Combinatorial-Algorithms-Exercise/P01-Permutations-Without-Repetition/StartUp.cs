namespace P01_Permutations_Without_Repetition
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            char[] elements = Console.ReadLine()
                .Split()
                .Select(char.Parse)
                .ToArray();

            PermuteRecursive<char>.Permute(elements);
            // PermuteIterative<char>.Permute(elements);
        }

        public class PermuteRecursive<T> where T : IComparable<T>
        {
            private static T[] _elements;

            public static void Permute(T[] el)
            {
                _elements = el;
                Permute(0);
            }

            private static void Permute(int index)
            {
                if (index >= _elements.Length)
                {
                    Print();
                }
                else
                {
                    Permute(index + 1);

                    for (int i = index + 1; i < _elements.Length; i++)
                    {
                        Swap(index, i);
                        Permute(index + 1);
                        Swap(index, i);
                    }
                }
            }

            private static void Swap(int first, int second)
            {
                T temp = _elements[first];
                _elements[first] = _elements[second];
                _elements[second] = temp;
            }

            private static void Print()
            {
                Console.WriteLine(string.Join(" ", _elements));
            }
        }

        public class PermuteIterative<T>
        {
            public static void Permute(T[] elements)
            {
                Print(elements);
                int n = elements.Length;
                int[] p = new int[n];
                int i = 1;

                while (i < n)
                {
                    if (p[i] < i)
                    {
                        int j = ((i % 2) == 0) ? 0 : p[i];
                        Swap(elements, i, j);
                        Print(elements);
                        p[i]++;
                        i = 1;
                    }
                    else
                    {
                        p[i] = 0;
                        i++;
                    }
                }
            }

            private static void Swap(T[] elements, int first, int second)
            {
                T temp = elements[first];
                elements[first] = elements[second];
                elements[second] = temp;
            }

            private static void Print(T[] elements)
            {
                Console.WriteLine(string.Join(" ", elements));
            }
        }
    }
}