namespace P04_Variations_With_Repetition
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

            // VariationsRecursive<char>.Variate(elements, k);
            // VariationsIterative<char>.Variate(elements, k);
        }
    }

    public class VariationsRecursive<T>
    {
        private static T[] elements;
        private static T[] variations;

        public static void Variate(T[] el, int k)
        {
            elements = el;
            variations = new T[k];
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
                    variations[index] = elements[i];
                    Variate(index + 1);
                }
            }
        }

        private static void Print()
        {
            Console.WriteLine(string.Join(" ", variations));
        }
    }

    public class VariationsIterative<T>
    {
        private static T[] elements;
        private static int[] variations;

        public static void Variate(T[] el, int k)
        {
            elements = el;
            int n = el.Length;
            variations = new int[k];

            while (true)
            {
                Print();
                int index = k - 1;

                while (index >= 0 && variations[index] == n - 1)
                {
                    index--;
                }

                if (index < 0)
                {
                    break;
                }

                variations[index]++;

                for (int i = index + 1; i < k; i++)
                {
                    variations[i] = 0;
                }
            }
        }

        private static void Print()
        {
            for (int i = 0; i < variations.Length; i++)
            {
                Console.Write($"{elements[variations[i]]} ");
            }

            Console.WriteLine();
        }
    }
}