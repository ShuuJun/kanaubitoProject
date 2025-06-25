using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameHandler : MonoBehaviour
{

    public static int playerStat1;

    public static bool GameisPaused = false;
    public GameObject mainMenuUI;
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    public AudioMixer mixer;
    public static float volumeLevel = 1.0f;

    private enum MenuCaller
    {
        None,
        FromMainMenu,
        FromPauseMenu
    }

    private MenuCaller lastMenuCaller = MenuCaller.None;


    void Start()
    {
        pauseMenuUI.SetActive(false);
        GameisPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (GameisPaused) { Resume(); }
            else { Pause(); }
        }
        // Stat tester:
        //if (Input.GetKey("p")){
        //       Debug.Log("Player Stat = " + playerStat1);
        //}
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("Scene1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("Scene2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("Scene3");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene("Scene4");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SceneManager.LoadScene("Scene5");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SceneManager.LoadScene("Scene6");
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SceneManager.LoadScene("Scene7");
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SceneManager.LoadScene("Scene8");
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            SceneManager.LoadScene("SceneWin");
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void OpenCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        // Please also reset all static variables here, for new games!
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }

    public void OpenSettingsFromMainMenu()
    {
        lastMenuCaller = MenuCaller.FromMainMenu;
        mainMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
    }

    public void OpenSettingsFromPauseMenu()
    {
        lastMenuCaller = MenuCaller.FromPauseMenu;
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
    }

    public void BackFromSettings()
    {
        settingsMenuUI.SetActive(false);

        if (lastMenuCaller == MenuCaller.FromMainMenu)
        {
            mainMenuUI.SetActive(true);
        }
        else if (lastMenuCaller == MenuCaller.FromPauseMenu)
        {
            pauseMenuUI.SetActive(true);
        }

        lastMenuCaller = MenuCaller.None;
    }
}