using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseSelfScene : MonoBehaviour
{
    public void CloseMainScene()
    {
        Scene scene = SceneManager.GetSceneByName("MainScene");

        if (scene.isLoaded)
        {
            SceneManager.UnloadSceneAsync(scene);
        }
    }
}
