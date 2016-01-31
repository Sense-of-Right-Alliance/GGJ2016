using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class SpellDescriptor
{
    public string Name { get; private set; }

    Dictionary<string, float> opinions;

    public SpellDescriptor(string name, Dictionary<string, float> opinions)
    {
        this.Name = name;
        this.opinions = opinions;
    }

    public float GetOpinion(Region region)
    {
        if (!opinions.ContainsKey(region.InternalName))
            throw new ArgumentException("No opinion data available for region " + region.InternalName + " (" + region.DisplayedName + ")");

        return opinions[region.InternalName];
    }
}
