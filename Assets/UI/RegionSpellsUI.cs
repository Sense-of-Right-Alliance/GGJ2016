using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
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
    void Awake()
    {
        for (int i = spellList.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(spellList.transform.GetChild(i).gameObject);
        }

        if (!gameManager)
            gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    public void Init(Region region)
    {
        currentRegion = region;
        RefreshSpellList();
    }

    public void UpdateSpells()
    {
        RefreshSpellList();
    }

    public void RefreshSpellList()
    {
        ClearSpellListItems();

        List<RegionalSpell> topSpells = currentRegion.TopSpells;

        GameObject listItem;
        for (int i = 0; i < topSpells.Count; i++)
        {
            listItem = GetListItem();
            listItem.transform.SetParent(spellList.transform, false);
            listItem.GetComponent<RegionSpellListItem>().Init(i+1, topSpells[i]);

            if (gameManager.PlayerWizard == null) continue;

            // Color the text
            if (topSpells[i].Spell.Id == gameManager.PlayerWizard.CurrentSpell.Id)
            {
                listItem.GetComponent<Text>().color = Color.green;

            }
            else if (gameManager.PlayerWizard.PastSpells.Any(s => s.Id == topSpells[i].Spell.Id))
            {
                listItem.GetComponent<Text>().color = Color.yellow;
            }
            else
            {
                listItem.GetComponent<Text>().color = Color.white;
            }

            
        }
    }

    public void ClearSpellListItems()
    {
        for (int i = 0; i < listItems.Count; i++)
        {
            listItems[i].transform.SetParent(null);
            listItems[i].gameObject.SetActive(false);
        }
    }

    GameObject GetListItem()
    {
        for (int i = 0; i < listItems.Count; i++)
        {
            if (listItems[i].gameObject.activeSelf == false)
            {
                listItems[i].gameObject.SetActive(true);
                return listItems[i];
            }
        }
        
        GameObject listItem = (GameObject)Instantiate(regionSpellListItem, Vector3.zero, Quaternion.identity);
        listItems.Add(listItem);
        return listItem;
    }
}
