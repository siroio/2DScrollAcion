using System;
using System.Collections.Generic;

public static class HashSetUtil
{
    public static T Find<T>(this HashSet<T> self, in Predicate<T> pre)
    {
        foreach (var item in self)
        {
            if (pre.Invoke(item))
            {
                return item;
            }
        }
        return default;
    }
}
