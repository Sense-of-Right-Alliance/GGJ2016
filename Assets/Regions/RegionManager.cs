using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class RegionManager : MonoBehaviour
{
    public List<Region> Regions { get; private set; }

    public RegionManager()
    {
        Regions = new List<Region>()
        {
            new Region("Swamp", "Witchbrew", 1.2),
            new Region("Coast", "Barnacleshell Coast", 0.9),
            new Region("City", "Deadspell Crag", 1.3),
            new Region("Mountain", "Far Peaks", 0.7),
            new Region("Desert", "Sandwave Dunes", 0.8),
            new Region("Volcano", "Searing Isles", 1.1),
            new Region("Haunted", "Spookster's Empire", 1.0),
        };
    }

    public Region GetRegion(string internalName)
    {
        return Regions.FirstOrDefault(u => u.InternalName == internalName);
    }

    void PopularityTick()
    {
        foreach (var region in Regions)
        {
            region.GameUpdateTick();
        }
    }
}
