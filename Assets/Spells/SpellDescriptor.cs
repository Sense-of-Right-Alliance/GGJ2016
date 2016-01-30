using UnityEngine;
using System.Collections;

public class SpellDescriptor
{
    public string Name { get; private set; }

    public SpellDescriptor(string name)
    {
        this.Name = name;
    }
}
