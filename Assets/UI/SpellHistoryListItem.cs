using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpellHistoryListItem : MonoBehaviour
{
    Spell currentSpell;

    void Start()
    {

    }

    public void Init(Spell spell)
    {
        this.currentSpell = spell;

        UpdateText();
    }

    // text: <rank> <name> <infamy> <newness> <change in pop> eg. 104 Player's Sub-par Spell 0 2% [dec]
    public void UpdateText()
    {
        if (currentSpell == null) return;

        bool popIncreasing = true; // currentSpell.PopularityIncreasing;

        string changeInPop = popIncreasing ? "inc" : "dec";

        string displayString = System.String.Format("{0} {1}", currentSpell.Name, (int)currentSpell.TotalInfamy);

        GetComponent<Text>().text = displayString;
    }
}
