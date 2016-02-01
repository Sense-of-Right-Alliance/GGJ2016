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

    System.Random random;

    public SpellManager()
    {
        SpellDescriptors = SpellParser.FetchDescriptors();
        SpellObjects = SpellParser.FetchObjects();

        random = new System.Random();
    }

    public Spell GenerateRandomSpell(Wizard wizard)
    {
        var descriptor = SpellDescriptors.ElementAt(random.Next(SpellDescriptors.Count()));
        var obj = SpellObjects.ElementAt(random.Next(SpellObjects.Count()));

        return new Spell(nextId++, wizard, descriptor, obj);
    }
}
