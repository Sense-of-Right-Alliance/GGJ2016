using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WizardDetailsUI : MonoBehaviour
{
    public Text ageText;
    public Text notorietyText;
    public SpellHistoryMenu spellHistoryMenu;

    public GameManager gameManager;

    public bool reduced = false;

    void Start()
    {
    }

    public void UpdateUI()
    {
        if (!gameManager)
            gameManager = GameObject.FindObjectOfType<GameManager>();

        Wizard playerWizard = gameManager.PlayerWizard;

        if (playerWizard == null) return;

        if (!reduced)
        {
            if (spellHistoryMenu.gameObject.activeSelf) spellHistoryMenu.UpdateUI();

            ageText.text = "Age: " + playerWizard.Age + " years wiser";
            notorietyText.text = "Notoriety: " + (int)playerWizard.Notoriety + "";
        }
        else
        {
            ageText.text = ""+playerWizard.Age;
            notorietyText.text = ""+playerWizard.Notoriety;
        }

        

        
    }
}
