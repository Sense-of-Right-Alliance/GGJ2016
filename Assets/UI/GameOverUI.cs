using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverUI : MonoBehaviour
{
    public GameManager gameManager;

    public Text captionText;

    // Use this for initialization
    void Start () {
        if (!gameManager)
            gameManager = GameObject.FindObjectOfType<GameManager>();

        if (!captionText)
            captionText = transform.FindChild("Caption").GetComponent<Text>();

        gameObject.SetActive(false);
	}

    public void Init()
    {
        gameObject.SetActive(true);

        Wizard playerWizard = gameManager.PlayerWizard;

        captionText.text = "Your frail wizard body has expired, but will " + playerWizard.PosessiveName + " wizarding legacy live on?";
    }
}
