using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuPanel : MonoBehaviour {

    public enum TransitionDir { Left, Right };

    public RectTransform panel;

    public delegate void TransitionCallbackDelegate();

    private enum MenuTransitionState { on, off, tOn, tOff };
    private MenuTransitionState state = MenuTransitionState.off;

    private TransitionDir currentDir = TransitionDir.Right;
    private MenuManager.MenuTransitionType transitionType;
    private float speed = 600.0f;

    TransitionCallbackDelegate callback;

    public void TransitionOn(MenuManager.MenuTransitionType transitionType, TransitionDir dir=TransitionDir.Left,  TransitionCallbackDelegate callback = null, float speed=600.0f)
    {
        this.speed = 600.0f;
        this.transitionType = transitionType;
        this.callback = callback;
        TransitionOnInternal(dir);
    }

    public void TransitionOnInternal(TransitionDir dir)
    {
        gameObject.SetActive(true);
        if (transitionType == MenuManager.MenuTransitionType.Instant)
        {
            TransitionOnFinished();
        }
        else
        {
            // todo: handle other transitions  
        }
    }
    
    public void TransitionOff(MenuManager.MenuTransitionType transitionType, TransitionDir dir=TransitionDir.Right, TransitionCallbackDelegate callback=null, float speed=600.0f)
    {
        this.transitionType = transitionType;
        this.callback = callback;
        TransitionOffInternal(dir);
    }

    public void TransitionOffInternal(TransitionDir dir)
    {
        if (transitionType == MenuManager.MenuTransitionType.Instant)
        {
            TransitionOffFinished();
        }
        else
        {
            // todo: handle other transitions
        }
    }

    void Update()
    {
        switch (state)
        {
            case (MenuTransitionState.tOn):
                //UpdateTransOn();
                break;
            case (MenuTransitionState.tOff):
                //UpdateTransOff();
                break;
        }
    }

    void TransitionOnFinished()
    {
        state = MenuTransitionState.on;

        if (callback != null)
            callback();
    }

    void TransitionOffFinished()
    {
        state = MenuTransitionState.off;

        gameObject.SetActive(false);

        if (callback != null)
            callback();
    }
}
