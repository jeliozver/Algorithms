namespace P06_The_8_Queens_Puzzle
{
    using System;

    public class StartUp
    {
        private const int Size = 8;
        private static readonly bool[,] ChessBoard = new bool[Size, Size];
        private static readonly bool[] AttackedColumns = new bool[Size];
        private static readonly bool[] AttackedLeftDiagonals = new bool[15];
        private static readonly bool[] AttackedRightDiagonals = new bool[15];

        public static void Main()
        {
            PutQueens(0);
        }

        private static void PutQueens(int row)
        {
            if (row == Size)
            {
                PrintSolution();
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    int leftDiagonalIndex = GetLeftDiagonalIndex(row, col);

                    if (CanPlaceQueen(row, col, leftDiagonalIndex))
                    {
                        MarkAllAttackedPositions(row, col, leftDiagonalIndex);
                        PutQueens(row + 1);
                        UnmarkAllAttackedPositions(row, col, leftDiagonalIndex);
                    }
                }
            }
        }

        private static void PrintSolution()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Console.Write(ChessBoard[i, j] ? "* " : "- ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static bool CanPlaceQueen(int row, int col, int leftDiagonalIndex)
        {
            bool isPositionOccupied =
                AttackedColumns[col] ||
                AttackedLeftDiagonals[leftDiagonalIndex] ||
                AttackedRightDiagonals[row + col];

            return !isPositionOccupied;
        }

        private static void MarkAllAttackedPositions(int row, int col, int leftDiagonalIndex)
        {
            AttackedColumns[col] = true;
            AttackedLeftDiagonals[leftDiagonalIndex] = true;
            AttackedRightDiagonals[row + col] = true;
            ChessBoard[row, col] = true;
        }

        private static void UnmarkAllAttackedPositions(int row, int col, int leftDiagonalIndex)
        {
            AttackedColumns[col] = false;
            AttackedLeftDiagonals[leftDiagonalIndex] = false;
            AttackedRightDiagonals[row + col] = false;
            ChessBoard[row, col] = false;
        }

        private static int GetLeftDiagonalIndex(int row, int col)
        {
            if (col - row == 0)
            {
                return 7;
            }

            return col - row + 7;
        }
    }
}