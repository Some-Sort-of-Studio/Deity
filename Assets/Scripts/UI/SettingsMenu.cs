using UnityEngine;
using TMPro;
using UnityEditor;

public class SettingsMenu : MonoBehaviour
{
    [Header("Text References:")]
    [SerializeField] private TMP_Text resolutionText;
    [SerializeField] private TMP_Text screenTypeText;
    [SerializeField] private TMP_Text vSyncText;
    [SerializeField] private TMP_Text qualityText;
    [SerializeField] private TMP_Text particleText;

    // resolution ID + array
    private int resolutionID;
    Resolution[] resolutions;

    [Header("Quality Settings:")]
    [SerializeField] private int qualityIndex = 2;
    [SerializeField] private string[] qualityName;

    private void Start()
    {
        // sets everything to default on start
        DefaultSettings();

        resolutions = Screen.resolutions;

        resolutionText.text = Screen.currentResolution.ToString();

        resolutionID = resolutions.Length;
    }

    public void DefaultSettings()
    {
        // screen defaults
        Screen.fullScreen = true;
        screenTypeText.text = "Fullscreen";
        QualitySettings.vSyncCount = 1;
        vSyncText.text = "vSync On";

        // graphics defaults
        qualityIndex = 2;
        QualitySettings.SetQualityLevel(qualityIndex);
        qualityText.text = qualityName[qualityIndex];


        particleText.text = "High";
    }

    protected virtual void SetPrefs()
    {
        // set all default values
    }

    public void ChangeResolutionLeft()
    {
        if (resolutionID == 0)
        {
            return;
        }
        else
        {
            resolutionID -= 1;
            ChangeResolution(resolutions[resolutionID]);
        }
    }

    public void ChangeResolutionRight()
    {
        if(resolutionID == resolutions.Length)
        {
            return;
        }
        else
        {
            resolutionID += 1;
            ChangeResolution(resolutions[resolutionID]);
        }
    }

    private void ChangeResolution(Resolution restoset)
    {
        Screen.SetResolution(restoset.width, restoset.height, true);
        resolutionText.text = Screen.currentResolution.ToString();
    }

    public void ChangeFullscreen(bool set)
    {
        Screen.fullScreen = set;

        if(set == true)
        {
            screenTypeText.text = "Fullscreen";
        }
        else
        {
            screenTypeText.text = "Windowed";
        }
    }

    public void ChangeVSync(bool set)
    {
        if(set == true)
        {
            QualitySettings.vSyncCount = 1;
            vSyncText.text = "vSync On";
        }
        else
        {
            QualitySettings.vSyncCount = 0;
            vSyncText.text = "vSync Off";
        }
    }

    public void SetQualityLevelUp()
    {
        if (qualityIndex == 2)
        {
            return;
        }
        else
        {
            qualityIndex += 1;
            QualitySettings.SetQualityLevel(qualityIndex);
            qualityText.text = qualityName[qualityIndex];
        }
    }

    public void SetQualityLevelDown()
    {
        if(qualityIndex == 0)
        {
            return;
        }
        else
        {
            qualityIndex -= 1;
            QualitySettings.SetQualityLevel(qualityIndex);
            qualityText.text = qualityName[qualityIndex];
        }
    }
}

