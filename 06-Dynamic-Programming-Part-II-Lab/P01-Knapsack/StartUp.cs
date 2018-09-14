namespace P01_Knapsack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static readonly int Capacity = int.Parse(Console.ReadLine());
        private static readonly List<Item> TakenItems = new List<Item>();
        private static List<Item> _items = new List<Item>();
        private static int[,] _prices;
        private static bool[,] _itemsIncluded;
        private static int _totalWeight;
        private static int _totalValue;

        public static void Main()
        {
            GetItems();
            FillKnapsack();
            GetResults();
            PrintResult();
        }

        private static void GetItems()
        {
            string currentItem = Console.ReadLine();

            while (currentItem != "end")
            {
                string[] args = currentItem.Split();

                string itemName = args[0];
                int itemWeight = int.Parse(args[1]);
                int itemPrice = int.Parse(args[2]);

                Item newItem = new Item
                {
                    Name = itemName,
                    Weight = itemWeight,
                    Price = itemPrice
                };

                _items.Add(newItem);

                currentItem = Console.ReadLine();
            }

            _items = _items.OrderByDescending(x => x.Name).ToList();
            _prices = new int[_items.Count + 1, Capacity + 1];
            _itemsIncluded = new bool[_items.Count + 1, Capacity + 1];
        }

        private static void FillKnapsack()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                Item item = _items[i];

                for (int j = 0; j <= Capacity; j++)
                {
                    if (item.Weight > j)
                    {
                        continue;
                    }

                    int excluding = _prices[i, j];
                    int including = item.Price + _prices[i, j - item.Weight];

                    if (including > excluding)
                    {
                        _prices[i + 1, j] = including;
                        _itemsIncluded[i + 1, j] = true;
                    }
                    else
                    {
                        _prices[i + 1, j] = excluding;
                    }
                }
            }
        }

        private static void GetResults()
        {
            _totalValue = _prices[_items.Count, Capacity];

            int capacity = Capacity;

            for (int i = _items.Count - 1; i >= 0; i--)
            {
                Item currentItem = _items[i];

                if (_itemsIncluded[i + 1, capacity])
                {
                    TakenItems.Add(currentItem);
                    capacity -= currentItem.Weight;
                    _totalWeight += currentItem.Weight;
                }
            }
        }

        private static void PrintResult()
        {
            Console.WriteLine($"Total Weight: {_totalWeight}");
            Console.WriteLine($"Total Value: {_totalValue}");

            foreach (var i in TakenItems)
            {
                Console.WriteLine(i.Name);
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Price { get; set; }
    }
}