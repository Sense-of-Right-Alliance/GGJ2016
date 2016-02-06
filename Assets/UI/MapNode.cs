using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapNode : MonoBehaviour
{
    public string InternalName;

    public Text statusText;

    private Region region;
    private GameManager gameManager;
    private RegionManager regionManager;

    void Start()
    {
        if (!statusText)
            statusText = GetComponentInChildren<Text>();

        if (!gameManager)
            gameManager = GameObject.FindObjectOfType<GameManager>();

        if (!regionManager)
            regionManager = GameObject.FindObjectOfType<RegionManager>();
    }

    public void UpdateUI()
    {
        if (region == null) region = regionManager.GetRegion(InternalName);

        if (gameManager.PlayerWizard == null) return;

        if (gameManager.PlayerWizard.CurrentSpell.RegionalSpells.ContainsKey(region))
        {
            RegionalSpell rSpell = gameManager.PlayerWizard.CurrentSpell.RegionalSpells[region];

            int rank = region.TopSpells.IndexOf(rSpell);
            bool popIncreasing = rSpell.PopularityIncreasing;

            string changeInPop = popIncreasing ? "▲" : "▼";

            string rankString = rank == -1 ? "---" : System.String.Format("{0:d3}", rank);

            string displayString = System.String.Format("{0} [{1:d3}] {2:f0}% {3}", rankString, (int)(rSpell.Rating * 10), rSpell.Exposure * 100, changeInPop);

            statusText.text = displayString;
        }
        else
        {
            statusText.text = "";
        }
    }
}
