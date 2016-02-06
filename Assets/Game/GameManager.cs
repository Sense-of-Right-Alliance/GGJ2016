﻿using UnityEngine;
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
    //public WizardDetailsUI wizardDetailsUI;
    public SpellHistoryMenu spellHistoryMenu;
    public RegionDetailsMenu regionDetailsMenu;
    public NotificationManager notificationManager;

    Wizard playerWizard;
    public Wizard PlayerWizard
    {
        get { return playerWizard; }
    }
    Region currentRegion;

    SpellManager spellManager;
    WizardManager wizardManager;
    RegionManager regionManager;

    WizardIcon wizardIcon;

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

        if (!wizardIcon)
            wizardIcon = GameObject.FindObjectOfType<WizardIcon>();

        spellManager = GetComponent<SpellManager>();
        wizardManager = GetComponent<WizardManager>();
        regionManager = GetComponent<RegionManager>();
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
        if (wizardName != null)
        {
            if (fromFirstScreen) playerWizard = wizardManager.GenerateWizard(wizardName);

            playerWizard.CurrentSpell = spellManager.GenerateRandomSpell(playerWizard);
            
            allSpells.Add(playerWizard.CurrentSpell);

            notificationManager.QueueNotification("You've researched the " + playerWizard.CurrentSpell.Name + " spell!");

            if (wizardIcon.inRegion) currentRegion.IntroduceSpell(playerWizard.CurrentSpell);

            if (fromFirstScreen)
            {
                
                regionManager.AddRandomSpellsToAllRegions();
                menuManager.HideScreen();
                notificationManager.QueueNotification("Promote your spell! You can change which region you're promoting in by clicking the region icon.", 8f);
            }

            gameObject.SendMessage("UpdateUI");
        }
    }

    public void TravelToRegionClicked(RegionDetailsMenu targetRegionMenu)
    {
        Region targetRegion = targetRegionMenu.CurrentRegion;

        if (currentRegion != null)
        {
            currentRegion.RemoveWizard(playerWizard);
            //Debug.Log("Removed from " + currentRegion.InternalName + " updated visiters = " + currentRegion.VisitingWizards.Count);
        }

        //targetRegion.AddWizard(playerWizard);
        currentRegion = targetRegion;

        //Debug.Log("Clicked to travel to the " + currentRegion.InternalName + " region! updated visiters = " + currentRegion.VisitingWizards.Count);

        wizardIcon.MoveToRegion(targetRegionMenu.CurrentNode, targetRegion.AddWizard);

        gameObject.SendMessage("UpdateUI");
    }

    float popularityIntervalTimer = 0f;
    void Update()
    {
        if (gameOver) return;

        popularityIntervalTimer -= Time.deltaTime;
        if (popularityIntervalTimer <= 0f)
        {
            BroadcastMessage("PopularityTick"); // tell listening classes to update properties relative to your spells popularity

            gameObject.SendMessage("UpdateUI");
            popularityIntervalTimer = POPULARITY_INTERVAL;

            CheckGameEnd();
        }
    }

    void PopularityTick()
    {
        //Debug.Log("Popularity Ticked!");
    }

    bool gameOver = false;
    void CheckGameEnd()
    {
        if (playerWizard != null && !playerWizard.Alive)
        {
            gameOver = true;
            gameObject.SendMessage("OnGameOver");
        }
    }
}
