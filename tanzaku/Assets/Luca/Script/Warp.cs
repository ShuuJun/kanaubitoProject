using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warp : MonoBehaviour
{
    public string WarpTo;
    private bool isPlayerInside = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPlayerInside = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerInside = false;
    }

    private void Update()
    {
        if(isPlayerInside && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(WarpTo);
        }
    }
}
