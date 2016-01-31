using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NotificationManager : MonoBehaviour
{
    private static float NOTIFICATION_DURATION = 3f;

    public GameObject notificationPanel;

    public List<string> stack = new List<string>();

    private float timer = 0f;

    void Start()
    {
        if (!notificationPanel)
            notificationPanel = GameObject.Find("Notification Panel");
    }
        

    void Update()
    {
        if (notificationPanel.activeSelf)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f) ShowNextMessage();
        }
    }

    public void ShowNextMessage()
    {
        if (stack.Count > 0)
        {
            string message = stack[0];
            stack.RemoveAt(0);

            notificationPanel.GetComponentInChildren<Text>().text = message;

            notificationPanel.SetActive(true);

            timer = NOTIFICATION_DURATION;
        }
        else
        {
            notificationPanel.SetActive(false);
        }
    }

    public void QueueNotification(string message)
    {
        stack.Add(message);

        if (stack.Count == 1) ShowNextMessage();
    }
}
