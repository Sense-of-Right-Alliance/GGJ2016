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
    public List<RegionalSpell> TopSpells { get { return AllSpells.Values.OrderByDescending(u => u.Rating).Take(100).ToList(); } }
    public List<Region> Neighbours { get; private set; }

    public Region(string internalName, string displayedName, double adventurousness)
    {
        this.InternalName = internalName;
        this.DisplayedName = displayedName;
        this.Adventurousness = adventurousness;

        AllSpells = new Dictionary<int, RegionalSpell>();
        VisitingWizards = new List<Wizard>();
        Neighbours = new List<Region>();
    }

    public void AddNeighbours(IEnumerable<Region> neighbours)
    {
        Neighbours.AddRange(neighbours);
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

        var topList = TopSpells;
        for (int i = 0; i < topList.Count; i++)
        {
            topList[i].Infamy += (double)(topList.Count - i) / 1000.0;
        }
    }

    public void AddWizard(Wizard wizard)
    {
        if (wizard.CurrentSpell != null && !AllSpells.ContainsKey(wizard.CurrentSpell.Id))
        {
            IntroduceSpell(wizard.CurrentSpell);
        }
        VisitingWizards.Add(wizard);
    }

    public void RemoveWizard(Wizard wizard)
    {
        VisitingWizards.Remove(wizard);
    }
}
