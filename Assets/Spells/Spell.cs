using UnityEngine;
using System.Collections;

public class Spell
{
    public string Name
    {
        get { return string.Format("{0}'s {1} {2}", wizardName, Descriptor.Name, Object.Name);  }
    }

    public SpellObject Object { get; private set; }

    public SpellDescriptor Descriptor { get; private set; }

    string wizardName;

    public Spell(string wizardName, SpellDescriptor descriptor, SpellObject obj)
    {
        this.wizardName = wizardName;
        this.Descriptor = descriptor;
        this.Object = obj;
    }
}
