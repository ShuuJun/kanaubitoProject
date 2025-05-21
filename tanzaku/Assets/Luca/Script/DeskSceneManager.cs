using System.Collections.Generic;
using UnityEngine;

public class DeskSceneManager : MonoBehaviour
{
    public List<string> timeZones = new List<string>
    {
        "Morning",
        "Afternoon",
        "Evening"
    };

    public string currentTimeZone;
    private int currentIndex = 0;

    void Start()
    {
        currentTimeZone = timeZones[0];
    }

    public string GetNextTime()
    {
        currentIndex = (currentIndex + 1) % timeZones.Count;
        return timeZones[currentIndex];
    }

    public void AdvanceTime()
    {
        currentTimeZone = GetNextTime();
        Debug.Log("Time changed to: " + currentTimeZone);
    }
}
