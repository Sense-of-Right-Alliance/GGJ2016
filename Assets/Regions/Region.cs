using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Region
{
    public string InternalName { get; private set; }
    public string DisplayedName { get; private set; }
    public double Adventurousness { get; private set; }
    public List<Wizard> VisitingWizards { get; private set; }

    public Dictionary<int, RegionalSpell> AllSpells { get; private set; }
    public IEnumerable<RegionalSpell> TopSpells { get { return AllSpells.Values.OrderByDescending(u => u.Rating).Take(100); } }

    public Region(string internalName, string displayedName, double adventurousness)
    {
        this.InternalName = internalName;
        this.DisplayedName = displayedName;
        this.Adventurousness = adventurousness;

        AllSpells = new Dictionary<int, RegionalSpell>();
        VisitingWizards = new List<Wizard>();
    }

    public double GetOpinion(SpellDescriptor descriptor)
    {
        return descriptor.GetOpinion(this);
    }

    public double GetOpinion(SpellObject obj)
    {
        return obj.GetOpinion(this);
    }

    public void IntroduceSpell(Spell spell, int ticks = 0, double infamy = 0)
    {
        var regionalSpell = new RegionalSpell(spell, this, ticks, infamy);
        AllSpells.Add(spell.Id, regionalSpell);
    }

    public void GameUpdateTick()
    {
        foreach (var spell in AllSpells.Values)
        {
            spell.GameUpdateTick(VisitingWizards);
        }
    }
}
