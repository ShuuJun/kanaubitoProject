using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Quest : MonoBehaviour
{
    public string title;
    public string description;
    public bool isCompleted;

    public Quest(string title, string description)
    {
        this.title = title;
        this.description = description;
        this.isCompleted = false;
    }
}
