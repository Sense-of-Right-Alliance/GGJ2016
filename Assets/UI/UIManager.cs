using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public RegionDetailsMenu regionDetailsMenu;
    public WizardDetailsUI wizardDetailsUI;
    public GameOverUI gameOverUI;

    public GameManager gameManager;

	// Use this for initialization
	void Start () {
        if (!gameManager)
            gameManager = GameObject.FindObjectOfType<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void UpdateUI()
    {
        regionDetailsMenu.UpdateUI();
        wizardDetailsUI.UpdateUI();
    }

    void OnGameOver()
    {
        gameOverUI.Init();
    }
}
