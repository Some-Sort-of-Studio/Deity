using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class SettingsMenu : MonoBehaviour
{
    [Header("UI References:")]
    [SerializeField] private TMP_Text resolutionText;

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

        resolutionText.text = Screen.currentResolution.ToString();
    }

    public void ChangeResolutionLeft(int current)
    {
        if(Screen.currentResolution.ToString() == resolutions[options.Count].ToString())
        {
            return;
        }
        else
        {
            ChangeResolution(resolutions[options.Count - 1]);
        }
    }

    public void ChangeResolutionRight(int current)
    {
        if (Screen.currentResolution.ToString() == resolutions[options.Count].ToString())
        {
            return;
        }
        else
        {
            ChangeResolution(resolutions[options.Count + 1]);
        }
    }

    private static void ChangeResolution(Resolution restoset)
    {
        Screen.SetResolution(restoset.width, restoset.height, false);
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

