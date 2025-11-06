using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupLoader : MonoBehaviour
{
    // 弹出场景的名称
    public string popupSceneName = "MainScene";

    // 点击按钮时调用
    public void OpenPopup()
    {
        // 叠加加载 PopupScene，不会卸载当前场景
        SceneManager.LoadScene(popupSceneName, LoadSceneMode.Additive);
    }
}
