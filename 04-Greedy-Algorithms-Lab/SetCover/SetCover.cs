using System;
using System.Collections.Generic;
using System.Linq;

public class SetCover
{
    public static void Main(string[] args)
    {
        var universe = new[] { 1, 3, 5, 7, 9, 11, 20, 30, 40 };
        var sets = new[]
        {
                new[] { 20 },
                new[] { 1, 5, 20, 30 },
                new[] { 3, 7, 20, 30, 40 },
                new[] { 9, 30 },
                new[] { 11, 20, 30, 40 },
                new[] { 3, 7, 40 }
            };

        var selectedSets = ChooseSets(sets.ToList(), universe.ToList());
        Console.WriteLine($"Sets to take ({selectedSets.Count}):");
        foreach (var set in selectedSets)
        {
            Console.WriteLine($"{{ {string.Join(", ", set)} }}");
        }
    }

    public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
    {
        List<int[]> selectedSets = new List<int[]>();

        HashSet<int> universeSet = new HashSet<int>(universe);
        HashSet<int[]> setsSet = new HashSet<int[]>(sets);

        while (universeSet.Count > 0)
        {
            var currentSet = setsSet
                .OrderByDescending(s => s.Count(universeSet.Contains))
                .First();

            selectedSets.Add(currentSet);
            setsSet.Remove(currentSet);

            foreach (var t in currentSet)
            {
                universeSet.Remove(t);
            }
        }

        return selectedSets;
    }
}