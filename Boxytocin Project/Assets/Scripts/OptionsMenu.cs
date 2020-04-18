using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    public TMPro.TMP_Dropdown resolutionDropdown;
    public TMPro.TMP_Dropdown qualityDropdown;
    public Toggle fullScreenButton;
    public static float sliderVolume = 1.0f;
    Resolution[] resolutions;
    public static int resolutionChoice = 0;
    public static int qualityChoice = 5;
    public static bool fullScreenChoice = true;


    private void Start()
    {
        GameObject.Find("Slider").GetComponent<Slider>().value = sliderVolume;
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        qualityDropdown.value = qualityChoice;
        qualityDropdown.RefreshShownValue();
        fullScreenButton.isOn = fullScreenChoice;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        sliderVolume = GameObject.Find("Slider").GetComponent<Slider>().value;
    }

    public void SetQuality(int qualityIndex)
    {
        qualityChoice = qualityIndex;
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        fullScreenChoice = isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

}
