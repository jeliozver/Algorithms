namespace P13_Words
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string elements = Console.ReadLine();
            string unique = new string(elements.Distinct().ToArray());

            if (elements.Length == unique.Length)
            {
                Console.WriteLine(CalcFactorial(elements.Length));
                return;
            }

            int words = PermuteRecursive.Permute(elements.ToCharArray());
            Console.WriteLine(words);
        }

        public static int CalcFactorial(int number)
        {
            int factorial = 1;

            while (number > 1)
            {
                factorial *= number;
                number--;
            }

            return factorial;
        }
    }

    public class PermuteRecursive
    {
        private static int wordsCount = 0;

        public static int Permute(char[] elements)
        {
            Array.Sort(elements);
            Permute(elements, 0, elements.Length);
            return wordsCount;
        }

        private static void Permute(char[] elements, int start, int n)
        {
            if (IsValid(elements))
            {
                wordsCount++;
            }

            for (int i = n - 2; i >= start; i--)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (elements[i] != elements[j])
                    {
                        Swap(elements, i, j);
                        Permute(elements, i + 1, n);
                    }
                }

                char tmp = elements[i];

                for (int k = i; k < n - 1;)
                {
                    elements[k] = elements[++k];
                }

                elements[n - 1] = tmp;
            }
        }

        private static void Swap(char[] elements, int first, int second)
        {
            char temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }

        private static bool IsValid(char[] elements)
        {
            for (int i = 0; i < elements.Length - 1; i++)
            {
                if (elements[i] == elements[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}