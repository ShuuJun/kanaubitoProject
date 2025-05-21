using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeZoneTestSceneManager : MonoBehaviour
{
    public static Action Morning;
    public static Action Afternoon;
    public static Action Evening;

    public static Action TimeChange;

    public static string timeZone { get; private set;}

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MorningStart()
    {
        timeZone = "Morning";
        TimeChange?.Invoke();
    }

    public void AfternoonStart()
    {
        timeZone = "Afternoon";
        TimeChange?.Invoke();
    }

    public void EveningStart()
    {
        timeZone = "Evening";
        TimeChange?.Invoke();
    }

}
