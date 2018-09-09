namespace P06_Combinations_With_Repetition
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
            int k = int.Parse(Console.ReadLine());

            CombinationsRecursive<char>.Combine(elements, k);
        }

        public class CombinationsRecursive<T>
        {
            private static T[] elements;
            private static int[] combinations;
            private static int _k;

            public static void Combine(T[] el, int k)
            {
                _k = k;
                elements = el;
                combinations = new int[_k];
                Combine(0, 0);
            }

            private static void Combine(int index, int start)
            {
                if (index >= _k)
                {
                    Print();
                }
                else
                {
                    for (int i = start; i < elements.Length; i++)
                    {
                        combinations[index] = i;
                        Combine(index + 1, i);
                    }
                }
            }

            private static void Print()
            {
                for (int i = 0; i < combinations.Length; i++)
                {
                    Console.Write(elements[combinations[i]] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}