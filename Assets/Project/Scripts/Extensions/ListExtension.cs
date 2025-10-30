using System;
using System.Collections.Generic;
using System.Linq;

public static class ListExtension 
{
    public static bool DoesCointainSame<T>(this List<T> listA, List<T> listB)
    {
        if (listA == null || listB == null) return false;
        if (listA.Count != listB.Count) return false;

        var setA = new HashSet<T>(listA);
        var setB = new HashSet<T>(listB);

        return setA.SetEquals(setB);
    }

    public static void Shuffle<T>(this List<T> list)
    {
        Random rng = new Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            (list[k], list[n]) = (list[n], list[k]); // swap
        }
    }

}
