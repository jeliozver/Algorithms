namespace P08_Snakes
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private static char[] _currentSnake;
        private static readonly HashSet<string> VisitedCells = new HashSet<string>();
        private static readonly HashSet<string> Result = new HashSet<string>();
        private static readonly HashSet<string> AllPossibleSnakes = new HashSet<string>();

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            _currentSnake = new char[n];
            GenerateSnakes(0, 0, 0, 'S');
            PrintResult();
        }

        private static void GenerateSnakes(int index, int row, int col, char direction)
        {
            if (index >= _currentSnake.Length)
            {
                MarkSnake();
            }
            else
            {
                string cell = $"{row} {col}";

                if (!VisitedCells.Contains(cell))
                {
                    _currentSnake[index] = direction;

                    VisitedCells.Add(cell);
                    GenerateSnakes(index + 1, row, col + 1, 'R');
                    GenerateSnakes(index + 1, row + 1, col, 'D');
                    GenerateSnakes(index + 1, row, col - 1, 'L');
                    GenerateSnakes(index + 1, row - 1, col, 'U');
                    VisitedCells.Remove(cell);
                }
            }
        }

        private static void MarkSnake()
        {
            string normalSnake = new string(_currentSnake);

            if (AllPossibleSnakes.Contains(normalSnake))
            {
                return;
            }

            Result.Add(normalSnake);

            string flippedSnake = Flip(normalSnake);
            string reversedSnake = Reverse(normalSnake);
            string reversedFlippedSnake = Flip(reversedSnake);

            for (int i = 0; i < 4; i++)
            {
                AllPossibleSnakes.Add(normalSnake);
                normalSnake = Rotate(normalSnake);

                AllPossibleSnakes.Add(flippedSnake);
                flippedSnake = Rotate(flippedSnake);

                AllPossibleSnakes.Add(reversedSnake);
                reversedSnake = Rotate(reversedSnake);

                AllPossibleSnakes.Add(reversedFlippedSnake);
                reversedFlippedSnake = Rotate(reversedFlippedSnake);
            }
        }

        private static string Flip(string snake)
        {
            char[] newSnake = new char[snake.Length];

            for (int i = 0; i < snake.Length; i++)
            {
                switch (snake[i])
                {
                    case 'U':
                        newSnake[i] = 'D';
                        break;

                    case 'D':
                        newSnake[i] = 'U';
                        break;

                    default:
                        newSnake[i] = snake[i];
                        break;
                }
            }

            return new string(newSnake);
        }

        private static string Reverse(string snake)
        {
            char[] newSnake = new char[snake.Length];

            newSnake[0] = 'S';

            for (int i = 1; i < snake.Length; i++)
            {
                newSnake[snake.Length - i] = snake[i];
            }

            return new string(newSnake);
        }

        private static string Rotate(string snake)
        {
            char[] newSnake = new char[snake.Length];

            for (int i = 0; i < snake.Length; i++)
            {
                switch (snake[i])
                {
                    case 'R':
                        newSnake[i] = 'D';
                        break;

                    case 'D':
                        newSnake[i] = 'L';

                        break;

                    case 'L':
                        newSnake[i] = 'U';
                        break;

                    case 'U':
                        newSnake[i] = 'R';
                        break;

                    default:
                        newSnake[i] = snake[i];
                        break;
                }
            }

            return new string(newSnake);
        }

        private static void PrintResult()
        {
            foreach (var s in Result)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine($"Snakes count = {Result.Count}");
        }
    }
}