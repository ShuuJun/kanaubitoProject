using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupCloser : MonoBehaviour
{
    public void ClosePopupScene()
    {
        // 获取当前按钮所在的场景并卸载它
        SceneManager.UnloadSceneAsync(gameObject.scene);
    }
}
