using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Dropdown resDropDown;
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
        Screen.fullScreen = isfullscreen;
    }
}
