using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RegionDetailsMenu : MonoBehaviour
{
    public Text nameText;
    public RegionSpellsUI regionSpellsUI;
    public RegionManager regionManager;
    public GameObject playerSpellStatus;
    public GameManager gameManager;

    Region currentRegion;
    public Region CurrentRegion
    {
        get { return currentRegion; }
    }

    MapNode currentNode;
    public MapNode CurrentNode
    {
        get { return currentNode; }
    }

    void Start()
    {
        gameObject.SetActive(false);

        playerSpellStatus.GetComponent<Text>().text = "";

        if (!nameText)
            nameText = transform.FindChild("Name").GetComponent<Text>();

        if (!regionSpellsUI)
            regionSpellsUI = transform.FindChild("Region Spells").GetComponent<RegionSpellsUI>();

        if (!regionManager)
            regionManager = GameObject.FindObjectOfType<RegionManager>();

        if (!gameManager)
            gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    public string Region
    {
        get { return currentRegion.InternalName; }
    }

    public void Init(MapNode node)
    {
        this.currentNode = node;
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

        if (gameManager.PlayerWizard.CurrentSpell.RegionalSpells.ContainsKey(currentRegion))
        {
            RegionalSpell spell = gameManager.PlayerWizard.CurrentSpell.RegionalSpells[currentRegion];
            playerSpellStatus.GetComponent<RegionSpellListItem>().Init(currentRegion.TopSpells.IndexOf(spell), spell);
        }
        else
        {
            playerSpellStatus.GetComponent<Text>().text = "Spell Not Introduced";
        }

        regionSpellsUI.UpdateSpells();
    }
}
