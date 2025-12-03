using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuestSelectionManager : MonoBehaviour
{
    [Header("UI References")]
    public Transform questListParent;
    public Text detailTitleText;
    public Text detailRequesterText;
    public Text detailObjectiveText;

    // --- Settings ---
    [Header("Settings")]
    public Color selectedColor = Color.magenta;
    public Color defaultColor = Color.white;

    private List<Text> questTextComponents = new List<Text>();
    private int selectedIndex = 0;
    private bool isInputEnabled = true;

    [System.Serializable]
    public class QuestData
    {
        public string questTitle;   // Title in the right panel (Ej: クエスト1)
        public string detailTitle;  // Title in the left panel (Ej: クエスト：本を返す)
        public string requester;    // Applicant (Ej: 依頼人：森乃千花)
        public string objective;    // Objective (Ej: 目的：千花はみのり先輩の本を返してほしい。)
    }

    // Quest List and details
    [Header("Quest Data")]
    public List<QuestData> allQuests = new List<QuestData>();

    // ==========================================================
    // INITIALIZATION
    // ==========================================================
    void Start()
    {
        InitializeQuestList();

        if (questTextComponents.Count > 0)
        {
            UpdateSelectionDisplay();
            UpdateDetailPanel();
        }
    }

    void InitializeQuestList()
    {
        if (questListParent == null)
        {
            Debug.LogError("Quest List Parent is not assigned in the Inspector.");
            return;
        }

        questTextComponents.Clear();
        foreach (Transform child in questListParent)
        {
            Text textComp = child.GetComponent<Text>();
            if (textComp != null)
            {
                questTextComponents.Add(textComp);
            }
        }

        if (questTextComponents.Count != allQuests.Count)
        {
            Debug.LogWarning($"Quest text count ({questTextComponents.Count}) does not match Quest Data count ({allQuests.Count}). Check your UI setup and data list.");
        }
    }

    // ==========================================================
    // INPUT HANDLING AND NAVIGATION
    // ==========================================================
    void Update()
    {
        if (!isInputEnabled) return;

        // Move UP
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Navigate(-1);
        }

        // Move DOWN
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Navigate(1);
        }
    }

    void Navigate(int direction)
    {
        int newIndex = selectedIndex + direction;

        // Limit the index within the range of available missions
        if (newIndex >= 0 && newIndex < questTextComponents.Count)
        {
            selectedIndex = newIndex;
            UpdateSelectionDisplay();
            UpdateDetailPanel();
        }
        // Si quieres que el cursor "envuelva" de abajo a arriba:
        /*
        else if (newIndex < 0)
        {
            selectedIndex = questTextComponents.Count - 1;
            UpdateSelectionDisplay();
            UpdateDetailPanel();
        }
        else if (newIndex >= questTextComponents.Count)
        {
            selectedIndex = 0;
            UpdateSelectionDisplay();
            UpdateDetailPanel();
        }
        */
    }

    // ==========================================================
    // UI UPDATE
    // ==========================================================

    // Change the text color in the selected mission
    void UpdateSelectionDisplay()
    {
        for (int i = 0; i < questTextComponents.Count; i++)
        {
            if (i == selectedIndex)
            {
                questTextComponents[i].color = selectedColor;
            }
            else
            {
                questTextComponents[i].color = defaultColor;
            }
        }
    }

    // Update the details panel on the left
    void UpdateDetailPanel()
    {
        if (selectedIndex >= allQuests.Count) return;

        QuestData currentQuest = allQuests[selectedIndex];

        if (detailTitleText != null)
        {
            
            detailTitleText.text = currentQuest.detailTitle;
        }

        if (detailRequesterText != null)
        {
            
            detailRequesterText.text = "依頼人：" + currentQuest.requester;
        }

        if (detailObjectiveText != null)
        {
            
            detailObjectiveText.text = "目的：" + currentQuest.objective;
        }
    }
}