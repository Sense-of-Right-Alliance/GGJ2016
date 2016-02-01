using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class RegionalSpell
{
    public Spell Spell { get; private set; }
    public Region Region { get; private set; }

    double popularityModifier = 0.1;
    public double Exposure { get; private set; }
    public double Popularity { get { return Newness * Exposure; } }

    double previousPopularity = 0;
    public bool PopularityIncreasing { get; private set; }
    
    public double ObjectOpinion { get { return Region.GetOpinion(Spell.Object); } }
    public double DescriptorOpinion { get { return Region.GetOpinion(Spell.Descriptor); } }

    double objOpinionModifier = 1.0;
    double descOpinionModifier = 1.0;
    public double Worth { get { return ObjectOpinion * objOpinionModifier + DescriptorOpinion * descOpinionModifier; } }

    public double WizardReaction { get; private set; }

    double infamyModifier = 1.0;
    public double Infamy { get; private set; }

    public double Rating
    {
        get
        {
            return (Worth * WizardReaction) + (Popularity * popularityModifier * Region.Adventurousness) + (Infamy * infamyModifier);
        }
    }

    int ticks = 0;
    public double Newness
    {
        get
        {
            if (ticks < 300) return 90;
            return 240.0 / (double)ticks;
        }
    }

    System.Random random;

    public RegionalSpell(Spell spell, Region region, int ticks, double infamy)
    {
        this.Spell = spell;
        spell.RegionalSpells[region] = this;

        this.Region = region;
        this.ticks = ticks;
        this.Infamy = infamy;

        random = Utility.GetRandom(Spell.Wizard.Name, Region.InternalName);
        WizardReaction = random.NextDouble().Between(0.75, 1.25);

        double exposureAmount = (double)ticks * random.NextDouble() / 600.0;
        Exposure = exposureAmount > 1.0 ? 1.0 : (exposureAmount < 0.0 ? 0.01 : exposureAmount);

        PopularityIncreasing = true;
    }

    public void GameUpdateTick(IEnumerable<Wizard> wizards)
    {
        ticks += 1;

        // increase exposure if wizard is marketing
        if (Exposure < 1.0 && wizards.Any(w => w.CurrentSpell == Spell))
        {
            if (Exposure + 0.002 > 1.0)
            {
                Exposure = 1.0;
            }
            else
            { 
                Exposure += 0.002;
            }
        }

        // increase exposure
        if (Exposure < 1.0 && Exposure > 0.0)
        {
            double amount = random.NextDouble();

            if (amount < Exposure)
            {
                if (Exposure + 0.01 > 1.0)
                {
                    Exposure = 1.0;
                }
                else
                {
                    Exposure += 0.01;
                }

                // increase exposure in neighbouring regions
                foreach (var neighbour in Region.Neighbours)
                {
                    if (!neighbour.AllSpells.ContainsKey(Spell.Id))
                    {
                        neighbour.IntroduceSpell(Spell);
                    }

                    if (neighbour.AllSpells[Spell.Id].Exposure + 0.005 > 1.0)
                    {
                        neighbour.AllSpells[Spell.Id].Exposure = 1.0;
                    }
                    else
                    {
                        neighbour.AllSpells[Spell.Id].Exposure += 0.005;
                    }
                }
            }
        }

        double popDifference = Popularity - previousPopularity;
        if (Math.Abs(popDifference) > 0.1)
        {
            PopularityIncreasing = previousPopularity < Popularity;
            previousPopularity = Popularity;
        }
        else if (Exposure >= 1.0)
        {
            PopularityIncreasing = false;
        }
    }

    //static List<NewnessOpinion> newnessDecline = new List<NewnessOpinion>()
    //{
    //    new NewnessOpinion(0, 10),
    //    new NewnessOpinion(1, 8),
    //    new NewnessOpinion(5, 5),
    //    new NewnessOpinion(10, 3),
    //    new NewnessOpinion(50, 1),
    //    new NewnessOpinion(100, 0.75f),
    //    new NewnessOpinion(1000, 0.5f),
    //};

    //double GetNewness(double years)
    //{
    //    int numPopularityPoints = newnessDecline.Count();
    //    double lastYear = 0;
    //    double popularity = 0;

    //    bool foundPopularity = false;
    //    for (int i = 1; i < numPopularityPoints; i += 1)
    //    {
    //        if (newnessDecline[i].years > lastYear)
    //        {
    //            double range = newnessDecline[i].years = newnessDecline[i - 1].years;
    //            double progress = years - newnessDecline[i - 1].years;
    //            double percent = progress / range;

    //            double popularityRange = newnessDecline[i].popularity - newnessDecline[i - 1].popularity;
    //            double popularityProgress = percent * popularityRange;

    //            popularity = popularityProgress + newnessDecline[i - 1].popularity;
    //            foundPopularity = true;
    //            break;
    //        }
    //    }
    //    if (!foundPopularity)
    //    {
    //        popularity = newnessDecline[numPopularityPoints - 1].popularity;
    //    }

    //    return popularity;
    //}

    //class NewnessOpinion
    //{
    //    public double years;
    //    public double popularity;

    //    public NewnessOpinion(double years, double popularity)
    //    {
    //        this.years = years;
    //        this.popularity = popularity;
    //    }
    //}
}
