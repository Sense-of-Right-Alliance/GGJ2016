using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class RegionalSpell
{
    public Spell Spell { get; private set; }
    public Region Region { get; private set; }

    public RegionalSpell(Spell spell, Region region)
    {
        this.Spell = spell;
        this.Region = region;
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

    //double GetWizardPopularityModifier()
    //{
    //    var rand = new System.Random(Spell.Wizard.Name.GetHashCode());
    //    return rand.NextDouble();
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
