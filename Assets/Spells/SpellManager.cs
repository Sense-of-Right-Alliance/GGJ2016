using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public List<SpellDescriptor> SpellDescriptors { get; private set; }
    public List<SpellObject> SpellObjects { get; private set; }

    RegionManager regionManager;

    public SpellManager()
    {
        SpellDescriptors = new List<SpellDescriptor>()
        {
            new SpellDescriptor("Flaming"),
            new SpellDescriptor("Slimey"),
            new SpellDescriptor("Damp"),
            new SpellDescriptor("Shocking"),
            new SpellDescriptor("Fanciful"),
            new SpellDescriptor("Glowing"),
            new SpellDescriptor("Old"),
            new SpellDescriptor("Frightening"),
            new SpellDescriptor("Terrible"),
            new SpellDescriptor("Foul"),
            new SpellDescriptor("Blinding"),
            new SpellDescriptor("Deafening"),
            new SpellDescriptor("Heavy"),
            new SpellDescriptor("Dazzling"),
            new SpellDescriptor("Lustful"),
        };

        SpellObjects = new List<SpellObject>()
        {
            new SpellObject("Feet"),
            new SpellObject("Rock"),
            new SpellObject("Ball"),
            new SpellObject("Eye"),
            new SpellObject("Pinkie"),
            new SpellObject("Butt"),
            new SpellObject("Wheels"),
            new SpellObject("Box"),
            new SpellObject("Feast"),
            new SpellObject("Skull"),
            new SpellObject("Blade"),
            new SpellObject("Feast"),
            new SpellObject("Spike"),
            new SpellObject("Tools"),
            new SpellObject("Ward"),
        };
    }

    public void Awake()
    {
        regionManager = GetComponent<RegionManager>();
    }
}
