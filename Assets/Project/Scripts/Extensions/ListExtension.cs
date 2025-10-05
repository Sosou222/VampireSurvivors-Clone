using System.Collections.Generic;

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

}
