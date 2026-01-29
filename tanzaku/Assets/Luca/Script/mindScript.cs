using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mindScript : MonoBehaviour
{
    public GameObject[] Players;
    [SerializeField]
    GameObject currentPlayer;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < Players.Length; i++)
        {
            Players[i].GetComponent<SimplePlayerController>().enabled = false;
        }
        currentPlayer = Players[0];
    }

    public void ChangePlayer(GameObject player)
    {
        
        currentPlayer.GetComponent<SimplePlayerController>().enabled = false;
        if (currentPlayer == Players[0])
            currentPlayer = Players[1];
        else
            currentPlayer = Players[0];
    }
}
