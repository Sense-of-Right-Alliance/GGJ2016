using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class SpellDescriptor
{
    public string Name { get; private set; }

    Dictionary<string, double> opinions;

    public SpellDescriptor(string name, Dictionary<string, double> opinions)
    {
        this.Name = name;
        this.opinions = opinions;

        //foreach (var opinion in opinions)
        //{
        //    var random = Utility.GetRandom(opinion.Key, name);
        //    opinions[opinion.Key] = opinion.Value + random.NextDouble().Between(-1.5, 1.5);
        //}
    }

    public double GetOpinion(Region region)
    {
        if (!opinions.ContainsKey(region.InternalName))
            throw new ArgumentException("No opinion data available for region " + region.InternalName + " (" + region.DisplayedName + ")");

        return opinions[region.InternalName];
    }
}
