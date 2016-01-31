using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static float POPULARITY_INTERVAL = 0.2f;

    public InputField wizardNameField;

    public string wizardName;
    public Spell currentSpell;
    public List<Spell> allSpells = new List<Spell>();

    public MenuManager menuManager;
    public SpellHistoryMenu spellHistoryMenu;
    public NotificationManager notificationManager;

    SpellManager spellManager;

    public void Start()
    {
        if (!menuManager)
            menuManager = GameObject.FindObjectOfType<MenuManager>();

        if (!notificationManager)
            notificationManager = GameObject.FindObjectOfType<NotificationManager>();

        if (!spellHistoryMenu)
            spellHistoryMenu = GameObject.FindObjectOfType<SpellHistoryMenu>();

        spellManager = GetComponent<SpellManager>();
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
            
            menuManager.ShowNextScreen();
        }
    }

    public void ResearchNewSpellClicked(bool fromFirstScreen=false)
    {
        if (wizardNameField && wizardNameField.text != "")
        {
            currentSpell = spellManager.GenerateRandomSpell(wizardName);

            allSpells.Add(currentSpell);

            notificationManager.QueueNotification("You've researched the " + currentSpell.Name + " spell!");

            spellHistoryMenu.UpdateSpellList();

            if (fromFirstScreen) menuManager.HideScreen();
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
