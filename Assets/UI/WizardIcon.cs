using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WizardIcon : MonoBehaviour
{
    static int OffsetX = 15;
    static int OffsetY = -15;
	// Use this for initialization
	void Start () {
    }

    public void MoveToRegion(MapNode node)
    {
        Debug.Log("Moving Icon to Region");

        RectTransform rect = GetComponent<RectTransform>();
        RectTransform target = node.GetComponent<RectTransform>();

        Vector3 p = rect.position;
        p.x = target.position.x + OffsetX;
        p.y = target.position.y + OffsetY;

        rect.position = p;
    }

    // Update is called once per frame
    void Update () {
        Pulse();
	}

    void Pulse()
    {
        // todo: slight pulse animation
    }
}
