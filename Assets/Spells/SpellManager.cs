using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public IEnumerable<SpellDescriptor> SpellDescriptors { get; private set; }
    public IEnumerable<SpellObject> SpellObjects { get; private set; }

    int nextId = 0;

    public SpellManager()
    {
        SpellDescriptors = SpellParser.FetchDescriptors();
        SpellObjects = SpellParser.FetchObjects();
    }

    public Spell GenerateRandomSpell(Wizard wizard)
    {
        var rand = new System.Random(nextId);
        var descriptor = SpellDescriptors.ElementAt(rand.Next(SpellDescriptors.Count()));
        var obj = SpellObjects.ElementAt(rand.Next(SpellObjects.Count()));

        return new Spell(nextId++, wizard, descriptor, obj);
    }
}
