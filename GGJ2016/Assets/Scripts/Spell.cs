using UnityEngine;
using System.Collections;

public class Spell
{
    public string Name
    {
        get { return string.Format("{0}'s {1} {2}", wizardName, spellAdjective.Name, spellObject.Name);  }
    }

    string wizardName;
    SpellAdjective spellAdjective;
    SpellObject spellObject;

    public Spell(string wizardName, SpellAdjective adjective, SpellObject obj)
    {
        this.wizardName = wizardName;
        this.spellAdjective = adjective;
        this.spellObject = obj;
    }

    public static Spell GenerateRandomSpell(string wizardName)
    {
        SpellAdjective adj = new SpellAdjective() { Name = "Funny" };
        SpellObject obj = new SpellObject() { Name = "Rock" };

        Spell s = new Spell(wizardName, adj, obj);

        return s;
    }
}
