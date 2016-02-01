using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class RegionManager : MonoBehaviour
{
    public List<Region> Regions { get; private set; }

    SpellManager spellManager;
    WizardManager wizardManager;

    System.Random random;

    public RegionManager()
    {
        Regions = new List<Region>()
        {
            new Region("Swamp", "Witchbrew", 1.2),
            new Region("Coast", "Barnacleshell Coast", 0.9),
            new Region("City", "Deadspell Crag", 1.3),
            new Region("Mountain", "Far Peaks", 0.7),
            new Region("Desert", "Sandwave Dunes", 0.8),
            new Region("Volcano", "Searing Isles", 1.1),
            new Region("Haunted", "Spookster's Empire", 1.0),
        };

        GetRegion("Swamp").AddNeighbours(new List<Region>()
        {
            GetRegion("Coast"),
            GetRegion("Desert"),
        });

        GetRegion("Desert").AddNeighbours(new List<Region>()
        {
            GetRegion("Coast"),
            GetRegion("Swamp"),
            GetRegion("City"),
        });

        GetRegion("Coast").AddNeighbours(new List<Region>()
        {
            GetRegion("Swamp"),
            GetRegion("Desert"),
            GetRegion("City"),
        });

        GetRegion("City").AddNeighbours(new List<Region>()
        {
            GetRegion("Coast"),
            GetRegion("Desert"),
        });

        GetRegion("Haunted").AddNeighbours(new List<Region>()
        {
            GetRegion("Mountain"),
        });

        GetRegion("Mountain").AddNeighbours(new List<Region>()
        {
            GetRegion("Haunted"),
        });

        random = new System.Random();
    }

    public void Awake()
    {
        spellManager = GetComponent<SpellManager>();
        wizardManager = GetComponent<WizardManager>();
    }

    public Region GetRegion(string internalName)
    {
        return Regions.FirstOrDefault(u => u.InternalName == internalName);
    }

    public void AddRandomSpellsToAllRegions()
    {
        var wizards = wizardManager.GenerateRandomWizards(80);
        var spells = new List<Spell>();

        foreach (var wizard in wizards)
        {
            for (int i = 0; i < random.Next(3,12); i++)
            {
                GenerateSpellsForWizard(wizard, spells);
            }
        }

        foreach (var region in Regions)
        {
            var regionSpells = spells.OrderBy(s => random.Next()).Take(100);
            foreach (var spell in regionSpells)
            {
                int ticks = random.Next(0, 3000);
                double infamy = (double)ticks * random.NextDouble() / 2000;
                region.IntroduceSpell(spell, ticks, infamy);
            }
        }
    }

    void GenerateSpellsForWizard(Wizard wizard, List<Spell> spells)
    {
        var spell = spellManager.GenerateRandomSpell(wizard);
        wizard.CurrentSpell = spell;
        spells.Add(spell);
    }

    void PopularityTick()
    {
        foreach (var region in Regions)
        {
            region.GameUpdateTick();
        }
    }
}
