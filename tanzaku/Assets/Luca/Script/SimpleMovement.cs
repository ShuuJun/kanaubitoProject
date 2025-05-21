using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SimpleMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // Get input axes
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float moveY = Input.GetAxis("Vertical");   // W/S or Up/Down

        // For 2D movement (X and Y axes)
         Vector3 move = new Vector3(moveX, moveY, 0);

        // For 3D movement (X and Z axes)
        //Vector3 move = new Vector3(moveX, 0, moveY);

        // Move the object
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
    }
}
