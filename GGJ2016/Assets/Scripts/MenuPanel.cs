using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuPanel : MonoBehaviour {

    public enum TransitionDir { Left, Right };

    public RectTransform panel;

    public float speed = 100.0f;

    public delegate void TransitionCallbackDelegate();

    private enum MenuTransitionState { on, off, tOn, tOff };

    private MenuTransitionState state = MenuTransitionState.off;

    private float leftOffX = -413f;
    private float rightOffX = 1101f;
    private float OnX = 310f;

    private float[] dirOnXs = { 1101f, -413f };
    private float[] dirOffXs = { -413f, 1101f };
    private float[] dirSpeedMults = { -1, 1 };

    private TransitionDir currentDir = TransitionDir.Right;

    TransitionCallbackDelegate callback;

    public void Start()
    {

    }

    public void TransitionOn(TransitionDir dir)
    {
        TransitionOnInternal(dir);
    }

    public void TransitionOn(TransitionDir dir, TransitionCallbackDelegate callback)
    {
        this.callback = callback;
        TransitionOnInternal(dir);
    }

    public void TransitionOnInternal(TransitionDir dir)
    {
        gameObject.SetActive(true);

        Vector3 pos = panel.position;
        pos.x = leftOffX;

        pos.x = dirOnXs[(int)dir];

        currentDir = dir;
        panel.position = pos;

        state = MenuTransitionState.tOn;
    }

    public void TransitionOff(TransitionDir dir)
    {
        TransitionOffInternal(dir);
    }

    public void TransitionOff(TransitionDir dir, TransitionCallbackDelegate callback)
    {
        this.callback = callback;
        TransitionOffInternal(dir);
    }

    public void TransitionOffInternal(TransitionDir dir)
    {
        Vector3 pos = panel.position;
        pos.x = OnX;

        currentDir = dir;

        state = MenuTransitionState.tOff;
    }

    void Update()
    {
        switch (state)
        {
            case (MenuTransitionState.tOn):
                UpdateTransOn();
                break;
            case (MenuTransitionState.tOff):
                UpdateTransOff();
                break;
        }
    }

    void UpdateTransOn()
    {
        Vector3 pos = panel.position;
        pos.x += dirSpeedMults[(int)currentDir] * speed * Time.deltaTime;

        if (currentDir == TransitionDir.Left && (pos.x <= OnX))
        {
            TransitionOnFinished(pos);
        } else if (currentDir == TransitionDir.Right && (pos.x >= OnX))
        {
            TransitionOnFinished(pos);
        }

        panel.position = pos;
    }

    void UpdateTransOff()
    {
        Vector3 pos = panel.position;
        pos.x += dirSpeedMults[(int)currentDir] * speed * Time.deltaTime;

        if (currentDir == TransitionDir.Left && (pos.x <= dirOffXs[(int)currentDir]))
        {
            TransitionOffFinished(pos);
        } else if (currentDir == TransitionDir.Right && (pos.x >= dirOffXs[(int)currentDir])) {
            TransitionOffFinished(pos);
        }

        panel.position = pos;
    }

    void TransitionOnFinished(Vector3 pos)
    {
        pos.x = OnX;
        state = MenuTransitionState.on;

        if (callback != null)
            callback();
    }

    void TransitionOffFinished(Vector3 pos)
    {
        pos.x = dirOffXs[(int)currentDir];
        state = MenuTransitionState.off;

        gameObject.SetActive(false);

        if (callback != null)
            callback();
    }
}
