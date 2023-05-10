using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;



public class Keyboard : MonoBehaviour
{
    private TouchScreenKeyboard keyboard;
    public static string keyboardText = "";
    public TextMeshProUGUI outputText;
    private bool isKeyboardOpen = false;

    public void OnInputFieldClicked()
    {
        if (!isKeyboardOpen)
        {
            keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
            isKeyboardOpen = true;
            outputText.enabled = true;
        }
    }

    private void Update()
    {
        if (keyboard != null && keyboard.status == TouchScreenKeyboard.Status.Done)
        {
            keyboardText = keyboard.text;
            outputText.text = keyboardText;
            outputText.enabled = false;
            keyboard = null;
            isKeyboardOpen = false;

        }
        else if (keyboard != null)
        {
            keyboardText = keyboard.text;
            outputText.text = keyboardText;
        }
    }
}
