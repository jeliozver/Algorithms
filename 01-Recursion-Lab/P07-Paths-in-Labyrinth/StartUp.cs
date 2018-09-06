namespace P07_Paths_in_Labyrinth
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private const char FreeSpot = '-';
        private const char VisitedSpot = 'v';
        private const char Start = 's';
        private const char Exit = 'e';
        private static List<char> _path = new List<char>();
        private static char[,] _lab = ReadLab();

        public static void Main()
        {
            FindPaths(0, 0, 's');
        }

        private static char[,] ReadLab()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            char[,] lab = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string currentRow = Console.ReadLine();

                for (int j = 0; j < currentRow.Length; j++)
                {
                    lab[i, j] = currentRow[j];
                }
            }

            return lab;
        }

        private static void FindPaths(int row, int col, char direction)
        {
            if (!IsInBounds(row, col))
            {
                return;
            }

            if (direction != Start)
            {
                _path.Add(direction);
            }

            if (IsExit(row, col))
            {
                PrintPath();
            }
            else if (!IsVisited(row, col) && IsFree(row, col))
            {
                Mark(row, col);
                FindPaths(row, col + 1, 'R');
                FindPaths(row + 1, col, 'D');
                FindPaths(row, col - 1, 'L');
                FindPaths(row - 1, col, 'U');
                Unmark(row, col);
            }

            if (direction != Start)
            {
                _path.RemoveAt(_path.Count - 1);
            }
        }

        private static bool IsInBounds(int row, int col)
        {
            try
            {
                char a = _lab[row, col];

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool IsExit(int row, int col)
        {
            return _lab[row, col] == Exit;
        }

        private static bool IsVisited(int row, int col)
        {
            return _lab[row, col] == VisitedSpot;
        }

        private static bool IsFree(int row, int col)
        {
            return _lab[row, col] == FreeSpot;
        }

        private static void Mark(int row, int col)
        {
            _lab[row, col] = VisitedSpot;
        }

        private static void Unmark(int row, int col)
        {
            _lab[row, col] = FreeSpot;
        }

        private static void PrintPath()
        {
            Console.WriteLine(string.Join("", _path));
        }
    }
}