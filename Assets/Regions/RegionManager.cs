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
            new Region("Swamp", "Witchbrew"),
            new Region("Coast", "Barnacleshell Coast"),
            new Region("City", "Deadspell Crag"),
            new Region("Mountain", "Far Peaks"),
            new Region("Desert", "Sandwave Dunes"),
            new Region("Volcano", "Searing Isles"),
            new Region("Haunted", "Spookster's Empire"),
        };
    }
}
