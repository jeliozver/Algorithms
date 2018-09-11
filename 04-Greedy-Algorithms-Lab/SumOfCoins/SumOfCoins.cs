using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main()
    {
        var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
        var targetSum = 923;

        var selectedCoins = ChooseCoins(availableCoins, targetSum);

        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
        foreach (var selectedCoin in selectedCoins)
        {
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        Dictionary<int, int> chosenCoins = new Dictionary<int, int>();
        int currentSum = 0;
        int coinIndex = 0;

        coins = coins
            .OrderByDescending(c => c)
            .ToList();

        while (currentSum != targetSum && coinIndex < coins.Count)
        {
            int currentCoinValue = coins[coinIndex];
            int remainingSum = targetSum - currentSum;
            int numberOfCoinsToTake = remainingSum / currentCoinValue;

            if (numberOfCoinsToTake > 0)
            {
                chosenCoins.Add(currentCoinValue, numberOfCoinsToTake);
                currentSum += currentCoinValue * numberOfCoinsToTake;
            }

            coinIndex++;
        }

        if (currentSum != targetSum)
        {
            throw new InvalidOperationException();
        }

        return chosenCoins;
    }
}