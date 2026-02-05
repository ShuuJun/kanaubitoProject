using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaypointLocationData", menuName = "LocationData")]
public class wpLocationData : ScriptableObject
{
    public Vector3 waypointCoordinates;
    public string savedScene;
    public bool takeshiActive = false;
    public bool warpedState = false;
}