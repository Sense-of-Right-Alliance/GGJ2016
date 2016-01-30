using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

    public MenuPanel[] menus;

    int screenIndex = -1;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < menus.Length; i++)
        {
            menus[i].gameObject.SetActive(false);
        }
        ShowScreen(0, MenuPanel.TransitionDir.Right);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowNextScreen()
    {
        ShowScreen(Mathf.Clamp(screenIndex + 1, 0, menus.Length), MenuPanel.TransitionDir.Right);
    }

    public void ShowPreviousScreen()
    {
        ShowScreen(Mathf.Clamp(screenIndex - 1, 0, menus.Length), MenuPanel.TransitionDir.Left);
    }

    public void HideScreen()
    {
        if (screenIndex >= 0) menus[screenIndex].TransitionOff(MenuPanel.TransitionDir.Right);
    }

    public void ShowScreen(int index, MenuPanel.TransitionDir dir)
    {
        Debug.Log("Showing screen " + index);
        if (screenIndex >= 0) menus[screenIndex].TransitionOff(dir);

        screenIndex = index;
        menus[screenIndex].TransitionOn(dir);
    }
    public void HideAllScreens(MenuPanel.TransitionCallbackDelegate callback)
    {
        if (screenIndex >= 0) menus[screenIndex].TransitionOff(MenuPanel.TransitionDir.Right, callback);
    }
}
