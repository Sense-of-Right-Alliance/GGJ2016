using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static float POPULARITY_INTERVAL = 0.2f;

    public InputField wizardNameField;

    public string wizardName;
    public List<Spell> allSpells = new List<Spell>();

    public MenuManager menuManager;
    public SpellHistoryMenu spellHistoryMenu;
    public RegionDetailsMenu regionDetailsMenu;
    public NotificationManager notificationManager;

    SpellManager spellManager;
    WizardManager wizardManager;

    public void Awake()
    {
        if (!menuManager)
            menuManager = GameObject.FindObjectOfType<MenuManager>();

        if (!notificationManager)
            notificationManager = GameObject.FindObjectOfType<NotificationManager>();

        if (!spellHistoryMenu)
            spellHistoryMenu = GameObject.FindObjectOfType<SpellHistoryMenu>();

        if (!regionDetailsMenu)
            regionDetailsMenu = GameObject.FindObjectOfType<RegionDetailsMenu>();

        spellManager = GetComponent<SpellManager>();
        wizardManager = GetComponent<WizardManager>();
    }

    public void MapNodeClicked(string region)
    {
        regionDetailsMenu.Init(region);
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
            var wizard = wizardManager.GenerateWizard(wizardName);
            wizard.CurrentSpell = spellManager.GenerateRandomSpell(wizard);
            
            allSpells.Add(wizard.CurrentSpell);

            notificationManager.QueueNotification("You've researched the " + wizard.CurrentSpell.Name + " spell!");

            spellHistoryMenu.UpdateSpellList();

            if (fromFirstScreen) menuManager.HideScreen();
        }
    }

    public void TravelToRegionClicked()
    {
        string region = regionDetailsMenu.Region;
        Debug.Log("Clicked to travel to the " + region + " region!");
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
