namespace P04_Towers_of_Hanoi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static readonly int N = int.Parse(Console.ReadLine());
        private static readonly Stack<int> Source = new Stack<int>(Enumerable.Range(1, N).Reverse());
        private static readonly Stack<int> Destination = new Stack<int>();
        private static readonly Stack<int> Spare = new Stack<int>();
        private static int _stepsTaken;

        public static void Main()
        {
            int numberOfDisks = Source.Count;
            PrintRods();
            MoveDisks(numberOfDisks, Source, Destination, Spare);
        }

        private static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            if (bottomDisk == 1)
            {
                DoMove(source, destination);
            }
            else
            {
                MoveDisks(bottomDisk - 1, source, spare, destination);
                DoMove(source, destination);
                MoveDisks(bottomDisk - 1, spare, destination, source);
            }
        }

        private static void DoMove(Stack<int> source, Stack<int> destination)
        {
            _stepsTaken++;
            destination.Push(source.Pop());
            LogMove();
            PrintRods();
        }

        private static void LogMove()
        {
            Console.WriteLine($"Step #{_stepsTaken}: Moved disk");
        }

        private static void PrintRods()
        {
            PrintSource();
            PrintDestination();
            PrintSpare();
            Console.WriteLine();
        }

        private static void PrintSource()
        {
            Console.WriteLine($"Source: {string.Join(", ", Source.Reverse())}");
        }

        private static void PrintDestination()
        {
            Console.WriteLine($"Destination: {string.Join(", ", Destination.Reverse())}");
        }

        private static void PrintSpare()
        {
            Console.WriteLine($"Spare: {string.Join(", ", Spare.Reverse())}");
        }
    }
}