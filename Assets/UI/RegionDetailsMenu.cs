using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RegionDetailsMenu : MonoBehaviour
{
    public Text nameText;
    public RegionSpellsUI regionSpellsUI;
    public RegionManager regionManager;

    Region currentRegion;
    public Region CurrentRegion
    {
        get { return currentRegion; }
    }

    void Start()
    {
        gameObject.SetActive(false);

        if (!nameText)
            nameText = transform.FindChild("Name").GetComponent<Text>();

        if (!regionSpellsUI)
            regionSpellsUI = transform.FindChild("Region Spells").GetComponent<RegionSpellsUI>();

        if (!regionManager)
            regionManager = GameObject.FindObjectOfType<RegionManager>();
    }

    public string Region
    {
        get { return currentRegion.InternalName; }
    }

    public void Init(MapNode node)
    {
        currentRegion = regionManager.GetRegion(node.InternalName);

        nameText.text = currentRegion.DisplayedName;

        regionSpellsUI.Init(currentRegion);

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void UpdateUI()
    {
        if (currentRegion == null) return; 

        regionSpellsUI.UpdateSpells();
    }
}
