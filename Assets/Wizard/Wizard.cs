using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class Wizard
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string PosessiveName
    {
        get
        {
            if (Name.Last() == 's')
                return Name + "'";
            else
                return Name + "'s";
        }
    }

    const double MINIMUM_AGE = 100;
    double age = 50;
    public int Age
    {
        get { return (int)Math.Floor(age); }
    }

    public bool Alive { get; private set; }
    
    public int Notoriety
    {
        get
        {
            return (int)(PastSpells.Sum(s => s.TotalInfamy) + CurrentSpell.TotalInfamy);
        }
    }

    public List<Spell> PastSpells = new List<Spell>();

    Spell currentSpell = null;
    public Spell CurrentSpell
    {
        get
        {
            return currentSpell;
        }
        set
        {
            if (currentSpell != null)
                PastSpells.Add(currentSpell);

            currentSpell = value;
        }
    }

    public Wizard(int id, string name)
    {
        this.Id = id;
        this.Name = name;
        this.Alive = true;
    }

    public void IncreaseAge(float time)
    {
        if (Alive)
        {
            age += time;
            if (age > MINIMUM_AGE)
            {
                double deathChance = (age - MINIMUM_AGE) / 200.0;
                if (Utility.Random(Name) < deathChance)
                    Alive = false;
            }
        }
    }
}
