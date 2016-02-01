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

        bool popIncreasing = currentSpell.PopularityIncreasing;

        string changeInPop = popIncreasing ? "▲" : "▼";

        string displayString = System.String.Format("{0:d3} [{1:d3}] {2} {3:f0}% {4}", rank, (int)(currentSpell.Rating * 10), currentSpell.Spell.Name, currentSpell.Exposure * 100, changeInPop);

        GetComponent<Text>().text = displayString;
    }
}
