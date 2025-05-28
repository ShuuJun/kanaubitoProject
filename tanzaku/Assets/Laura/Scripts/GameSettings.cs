using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/GameSettings")]

public class GameSettings : MonoBehaviour
{
    [Range(0, 1)] public float musicVolume = 0.5f;
    [Range(0, 1)] public float sfxVolume = 0.5f;
    public bool fullscreen = true;
    public int resolutionWidth = 1920;
    public int resolutionHeight = 1080;
}
