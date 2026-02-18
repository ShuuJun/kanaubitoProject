using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuestCanvasManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject questCanvas;           // The Canvas to toggle
    public Transform questListParent;        // Parent of the quest list texts
    public Text detailTitleText;
    public Text detailRequesterText;
    public Text detailObjectiveText;
    public Text detailLocationText;

    [Header("Player References")]
    public GameObject player;
    public MonoBehaviour playerMovementScript; // Your player movement script

    [Header("UI Settings")]
    public Color selectedColor = Color.magenta;
    public Color defaultColor = Color.white;
    public Color lockedColor = Color.gray;

    [Header("Quest Data")]
    public List<QuestData> allQuests = new List<QuestData>();

    private List<Text> questTextComponents = new List<Text>();
    private int selectedIndex = 0;
    private bool isCanvasOpen = false;

    [System.Serializable]
    public class QuestData
    {
        public string questTitle;
        public string detailTitle;
        public string requester;
        public string objective;
        public string location;
        public bool isUnlocked = false;
    }

    void Start()
    {
        if (questCanvas == null || player == null || playerMovementScript == null)
        {
            Debug.LogError("Assign all references in the Inspector!");
            return;
        }

        // Start with canvas closed
        questCanvas.SetActive(false);

        // Initialize quest list texts
        questTextComponents.Clear();
        foreach (Transform child in questListParent)
        {
            Text textComp = child.GetComponent<Text>();
            if (textComp != null) questTextComponents.Add(textComp);
        }

        UpdateSelectionDisplay();
        UpdateDetailPanel();
    }

    void Update()
    {
        // Toggle canvas
        if (Input.GetKeyDown(KeyCode.R))
        {
            ToggleCanvas();
        }

        // Handle navigation only when canvas is open
        if (isCanvasOpen)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                Navigate(-1);
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                Navigate(1);
            }
        }
    }

    private void ToggleCanvas()
    {
        isCanvasOpen = !isCanvasOpen;
        questCanvas.SetActive(isCanvasOpen);

        // Disable/enable player movement
        playerMovementScript.enabled = !isCanvasOpen;

        if (isCanvasOpen)
        {
            // Automatically select the first unlocked quest
            selectedIndex = 0; // fallback
            for (int i = 0; i < allQuests.Count; i++)
            {
                if (allQuests[i].isUnlocked)
                {
                    selectedIndex = i;
                    break;
                }
            }
        }

        // Refresh UI
        UpdateSelectionDisplay();
        UpdateDetailPanel();
    }

    private void Navigate(int direction)
    {
        int newIndex = selectedIndex + direction;

        // Loop around
        if (newIndex < 0) newIndex = allQuests.Count - 1;
        if (newIndex >= allQuests.Count) newIndex = 0;

        // Only select unlocked quests
        if (!allQuests[newIndex].isUnlocked)
        {
            int startIndex = newIndex;
            do
            {
                newIndex += direction;
                if (newIndex < 0) newIndex = allQuests.Count - 1;
                if (newIndex >= allQuests.Count) newIndex = 0;
                if (newIndex == startIndex) break; // Prevent infinite loop if all locked
            } while (!allQuests[newIndex].isUnlocked);
        }

        selectedIndex = newIndex;
        UpdateSelectionDisplay();
        UpdateDetailPanel();
    }

    public void UnlockQuest(int index)
    {
        if (index >= 0 && index < allQuests.Count)
        {
            allQuests[index].isUnlocked = true;
            UpdateSelectionDisplay();
            UpdateDetailPanel();
        }
    }

    private void UpdateSelectionDisplay()
    {
        for (int i = 0; i < questTextComponents.Count; i++)
        {
            if (i >= allQuests.Count) continue;

            QuestData quest = allQuests[i];

            if (!quest.isUnlocked)
            {
                questTextComponents[i].text = "--------";
                questTextComponents[i].color = lockedColor;
            }
            else
            {
                questTextComponents[i].text = quest.questTitle;
                questTextComponents[i].color = (i == selectedIndex) ? selectedColor : defaultColor;
            }
        }
    }

    private void UpdateDetailPanel()
    {
        if (selectedIndex >= allQuests.Count) return;

        QuestData quest = allQuests[selectedIndex];

        detailTitleText.text = quest.isUnlocked ? quest.detailTitle : "--------";
        detailRequesterText.text = quest.isUnlocked ? "依頼者：" + quest.requester : "";
        detailObjectiveText.text = quest.isUnlocked ? "内容：" + quest.objective : "";
        detailLocationText.text = quest.isUnlocked ? "行先：" + quest.location : "";
    }
}
