using UnityEngine;
using System.Collections;

public class SpellObject
{
    public string Name { get; private set; }

    public SpellObject(string name)
    {
        this.Name = name;
    }
}
