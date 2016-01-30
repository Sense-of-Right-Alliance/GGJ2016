using UnityEngine;
using System.Collections;

public class Spell
{
    public string Name
    {
        get { return string.Format("{0}'s {1} {2}", wizardName, spellAdjective.Name, spellObject.Name);  }
    }

    string wizardName;
    SpellDescriptor spellAdjective;
    SpellObject spellObject;

    public Spell(string wizardName, SpellDescriptor adjective, SpellObject obj)
    {
        this.wizardName = wizardName;
        this.spellAdjective = adjective;
        this.spellObject = obj;
    }

    public static Spell GenerateRandomSpell(string wizardName)
    {
        SpellDescriptor adj = new SpellDescriptor("Funny");
        SpellObject obj = new SpellObject("Rock");

        Spell s = new Spell(wizardName, adj, obj);

        return s;
    }
}
