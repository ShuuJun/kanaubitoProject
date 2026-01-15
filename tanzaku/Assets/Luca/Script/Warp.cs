using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warp : MonoBehaviour
{
    public string WarpTo;
    public wpLocationData waypoint;
    public wpLocationData currentLocation;
    private bool isPlayerInside = false;
    public SimplePlayerController player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPlayerInside = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerInside = false;
    }

    public void SavePosition()
    {
        currentLocation.waypointCoordinates = waypoint.waypointCoordinates;
        //PlayerPrefs.SetFloat("PlayerX", waypoint.waypointCoordinates.x);
        //PlayerPrefs.SetFloat("PlayerY", waypoint.waypointCoordinates.y);
        //PlayerPrefs.SetFloat("PlayerZ", waypoint.waypointCoordinates.z);
        //PlayerPrefs.Save(); // Ensure data is written to disk/registry
    }

    private void Update()
    {
        if (isPlayerInside && Input.GetKeyDown(KeyCode.F))
        {
            SavePosition();
            SceneManager.LoadScene(WarpTo);
        }
    }
}
