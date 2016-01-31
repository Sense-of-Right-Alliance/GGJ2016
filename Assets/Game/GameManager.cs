using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static float POPULARITY_INTERVAL = 0.2f;

    public InputField wizardNameField;

    public string wizardName;
    public Spell spell;

    public MenuManager menuManager;
    public SpellMenu spellMenu;

    SpellManager spellManager;
    WizardManager wizardManager;

    public void Start()
    {
        if (!menuManager)
            menuManager = GameObject.FindObjectOfType<MenuManager>();

        if (!spellMenu)
            spellMenu = GameObject.FindObjectOfType<SpellMenu>();

        spellManager = GetComponent<SpellManager>();
        wizardManager = GetComponent<WizardManager>();
    }

    public void MapNodeClicked(string region)
    {
        Debug.Log(region + " Clicked!");
    }

    public void ConfirmWizardNameClicked()
    {
        if (wizardNameField && wizardNameField.text != "")
        {
            wizardName = wizardNameField.text;

            var wizard = wizardManager.GenerateWizard(wizardName);

            spell = spellManager.GenerateRandomSpell(wizard);

            spellMenu.SetSpellName(spell);

            menuManager.ShowNextScreen();
        }
    }

    float popularityIntervalTimer = 0f;
    void Update()
    {
        popularityIntervalTimer -= Time.deltaTime;
        if (popularityIntervalTimer <= 0f)
        {
            BroadcastMessage("PopularityTick"); // tell listening classes to update properties relative to your spells popularity

            popularityIntervalTimer = POPULARITY_INTERVAL;
        }
    }

    void PopularityTick()
    {
        //Debug.Log("Popularity Ticked!");
    }
}
