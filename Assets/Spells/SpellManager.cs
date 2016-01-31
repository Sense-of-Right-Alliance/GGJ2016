using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public IEnumerable<SpellDescriptor> SpellDescriptors { get; private set; }
    public IEnumerable<SpellObject> SpellObjects { get; private set; }

    RegionManager regionManager;

    public SpellManager()
    {
        SpellDescriptors = SpellParser.FetchDescriptors();
        SpellObjects = SpellParser.FetchObjects();
    }

    public void Awake()
    {
        regionManager = GetComponent<RegionManager>();
    }

    public Spell GenerateRandomSpell(string wizardName)
    {
        var rand = new System.Random();
        var descriptor = SpellDescriptors.ElementAt(rand.Next(SpellDescriptors.Count()));
        var obj = SpellObjects.ElementAt(rand.Next(SpellObjects.Count()));

        return new Spell(wizardName, descriptor, obj);
    }
}
