using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NameMenu : MonoBehaviour {

    public InputField inputField;
    public Button confirmButton;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (inputField.isFocused && inputField.text != "" && Input.GetKey(KeyCode.Return))
        {
            confirmButton.onClick.Invoke();
            inputField.text = "";
        }
    }
}
