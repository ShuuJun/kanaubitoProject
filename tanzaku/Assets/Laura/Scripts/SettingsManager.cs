using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using UnityEngine.Localization.Settings;

public class SettingsManager : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;
    public Button englishButton;
    public Button japaneseButton;
    public TMP_Text englishButtonText;
    public TMP_Text japaneseButtonText;

    private Resolution[] resolutions;
    private bool resolutionsInitialized = false;
    private int currentLanguageIndex;

    void Start()
    {
        SetupResolutions();
        SetupFullscreen();

        StartCoroutine(DelayedLoadSettings());
    }

    IEnumerator DelayedLoadSettings()
    {
        yield return new WaitForSeconds(0.1f);
        LoadSettings();
    }

    // ======================== RESOLUTION ========================
    void SetupResolutions()
    {
        resolutionDropdown.ClearOptions();

        List<Resolution> allowedResolutions = new List<Resolution>
        {
        new Resolution { width = 1024, height = 768 },
        new Resolution { width = 1280, height = 720 },
        new Resolution { width = 1920, height = 1080 }
        };

        List<string> options = new List<string>();
        int savedResolutionIndex = 0;

        int savedWidth = PlayerPrefs.GetInt("ResolutionWidth", Screen.currentResolution.width);
        int savedHeight = PlayerPrefs.GetInt("ResolutionHeight", Screen.currentResolution.height);

        for (int i = 0; i < allowedResolutions.Count; i++)
        {
            string option = allowedResolutions[i].width + "x" + allowedResolutions[i].height;
            options.Add(option);

            if (allowedResolutions[i].width == savedWidth && allowedResolutions[i].height == savedHeight)
            {
                savedResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = savedResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        resolutionDropdown.onValueChanged.AddListener(SetResolution);
        resolutionsInitialized = true;

        SetResolution(savedResolutionIndex);
    }

    public void SetResolution(int resolutionIndex)
    {
        if (!resolutionsInitialized) return;

        List<Resolution> allowedResolutions = new List<Resolution>
        {
        new Resolution { width = 1024, height = 768 },
        new Resolution { width = 1280, height = 720 },
        new Resolution { width = 1920, height = 1080 }
        };

        if (resolutionIndex < 0 || resolutionIndex >= allowedResolutions.Count) return;

        Resolution resolution = allowedResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        PlayerPrefs.SetInt("ResolutionWidth", resolution.width);
        PlayerPrefs.SetInt("ResolutionHeight", resolution.height);
        PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);
        PlayerPrefs.Save();


    }



    // ======================== FULLSCREEN ========================
    void SetupFullscreen()
    {
        bool isFullscreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
        Screen.fullScreen = isFullscreen;
        fullscreenToggle.isOn = isFullscreen;

        fullscreenToggle.onValueChanged.AddListener(SetFullscreen);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
        PlayerPrefs.Save();
    }

    // ======================== LANGUAGE ========================


    /*public void SetLanguage(int languageIndex)
    {
        PlayerPrefs.SetInt("Language", languageIndex);
        PlayerPrefs.Save();

        StartCoroutine(ChangeLanguage(languageIndex));
    }

    private IEnumerator ChangeLanguage(int languageIndex)
    {
        yield return LocalizationSettings.InitializationOperation;

        if (languageIndex >= 0 && languageIndex < LocalizationSettings.AvailableLocales.Locales.Count)
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[languageIndex];
            UpdateLanguageButtons();
        }

    }

    private void UpdateLanguageButtons()
    {
        currentLanguageIndex = PlayerPrefs.GetInt("Language", 0);

        if (currentLanguageIndex == 0) // If it's in English
        {
            englishButtonText.text = "ENGLISH"; 
            japaneseButtonText.text = "日本語"; 
        }
        else if (currentLanguageIndex == 1) // If it's in Japanese
        {
            englishButtonText.text = "ENGLISH"; 
            japaneseButtonText.text = "日本語"; 
        }
    }*/

    // ======================== LOAD ========================
    public void LoadSettings()
{
    // Load fullscreen
    if (PlayerPrefs.HasKey("Fullscreen"))
    {
        bool isFullscreen = PlayerPrefs.GetInt("Fullscreen") == 1;
        fullscreenToggle.isOn = isFullscreen;
        Screen.fullScreen = isFullscreen;
    }

    // Load Language
    if (PlayerPrefs.HasKey("Language"))
    {
        currentLanguageIndex = PlayerPrefs.GetInt("Language");
        //StartCoroutine(ChangeLanguage(currentLanguageIndex));
    }

    // Load resolution
    if (resolutions == null || resolutions.Length == 0)
    {
        return;
    }

    if (PlayerPrefs.HasKey("ResolutionIndex"))
    {
        int resolutionIndex = PlayerPrefs.GetInt("ResolutionIndex");

        if (resolutionIndex >= 0 && resolutionIndex < resolutions.Length)
        {
            resolutionDropdown.value = resolutionIndex;
            resolutionDropdown.RefreshShownValue();

            Resolution resolution = resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        }

    }

    //UpdateLanguageButtons();

}
}
