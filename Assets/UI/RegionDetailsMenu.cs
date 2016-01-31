using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RegionDetailsMenu : MonoBehaviour {

    string region = "Mountain";
    public Text nameText;

    void Start()
    {
        gameObject.SetActive(false);

        if (!nameText)
            nameText = transform.FindChild("Name").GetComponent<Text>();
    }

    public string Region
    {
        get { return region; }
    }

	public void Init(string region)
    {
        this.region = region;

        nameText.text = region;

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
