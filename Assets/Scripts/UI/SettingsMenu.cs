using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class SettingsMenu : MonoBehaviour
{
    [Header("UI References:")]
    [SerializeField] private Text resolutionText;

    [SerializeField] private Toggle fullScreen;
    [SerializeField] private Toggle vSync;
    Resolution[] resolutions;

    private List<string> options = new List<string>();

    private void Start()
    {
        fullScreen.isOn = true;
        QualitySettings.vSyncCount = 1;

        resolutions = Screen.resolutions;

        foreach (Resolution resolution in resolutions)
        {
            options.Add(resolution.ToString());
        }

        resolutionText.text = options[1].ToString();
    }

    public void ChangeResolutionLeft(int back)
    {
        if(Screen.currentResolution.ToString() == options[1].ToString())
        {
            return;
        }
        else
        {
            //ChangeResolution();
        }
    }

    public void ChangeResolutionRight(int forward)
    {

    }

    private static void ChangeResolution(Resolution restoset)
    {

    }

    public void ApplyGraphics()
    {
        if(fullScreen.isOn)
        {
            Screen.fullScreen = true;
        }
        else Screen.fullScreen = false;

        if(vSync.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else QualitySettings.vSyncCount = 0;
    }
}

