using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // 这个函数可以绑定到按钮上
    public void LoadMapScene()
    {
        SceneManager.LoadScene("MapScene");
    }
}