using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Region
{
    public string InternalName { get; private set; }
    public string DisplayedName { get; private set; }

    public Region(string internalName, string displayedName)
    {
        this.InternalName = internalName;
        this.DisplayedName = displayedName;
    }

    public Region(string name) : this(name, name) { }

    public double GetOpinion(SpellDescriptor descriptor)
    {
        return descriptor.GetOpinion(this);
    }

    public double GetOpinion(SpellObject obj)
    {
        return obj.GetOpinion(this);
    }
}
