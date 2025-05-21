using System;
using UnityEngine;

public class DeskInteraction : MonoBehaviour
{
    private bool playerInZone = false;

    public Action ChangeTime;
    public DeskSceneManager deskSceneManager; // Assign in Inspector

    void Start()
    {
        ChangeTime += deskSceneManager.AdvanceTime;
    }

    void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.X))
        {
            if (deskSceneManager.currentTimeZone != "Evening")
            {
                ChangeTime?.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
        }
    }
}
