using UnityEngine;
using TMPro;

public class WebGLInputList : MonoBehaviour
{
    public TMP_InputField inputField;
    private TouchScreenKeyboard keyboard = new TouchScreenKeyboard(string.Empty, TouchScreenKeyboardType.NumberPad, false, false,true,false, "CUSTOM", 15);

    void Start()
    {
        inputField.onValidateInput += (input, charIndex, addedChar) => MyValidate(addedChar);
    }

    void Update()
    {
        //for (int i = 0; i < inputField.Length; i++)
        {
            // Check if the current input field is focused and the keyboard is not already open
            if (inputField.isFocused && (keyboard == null || !keyboard.active))
            {
                // Open the soft keyboard for this input field
                keyboard = TouchScreenKeyboard.Open(inputField.text, TouchScreenKeyboardType.NumberPad);
            }

            // Sync the input field with the keyboard input (in case keyboard is used)
            if (keyboard != null && keyboard.active)
            {
                inputField.text = keyboard.text;
            }
        }
    }
    private void OnDestroy()
    {
        inputField.onValidateInput -= (input, charIndex, addedChar) => MyValidate(addedChar);
    }

    private char MyValidate(char addedChar)
    {
        return char.IsDigit(addedChar) ? addedChar : '\0';
    }
}