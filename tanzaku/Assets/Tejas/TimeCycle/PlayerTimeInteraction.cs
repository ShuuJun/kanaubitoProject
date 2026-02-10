using UnityEngine;

/// <summary>
/// Allows the player to interact with a specific object to change the time of day.
/// This script should be attached to the Player GameObject.
/// </summary>
public class PlayerTimeInteraction : MonoBehaviour
{
    [Tooltip("Reference to the scene's TimeController.")]

    // A flag to check if the player is currently inside the trigger zone of a time-changing object.
    private bool canChangeTime = false;

    private TimeController timeController;

    void Start()
    {
        timeController = TimeController.Instance;
    }


    void Update()
    {
        // Check if the player is in the interaction zone and presses the 'E' key.
        if (canChangeTime && Input.GetKeyDown(KeyCode.E))
        {
            if (timeController != null)
            {
                timeController.AdvanceTime();
            }
            else
            {
                Debug.LogError("TimeController is not assigned on the PlayerTimeInteraction script!");
            }
        }
    }

    // Called when the player's collider enters another trigger collider.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // We use a tag to identify the object that can be used to change time.
        if (other.CompareTag("TimeChanger"))
        {
            canChangeTime = true;
            // You can add a UI prompt here to show "Press E to change time"
        }
    }

    // Called when the player's collider exits another trigger collider.
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("TimeChanger"))
        {
            canChangeTime = false;
            // You can hide the UI prompt here
        }
    }
}

