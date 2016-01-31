using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public static class Utility
{
    public static System.Random GetRandom(string seed)
    {
        return new System.Random(seed.GetHashCode());
    }

    public static System.Random GetRandom(string seed1, string seed2)
    {
        int hash = 17;
        unchecked
        {
            hash = hash * 31 + seed1.GetHashCode();
            hash = hash * 31 + seed2.GetHashCode();
        }
        return new System.Random(hash);
    }

    public static double Random(string seed)
    {
        var rand = new System.Random(seed.GetHashCode());
        return rand.NextDouble();
    }

    public static double Random(string seed1, string seed2)
    {
        int hash = 17;
        unchecked
        {
            hash = hash * 31 + seed1.GetHashCode();
            hash = hash * 31 + seed2.GetHashCode();
        }
        var rand = new System.Random(hash);
        return rand.NextDouble();
    }

    public static double RandomBetween(string seed, double lowerBound, double upperBound)
    {
        return Random(seed).Between(lowerBound, upperBound);
    }

    public static double RandomBetween(string seed1, string seed2, double lowerBound, double upperBound)
    {
        return Random(seed1, seed2).Between(lowerBound, upperBound);
    }

    public static double Between(this double percent, double lowerBound, double upperBound)
    {
        var range = upperBound - lowerBound;
        var result = percent * range;
        result += lowerBound;
        return result;
    }


}
