using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneToggler : MonoBehaviour
{
    [Header("要叠加的场景名称")]
    public string sceneName = "MainScene"; // 这里写要叠加的场景名

    private bool isSceneLoaded = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetSceneByName("MainScene");

            if (!scene.isLoaded)
            {
                SceneManager.LoadScene("MainScene", LoadSceneMode.Additive);
            }
        }
    }

    void LoadSceneAdditively()
    {
        if (!isSceneLoaded)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            isSceneLoaded = true;
            Debug.Log($"已叠加加载场景: {sceneName}");
        }
    }

    void UnloadScene()
    {
        if (isSceneLoaded)
        {
            SceneManager.UnloadSceneAsync(sceneName);
            isSceneLoaded = false;
            Debug.Log($"已卸载叠加场景: {sceneName}");
        }
    }
}
