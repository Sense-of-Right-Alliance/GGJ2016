using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WizardIcon : MonoBehaviour
{
    static int OffsetX = 15;
    static int OffsetY = -15;

    public delegate void WizardMoveCallback(Wizard wizard);

    public float rotationRate = 12f;
    public float travelSpeed = 0.5f;

    GameManager gameManager;
    // Use this for initialization
    void Start ()
    {
        if(!gameManager)
            gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    Vector2 start;
    Vector2 end;
    float progress;

    WizardMoveCallback moveCallback;
    bool moving = false;
    public void MoveToRegion(MapNode node, WizardMoveCallback callback)
    {
        Debug.Log("Moving Icon to Region");

        this.moveCallback = callback;

        RectTransform rect = GetComponent<RectTransform>();
        RectTransform target = node.GetComponent<RectTransform>();

        

        start = new Vector2(rect.position.x, rect.position.y);

        end = new Vector2(target.position.x + OffsetX, target.position.y + OffsetY);

        progress = 0f;
        moving = true;
    }

    // Update is called once per frame
    void Update () {
        if (gameManager.PlayerWizard != null)
        {
            if (moving) UpdateMove();
            Pulse();
            Rotate();
        }
	}

    void UpdateMove()
    {
        RectTransform rect = GetComponent<RectTransform>();
        Vector3 p = rect.position;

        progress += Time.deltaTime * travelSpeed;

        if (progress >= 1f)
        {
            progress = 1f;
            moving = false;

            if (moveCallback != null)
                moveCallback(gameManager.PlayerWizard);
        }

        Vector2 current = Vector2.Lerp(start, end, progress);

        p.x = current.x;
        p.y = current.y;

        rect.position = p;
    }

    void Pulse()
    {
        // todo: slight pulse animation
    }

    float rotation = 0f;
    void Rotate()
    {
        rotation += Time.deltaTime * (rotationRate / (Mathf.Max(gameManager.PlayerWizard.Age,100f)/100f));

        RectTransform rect = GetComponent<RectTransform>();
        rect.rotation = Quaternion.Euler(0, 0, rotation);
    }
}
