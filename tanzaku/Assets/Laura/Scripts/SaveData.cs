using System;
using System.Collections.Generic;

[Serializable]

public class ItemData
{
    public string itemName;
    public int quantity;
}
[Serializable]
public class QuestData
{
    public string title;
    public bool isCompleted;
}

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

    // Inventory Data
    public List<ItemData> inventoryItems;

    // Quest Data
    public List<QuestData> quests;
}
