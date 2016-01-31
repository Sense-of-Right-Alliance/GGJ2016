using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RegionSpellListItem : MonoBehaviour
{
    RegionalSpell currentSpell;
    Text textObj;

    double previousPopularity;

    public void Init(RegionalSpell spell)
    {
        this.currentSpell = spell;

        previousPopularity = spell.Popularity;

        UpdateText();
    }

    // text: <rank> <name> <infamy> <newness> <change in pop> eg. 104 Player's Sub-par Spell 0 2% [dec]
    public void UpdateText()
    {
        if (currentSpell == null || textObj == null) return;

        string changeInPop = "steady";
        if (currentSpell.Popularity > previousPopularity)
            changeInPop = "inc";
        else if (currentSpell.Popularity < previousPopularity)
            changeInPop = "dec";

        textObj.text = System.String.Format("{0} {1} {2} {3} {4}% [{5}]", "order", currentSpell.Spell.Name, currentSpell.Infamy, currentSpell.Newness, changeInPop);
    }
}
