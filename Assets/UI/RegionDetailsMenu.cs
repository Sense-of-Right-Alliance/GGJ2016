using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RegionDetailsMenu : MonoBehaviour
{

    string region = "Mountain";
    public Text nameText;
    public RegionSpellsUI regionSpellsUI;

    void Start()
    {
        gameObject.SetActive(false);

        if (!nameText)
            nameText = transform.FindChild("Name").GetComponent<Text>();

        if (!regionSpellsUI)
            regionSpellsUI = transform.FindChild("Region Spells").GetComponent<RegionSpellsUI>();
    }

    public string Region
    {
        get { return region; }
    }

    public void Init(string region)
    {
        this.region = region;

        nameText.text = region;

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void UpdateUI()
    {
        regionSpellsUI.UpdateSpells();
    }
}
