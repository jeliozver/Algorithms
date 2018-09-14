namespace P02_Longest_Increasing_Subsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static int[] _sequence;
        private static int[] _len;
        private static int[] _prev;
        private static int _maxLen;
        private static int _lastIndex = -1;
        private static readonly List<int> LongestSequence = new List<int>();

        public static void Main()
        {
            _sequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            _len = new int[_sequence.Length];
            _prev = new int[_sequence.Length];

            CalculateLis();
        }

        private static void CalculateLis()
        {
            if (_sequence.Length == 1)
            {
                Console.WriteLine(_sequence[0]);
                return;
            }

            for (int current = 0; current < _sequence.Length; current++)
            {
                _len[current] = 1;
                _prev[current] = -1;

                for (int prev = 0; prev < current; prev++)
                {
                    if (_sequence[current] > _sequence[prev] && _len[prev] + 1 > _len[current])
                    {
                        _len[current] = 1 + _len[prev];
                        _prev[current] = prev;
                    }
                }

                if (_len[current] > _maxLen)
                {
                    _maxLen = _len[current];
                    _lastIndex = current;
                }
            }

            RestoreLis();
        }

        private static void RestoreLis()
        {
            while (_lastIndex != -1)
            {
                LongestSequence.Add(_sequence[_lastIndex]);
                _lastIndex = _prev[_lastIndex];
            }

            LongestSequence.Reverse();
            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine(string.Join(" ", LongestSequence));
        }
    }
}