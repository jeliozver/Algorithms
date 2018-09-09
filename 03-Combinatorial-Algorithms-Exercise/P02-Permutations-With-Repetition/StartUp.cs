namespace P02_Permutations_With_Repetition
{
    using System;
    using System.Collections.Generic;
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
            // PermuteRecursive<char>.PermuteRepOpt(elements);
        }

        public class PermuteRecursive<T> where T : IComparable<T>
        {
            public static void Permute(T[] elements)
            {
                Permute(elements, 0);
            }

            public static void PermuteRepOpt(T[] elements)
            {
                Array.Sort(elements);
                PermuteRepOpt(elements, 0, elements.Length - 1);
            }

            private static void Permute(T[] elements, int index)
            {
                if (index >= elements.Length)
                {
                    Print(elements);
                }
                else
                {
                    HashSet<T> swapped = new HashSet<T>();

                    for (int i = index; i < elements.Length; i++)
                    {
                        if (!swapped.Contains(elements[i]))
                        {
                            Swap(elements, index, i);
                            Permute(elements, index + 1);
                            Swap(elements, index, i);
                            swapped.Add(elements[i]);
                        }
                    }
                }
            }

            private static void PermuteRepOpt(T[] elements, int start, int end)
            {
                Print(elements);

                for (int i = end - 1; i >= start; i--)
                {
                    for (int j = i + 1; j <= end; j++)
                    {
                        if (!elements[i].Equals(elements[j]))
                        {
                            Swap(elements, i, j);
                            PermuteRepOpt(elements, i + 1, end);
                        }
                    }

                    T temp = elements[i];

                    for (int k = i; k <= end - 1; k++)
                    {
                        elements[k] = elements[k + 1];
                        elements[end] = temp;
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