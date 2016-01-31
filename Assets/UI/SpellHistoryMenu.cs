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

    void Start()
    {
        if (!gameManager)
            gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    public void UpdateSpellList()
    {
        
        ClearSpellListItems();

        List<Spell> spells = gameManager.allSpells;

        GameObject listItem;
        for (int i = 0; i < spells.Count; i++)
        {
            listItem = (GameObject)Instantiate(spellListItem, Vector3.zero, Quaternion.identity);
            listItem.transform.SetParent(spellList.transform, false);
            listItem.GetComponent<Text>().text = spells[i].Name;
        }

        //LayoutRebuilder.MarkLayoutForRebuild((RectTransform)spellList.transform);
    }

    public void ClearSpellListItems()
    {
        for (int i = spellList.transform.childCount-1; i >= 0; i--)
        {
            Destroy(spellList.transform.GetChild(i).gameObject);
        }
    }
}
