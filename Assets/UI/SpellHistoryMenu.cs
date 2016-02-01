using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SpellHistoryMenu : MonoBehaviour
{
    public GameObject spellListItem;

    public ScrollRect scrollRect;
    public GameObject spellList;
    public GameManager gameManager;

    void Awake()
    {
        if (!gameManager)
            gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    public void UpdateUI()
    {
        RefreshSpellList();
    }

    public void RefreshSpellList()
    {
        ClearSpellListItems();

        AddSpellListItem(gameManager.PlayerWizard.CurrentSpell);

        List<Spell> spells = gameManager.PlayerWizard.PastSpells;
        for (int i = 0; i < spells.Count; i++)
        {
            AddSpellListItem(spells[i]);
        }
    }

    void AddSpellListItem(Spell spell)
    {
        GameObject listItem;
        
        listItem = (GameObject)Instantiate(spellListItem, Vector3.zero, Quaternion.identity);
        listItem.transform.SetParent(spellList.transform, false);
        listItem.GetComponent<SpellHistoryListItem>().Init(spell);

        if (spell.Id == gameManager.PlayerWizard.CurrentSpell.Id)
        {
            listItem.GetComponent<Text>().color = Color.green;
        }
        else if (spell.Id == gameManager.PlayerWizard.CurrentSpell.Id)
        {
            listItem.GetComponent<Text>().color = Color.yellow;
        }
    }

    public void ClearSpellListItems()
    {
        for (int i = spellList.transform.childCount-1; i >= 0; i--)
        {
            Destroy(spellList.transform.GetChild(i).gameObject);
        }
    }
}
