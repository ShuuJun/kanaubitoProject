using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void Start()
    {
        //StartCoroutine(LoadSavedLanguage());
    }

    /*IEnumerator LoadSavedLanguage()
    {
        yield return LocalizationSettings.InitializationOperation; // Esperar inicialización

        if (PlayerPrefs.HasKey("Language"))
        {
            int savedLanguageIndex = PlayerPrefs.GetInt("Language");
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[savedLanguageIndex];
        }
    }*/

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
