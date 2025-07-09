using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    // Player Position
    public float playerPosX;
    public float playerPosY;
    public float playerPosZ;

    // Special powers unlocked
    public bool hasTakePower;

    // Current scene
    public string currentScene;
}
