using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Keyboard : MonoBehaviour
{

    public void OnInputFieldClicked()
    {
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }

    TouchScreenKeyboard keyboard;
    public static string keyboardText = "";

    void Start()
    {
        keyboard = new TouchScreenKeyboard("Sample text that goes into the textbox", TouchScreenKeyboardType.Default, false, false, false, false, "sample prompting text that goes above the textbox", 26);
    }

    void Update()
    {

        if (keyboard != null)
        {

            keyboardText = keyboard.text;
            /*if (keyboard.done == true)
            {
                keyboardText = keyboard.text;
                keyboard = null;
            }*/
        }
    }
}