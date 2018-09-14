namespace P04_Rod_Cutting
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static int[] _prices;
        private static int[] _bestPrices;
        private static int[] _bestCombo;
        private static int _length;
        private static int _bestPrice;

        public static void Main()
        {
            _prices = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            _length = int.Parse(Console.ReadLine());

            _bestPrices = new int[_prices.Length];
            _bestCombo = new int[_prices.Length];

            _bestPrice = CutRod(_length);
            ReconstructSolution(_length);
        }

        private static int CutRod(int n)
        {
            for (int i = 0; i <= n; i++)
            {
                int currentBest = _bestPrices[i];

                for (int j = 1; j <= i; j++)
                {
                    currentBest = Math.Max(_bestPrices[i], _prices[j] + _bestPrices[i - j]);

                    if (currentBest > _bestPrices[i])
                    {
                        _bestPrices[i] = currentBest;
                        _bestCombo[i] = j;
                    }
                }
            }

            return _bestPrices[n];
        }

        private static void ReconstructSolution(int n)
        {
            Console.WriteLine(_bestPrice);

            while (n - _bestCombo[n] != 0)
            {
                Console.Write(_bestCombo[n] + " ");
                n -= _bestCombo[n];
            }

            Console.WriteLine(_bestCombo[n]);
        }
    }
}