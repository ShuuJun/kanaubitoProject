using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSwap : MonoBehaviour
{
    public GameObject otherPlayer;

    //void Start()
    //{
    //    swapPlayers();
    //}

    void Update() {

        if (Input.GetKeyDown(KeyCode.Z)) {
            otherPlayer.GetComponent<SimplePlayerController>().enabled = true;
            GetComponent<SimplePlayerController>().enabled = false;
        }
            

    }
}
