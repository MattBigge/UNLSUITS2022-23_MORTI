using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class IPKeyboard : MonoBehaviour
{
    private TouchScreenKeyboard keyboard;
    public static string keyboardText = "";
    public TextMeshProUGUI outputText;
    private bool isKeyboardOpen = false;

    public GameObject[] objectsToActivate;

    private void Start()
    {
        OpenKeyboard();
    }

    public void OnInputFieldClicked()
    {
        OpenKeyboard();
    }

    private void OpenKeyboard()
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

            // Activate other objects
            StartCoroutine(ActivateObjects());
        }
        else if (keyboard != null)
        {
            keyboardText = keyboard.text;
            outputText.text = keyboardText;
        }
    }

    private IEnumerator ActivateObjects()
    {
        yield return new WaitForEndOfFrame();

        // Activate other objects
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(true);
        }
    }
}
