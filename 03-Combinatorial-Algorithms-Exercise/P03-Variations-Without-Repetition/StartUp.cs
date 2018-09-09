namespace P03_Variations_Without_Repetition
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

            VariationsRecursive<char>.Variate(elements, k);
        }
    }

    public class VariationsRecursive<T>
    {
        private static T[] elements;
        private static T[] variations;
        private static bool[] used;

        public static void Variate(T[] el, int k)
        {
            elements = el;
            variations = new T[k];
            used = new bool[elements.Length];
            Variate(0);
        }

        private static void Variate(int index)
        {
            if (index >= variations.Length)
            {
                Print();
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        variations[index] = elements[i];
                        Variate(index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        private static void Print()
        {
            Console.WriteLine(string.Join(" ", variations));
        }
    }
}