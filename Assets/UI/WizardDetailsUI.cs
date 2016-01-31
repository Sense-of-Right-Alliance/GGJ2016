using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WizardDetailsUI : MonoBehaviour
{
    public Text ageText;
    public Text notorietyText;
    public SpellHistoryMenu spellHistoryMenu;

    public GameManager gameManager;

    void Start()
    {
        if (!gameManager)
            gameManager = GameObject.FindObjectOfType<GameManager>();

        if (!spellHistoryMenu)
            spellHistoryMenu = GameObject.FindObjectOfType<SpellHistoryMenu>();
    }

    public void UpdateUI()
    {
        Wizard playerWizard = gameManager.PlayerWizard;

        if (playerWizard == null) return;

        ageText.text = "Age: " + playerWizard.Age + " years wiser";
        notorietyText.text = "Notoriety: " + playerWizard.Notoriety + "";

        spellHistoryMenu.UpdateUI();
    }
}
