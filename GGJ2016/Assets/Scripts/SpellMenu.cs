using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpellMenu : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject spellPanel;
    public Text spellItemText; // temp. Would dynamically add spell items depending on how many you had?

    void Start()
    {
        if (!gameManager)
            gameManager = GameObject.FindObjectOfType<GameManager>();
    }
	public void SetSpellName(Spell spell)
    {
        spellItemText.text = spell.Name;
    }
}
