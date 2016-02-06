using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public RegionDetailsMenu regionDetailsMenu;
    public WizardDetailsUI wizardDetailsUI;
    public WizardDetailsUI wizardDetailsUISmall;
    public GameOverUI gameOverUI;
    public MapNode[] mapNodes;

    public GameManager gameManager;

	// Use this for initialization
	void Start () {
        if (!gameManager)
            gameManager = GameObject.FindObjectOfType<GameManager>();

        wizardDetailsUI.gameObject.SetActive(true);
        wizardDetailsUISmall.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void UpdateUI()
    {
        regionDetailsMenu.UpdateUI();
        wizardDetailsUI.UpdateUI();
        wizardDetailsUISmall.UpdateUI();

        for (int i = 0; i < mapNodes.Length; i++)
        {
            mapNodes[i].UpdateUI();
        }
    }

    void OnGameOver()
    {
        gameOverUI.Init();
    }

    public void ToggleWizardDetailView()
    {
        if (wizardDetailsUI.gameObject.activeSelf)
        {
            wizardDetailsUI.gameObject.SetActive(false);
            wizardDetailsUISmall.gameObject.SetActive(true);
        }
        else
        {
            wizardDetailsUI.gameObject.SetActive(true);
            wizardDetailsUISmall.gameObject.SetActive(false);
        }
    }
}
