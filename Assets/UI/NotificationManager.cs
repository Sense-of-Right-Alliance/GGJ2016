using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class NotificationManager : MonoBehaviour
{
    private static float NOTIFICATION_DURATION = 3f;

    public class NotificationDetails
    {
        public string Message = "";
        public float Duration = 3f;
    }

    public GameObject notificationPanel;

    List<NotificationDetails> stack = new List<NotificationDetails>();

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
            NotificationDetails notification = stack[0];
            stack.RemoveAt(0);

            notificationPanel.GetComponentInChildren<Text>().text = notification.Message;

            notificationPanel.SetActive(true);

            timer = notification.Duration;
        }
        else
        {
            notificationPanel.SetActive(false);
        }
    }

    public void QueueNotification(string message, float duration=-1f)
    {
        NotificationDetails notificationDeets = new NotificationDetails();
        notificationDeets.Message = message;
        notificationDeets.Duration = duration == -1f ? NOTIFICATION_DURATION : duration;

        stack.Add(notificationDeets);

        if (!notificationPanel.activeSelf && stack.Count == 1) ShowNextMessage();
    }
}


