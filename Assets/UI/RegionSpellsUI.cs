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

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateSpells()
    {
        for (int i = 0; i < listItems.Count; i++)
        {
            listItems[i].GetComponent<RegionSpellListItem>().UpdateSpell();
        }
    }

    public void RefreshSpellList()
    {
        ClearSpellListItems();

        List<Spell> spells = gameManager.allSpells;

        GameObject listItem;
        for (int i = 0; i < spells.Count; i++)
        {
            listItem = (GameObject)Instantiate(regionSpellListItem, Vector3.zero, Quaternion.identity);
            listItem.transform.SetParent(spellList.transform, false);
            listItem.GetComponent<Text>().text = spells[i].Name;

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
