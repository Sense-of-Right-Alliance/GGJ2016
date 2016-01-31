using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class RegionalSpell
{
    public Spell Spell { get; private set; }
    public Region Region { get; private set; }

    public double Exposure { get; private set; }
    public double Popularity { get { return Newness * Exposure; } }
    
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
            return (Worth * WizardReaction) + (Popularity * Region.Adventurousness) + (Infamy * infamyModifier);
        }
    }

    int ticks = 0;
    public double Newness
    {
        get
        {
            int minute = (int)(60 * (1f / 0.2f)); // 0.2f = GameManager.POPULARITY_INTERVAL

            if (ticks < minute)
                return 8;
            else if (ticks < minute * 2)
                return 7;
            else if (ticks < minute * 3)
                return 5.5;
            else if (ticks < minute * 4)
                return 4;
            else if (ticks < minute * 5)
                return 2;
            else
                return 1500 / ticks;
        }
    }

    public RegionalSpell(Spell spell, Region region, int ticks, double infamy)
    {
        this.Spell = spell;
        this.Region = region;
        this.ticks = ticks;
        this.Infamy = infamy;

        var rand = Utility.GetRandom(Spell.Wizard.Name, Region.InternalName);
        WizardReaction = rand.NextDouble().Between(0.75, 1.25);
    }

    public void GameUpdateTick(IEnumerable<Wizard> wizards)
    {
        if (wizards.Any(w => w.CurrentSpell == Spell))
            Exposure += 0.002;

        // TODO: increase local exposure
        // TODO: increase exposure in neighbouring regions
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
