using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverUI : MonoBehaviour
{
    public GameManager gameManager;

    public Text captionText;
    public WizardDetailsUI wizardDetailsUI;

    // Use this for initialization
    void Start () {
        gameObject.SetActive(false);
	}

    public void Init()
    {
        Debug.Log(" Initing game over!");

        gameObject.SetActive(true);

        if (!gameManager)
            gameManager = GameObject.FindObjectOfType<GameManager>();

        if (!captionText)
            captionText = transform.FindChild("Caption").GetComponent<Text>();

        Wizard playerWizard = gameManager.PlayerWizard;

        captionText.text = "Your frail wizard body has expired, but will " + playerWizard.PosessiveName + " wizarding legacy live on?";

        if (wizardDetailsUI != null)
            wizardDetailsUI.UpdateUI();
    }
}
