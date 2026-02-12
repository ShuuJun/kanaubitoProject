using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warp : MonoBehaviour
{
    public string WarpTo;
    public wpLocationData waypoint;
    public wpLocationData currentLocation;
    public wpLocationData makotoLocation;
    private bool isPlayerInside = false;
    public SimplePlayerController player;
    public GameObject playerMakoto;
    public GameObject playerTakeshi;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerTakeshi.activeInHierarchy == true)
        {
            playerTakeshi.GetComponent<TakeshiPlayerController>().warpedState = true;
        }
        isPlayerInside = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (playerTakeshi.activeInHierarchy == true)
        {
            playerTakeshi.GetComponent<TakeshiPlayerController>().warpedState = false;
        }
        isPlayerInside = false;
    }

    public void SavePosition()
    {
        currentLocation.waypointCoordinates = waypoint.waypointCoordinates;
        //Debug.Log(waypoint.waypointCoordinates);
        if (makotoLocation.takeshiActive == true)
        {
            if (makotoLocation.warpedState == false)
            {
                makotoLocation.savedScene = SceneManager.GetActiveScene().name;
            }
            makotoLocation.warpedState = true;
            makotoLocation.waypointCoordinates = playerMakoto.GetComponent<Transform>().position;
            playerTakeshi.GetComponent<TakeshiPlayerController>().warpedState = true;
            playerMakoto.GetComponent<SimplePlayerController>().warped = true;
        }
            
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
            //player.warped = true;
            SceneManager.LoadScene(WarpTo);
        }
    }
}
