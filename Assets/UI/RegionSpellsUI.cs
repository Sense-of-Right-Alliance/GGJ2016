using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RegionSpellsUI : MonoBehaviour
{
    public GameObject regionSpellListItem;

    public ScrollRect scrollRect;
    public GameObject spellList;
    public GameManager gameManager;

    List<GameObject> listItems = new List<GameObject>();

    Region currentRegion;

    // Use this for initialization
    void Start () {
	
	}

    public void Init(Region region)
    {
        currentRegion = region;
        RefreshSpellList();
    }

    public void UpdateSpells()
    {
        RefreshSpellList();
        /*
        for (int i = 0; i < listItems.Count; i++)
        {
            listItems[i].GetComponent<RegionSpellListItem>().UpdateText();
        }
        */
    }

    public void RefreshSpellList()
    {
        ClearSpellListItems();

        List<RegionalSpell> topSpells = currentRegion.TopSpells;

        GameObject listItem;
        for (int i = 0; i < topSpells.Count; i++)
        {
            listItem = (GameObject)Instantiate(regionSpellListItem, Vector3.zero, Quaternion.identity);
            listItem.transform.SetParent(spellList.transform, false);
            listItem.GetComponent<RegionSpellListItem>().Init(i+1, topSpells[i]);

            listItems.Add(listItem);
        }
    }

    public void ClearSpellListItems()
    {
        for (int i = spellList.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(spellList.transform.GetChild(i).gameObject);
        }

        listItems.Clear();
    }
}
