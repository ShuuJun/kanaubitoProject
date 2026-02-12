using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager Instance;

    private string savePath;
    public GameObject player;
    public bool hasTakePower;

    public InventoryManager inventoryManager;
    public QuestManager questManager;

    public QuestSelectionManager selectionManager;

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        FindManagersInScene();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindManagersInScene();
    }

    void FindManagersInScene()
    {
        if (selectionManager == null)
            selectionManager = FindObjectOfType<QuestSelectionManager>();

        if (questManager == null)
            questManager = FindObjectOfType<QuestManager>();

        if (player == null)
            player = GameObject.FindWithTag("Player");
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

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
        data.quests = new List<QuestData>();
        if (selectionManager != null)
        {
            foreach (var quest in selectionManager.allQuests)
            {
                QuestData questData = new QuestData();
                questData.title = quest.questTitle;
                questData.isUnlocked = quest.isUnlocked;
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

        // Load position
        if (player != null)
        {
            Vector3 newPos = new Vector3(data.playerPosX, data.playerPosY, data.playerPosZ);
            player.transform.position = newPos;
        }

        hasTakePower = data.hasTakePower;


        //Load Inventory
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
        if (data.quests != null)
        {
            // 1. Load Mission panel
            if (selectionManager != null)
            {
                for (int i = 0; i < data.quests.Count && i < selectionManager.allQuests.Count; i++)
                {
                    selectionManager.allQuests[i].isUnlocked = data.quests[i].isUnlocked;
                }
                selectionManager.UpdateSelectionDisplay();
            }

            // 2. Load Mission progress
            if (questManager != null)
            {
                for (int i = 0; i < data.quests.Count && i < questManager.quests.Count; i++)
                {
                    questManager.quests[i].isCompleted = data.quests[i].isCompleted;

                    if (data.quests[i].isCompleted)
                    {
                        questManager.CompleteCurrentQuest();
                    }
                }
            }
        }
    }
}