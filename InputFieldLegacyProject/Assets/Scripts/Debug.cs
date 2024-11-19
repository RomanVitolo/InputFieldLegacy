using System;
using UnityEngine;
using UnityEngine.UI;

public class Debug : MonoBehaviour
{
    public Text _msgText;
    
    private void OnApplicationPause(bool pauseStatus)
    {
        _msgText.text = pauseStatus ? $"The Application is: {pauseStatus.ToString()}" : "No application pause.";
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        _msgText.text = hasFocus ? $"The Application is: {hasFocus.ToString()}" : "No application focus.";
    }
}
