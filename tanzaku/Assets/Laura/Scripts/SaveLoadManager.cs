using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveLoadManager : MonoBehaviour
{
    private string savePath;
    public GameObject player;
    public bool hasTakePower;

    public InventoryManager inventoryManager;
    public QuestManager questManager;

    void Awake()
    {
        savePath = Application.persistentDataPath + "/savefile.json";
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();

        // Save player position
        if (player != null)
        {
            Vector3 pos = player.transform.position;
            data.playerPosX = pos.x;
            data.playerPosY = pos.y;
            data.playerPosZ = pos.z;
        }

        data.hasTakePower = hasTakePower;

        //Save Inventory
        data.inventoryItems = new List<ItemData>();
        if (inventoryManager != null)
        {
            foreach (var slot in inventoryManager.itemSlot)
            {
                ItemData itemData = new ItemData();
                itemData.itemName = slot.itemName;
                itemData.quantity = slot.quantity;
                data.inventoryItems.Add(itemData);
            }
        }

        // Save Quests
        if (questManager != null)
        {
            data.quests = new List<QuestData>();
            foreach (var quest in questManager.quests)
            {
                QuestData questData = new QuestData();
                questData.title = quest.title;
                questData.isCompleted = quest.isCompleted;
                data.quests.Add(questData);
            }
        }

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);

        Debug.Log("Saved game.");
    }

    public void LoadGame()
    {
        if (!File.Exists(savePath))
        {
            Debug.LogWarning("There is no save file.");
            return;
        }

        string json = File.ReadAllText(savePath);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        if (player != null)
        {
            Vector3 newPos = new Vector3(data.playerPosX, data.playerPosY, data.playerPosZ);
            player.transform.position = newPos;
        }

        hasTakePower = data.hasTakePower;

        if (inventoryManager != null && data.inventoryItems != null)
        {
            // Clear current inventory
            foreach (var slot in inventoryManager.itemSlot)
            {
                slot.ClearSlot();
            }

            // Load objects from file
            for (int i = 0; i < data.inventoryItems.Count && i < inventoryManager.itemSlot.Length; i++)
            {
                ItemData itemData = data.inventoryItems[i];

                if (!string.IsNullOrEmpty(itemData.itemName) && itemData.quantity > 0)
                {
                    inventoryManager.AddItem(itemData.itemName, itemData.quantity, null, null);
                }
            }
        }

        // Load the missions
        if (questManager != null && data.quests != null)
        {

            // Set the completion status for each quest based on the saved data
            for (int i = 0; i < data.quests.Count && i < questManager.quests.Count; i++)
            {
                questManager.quests[i].isCompleted = data.quests[i].isCompleted;
            }

            // Advance the currentQuestIndex by completing quests based on the saved data
            for (int i = 0; i < data.quests.Count && i < questManager.quests.Count; i++)
            {
                if (data.quests[i].isCompleted)
                {
                    questManager.CompleteCurrentQuest();
                }
            }
        }
    }
}