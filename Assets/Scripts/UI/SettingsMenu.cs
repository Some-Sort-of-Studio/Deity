using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class SettingsMenu : MonoBehaviour
{
    [Header("UI References:")]
    [SerializeField] private Dropdown resDropDown;

    [SerializeField] private Toggle fullScreen;
    [SerializeField] private Toggle vSync;
    Resolution[] resolutions;

    private void Start()
    {
        fullScreen.isOn = true;
        QualitySettings.vSyncCount = 1;

        resolutions = Screen.resolutions;

        List<string> options = new List<string>();

        foreach (Resolution resolution in resolutions)
        {
            options.Add(resolution.ToString());
        }

        resDropDown.AddOptions(options);
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

