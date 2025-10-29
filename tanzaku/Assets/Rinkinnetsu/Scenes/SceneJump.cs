using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneJump : MonoBehaviour
{
    // 跳转到任务栏（MapScene）
    public void GoToMap()
    {
        SceneManager.LoadScene("MapScene");
    }

    // 返回到主页面（LucaTestScene）
    public void GoToLuca()
    {
        SceneManager.LoadScene("LucaTestScene");
    }
}
