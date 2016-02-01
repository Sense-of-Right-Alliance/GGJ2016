using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RegionSpellListItem : MonoBehaviour
{
    RegionalSpell currentSpell;
    int rank = -1;

    void Start()
    {
    }

    public void Init(int rank, RegionalSpell spell)
    {
        this.rank = rank;
        this.currentSpell = spell;

        UpdateText();
    }

    // text: <rank> <name> <infamy> <newness> <change in pop> eg. 104 Player's Sub-par Spell 0 2% [dec]
    public void UpdateText()
    {
        if (currentSpell == null) return;

        bool popIncreasing = true; // currentSpell.PopularityIncreasing;

        string changeInPop = popIncreasing ? "inc" : "dec";

        string displayString = System.String.Format("{0} {1} {2} {3}% [{4}]", rank, currentSpell.Spell.Name, currentSpell.Infamy, currentSpell.Newness, changeInPop);

        GetComponent<Text>().text = displayString;
    }
}
