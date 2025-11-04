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

        SetFullScreen(true);
        resolutions = Screen.resolutions;

        List<string> options = new List<string>();

        foreach (Resolution resolution in resolutions)
        {
            options.Add(resolution.ToString());
        }

        resDropDown.AddOptions(options);
    }

    public void SetFullScreen(bool isfullscreen)
    {
        fullScreen.isOn = isfullscreen;
    }

    public void SetVSync(bool vsyncOn)
    {
        vSync.isOn = vsyncOn;
    }

    public void ApplyGraphics()
    {

    }
}

