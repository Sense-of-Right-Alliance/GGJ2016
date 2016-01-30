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
            new Region("Swamp"),
            new Region("Coast"),
            new Region("City"),
            new Region("Mountain"),
            new Region("Desert"),
            new Region("Volcano"),
            new Region("Haunted"),
        };
    }
}
