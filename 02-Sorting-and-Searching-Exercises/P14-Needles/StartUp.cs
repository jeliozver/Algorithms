namespace P14_Needles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static int[] _elements;
        private static int[] _needles;
        private static List<int> _indexes = new List<int>();

        public static void Main()
        {
            Console.ReadLine();

            _elements = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            _needles = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            FindIndex(_elements, _needles, _indexes);
            PrintResult();
        }

        private static void FindIndex(int[] elements, int[] needles, List<int> indexes)
        {
            int prev = elements[elements.Length - 1];

            for (int i = elements.Length - 1; i >= 0; i--)
            {
                if (elements[i] == 0)
                {
                    elements[i] = prev;
                }

                prev = elements[i];
            }

            for (int i = 0; i < needles.Length; i++)
            {
                bool isInserted = false;

                for (int j = 0; j < elements.Length; j++)
                {
                    if (needles[i] <= elements[j])
                    {
                        indexes.Add(j);
                        isInserted = true;
                        break;
                    }
                }

                if (!isInserted)
                {
                    int index = elements.Length - 1;

                    while (index > 0 && elements[index] == 0)
                    {
                        index--;
                    }

                    if (elements[index] == 0)
                    {
                        index--;
                    }

                    _indexes.Add(index + 1);
                }
            }
        }

        private static void PrintResult()
        {
            Console.WriteLine(string.Join(" ", _indexes));
        }
    }
}