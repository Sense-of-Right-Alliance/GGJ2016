using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class Spell
{
    public string Name
    {
        get { return string.Format("{0} {1} {2}", Wizard.PosessiveName, Descriptor.Name, Object.Name);  }
    }

    public Wizard Wizard { get; private set; }

    public SpellObject Object { get; private set; }

    public SpellDescriptor Descriptor { get; private set; }

    public Spell(Wizard wizard, SpellDescriptor descriptor, SpellObject obj)
    {
        this.Wizard = wizard;
        this.Descriptor = descriptor;
        this.Object = obj;
    }
}
