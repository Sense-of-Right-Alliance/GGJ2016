using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class WizardManager : MonoBehaviour
{
    public Dictionary<int, Wizard> Wizards { get; private set; }

    int nextWizardId = 0;

    public WizardManager()
    {
        Wizards = new Dictionary<int, Wizard>();
    }

    public Wizard GenerateWizard(string name)
    {
        var wiz = new Wizard(nextWizardId++, name);
        Wizards.Add(wiz.Id, wiz);
        return wiz;
    }

    void PopularityTick()
    {
        //Debug.Log("Updating Wizards (Age)");

        // todo: update all the ACTIVE wizards ages.
    }
}
