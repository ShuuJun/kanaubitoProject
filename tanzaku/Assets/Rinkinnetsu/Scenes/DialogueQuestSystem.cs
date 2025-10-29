using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueQuestSystem : MonoBehaviour
{
    [Header("UI References")]
    public GameObject questPanel;
    public Text titleText;
    public Text descText;
    public Text currentTargetText;
    public Text locationText;
    public Text progressText;

    private enum DialogueState { NotStarted, TalkToVillager, TalkToBlacksmith, TalkToMayor, Completed }
    private DialogueState currentState = DialogueState.NotStarted;

    public static DialogueQuestSystem Instance;

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
            return;
        }
    }

    void Start()
    {
        FindUIComponents();

        // ✅ 一开始显示面板
        if (questPanel != null)
        {
            questPanel.SetActive(true);
        }

        UpdateQuestDisplay();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void FindUIComponents()
    {
        if (questPanel == null) questPanel = GameObject.Find("QuestPanel");
        if (titleText == null)
        {
            GameObject titleObj = GameObject.Find("TitleText");
            if (titleObj != null) titleText = titleObj.GetComponent<Text>();
        }
        if (descText == null)
        {
            GameObject descObj = GameObject.Find("DescText");
            if (descObj != null) descText = descObj.GetComponent<Text>();
        }
        if (currentTargetText == null)
        {
            GameObject targetObj = GameObject.Find("CurrentTargetText");
            if (targetObj != null) currentTargetText = targetObj.GetComponent<Text>();
        }
        if (locationText == null)
        {
            GameObject locationObj = GameObject.Find("LocationText");
            if (locationObj != null) locationText = locationObj.GetComponent<Text>();
        }
        if (progressText == null)
        {
            GameObject progressObj = GameObject.Find("ProgressText");
            if (progressObj != null) progressText = progressObj.GetComponent<Text>();
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindUIComponents();
        UpdateQuestDisplay();
    }

    void Update()
    {
        HandleTestInput();
    }


    // ===== 以下是任务文字逻辑 =====

    void UpdateQuestDisplay()
    {
        if (titleText == null || descText == null || currentTargetText == null ||
            locationText == null || progressText == null) return;

        switch (currentState)
        {
            case DialogueState.NotStarted:
                titleText.text = "对话任务";
                descText.text = "收集村民们的意见";
                currentTargetText.text = "目标：等待接受任务";
                locationText.text = "位置：-";
                progressText.text = "进度：未开始";
                break;
            case DialogueState.TalkToVillager:
                titleText.text = "收集村民意见";
                descText.text = "首先与村民对话了解情况";
                currentTargetText.text = "目标：村民小李";
                locationText.text = "位置：村庄广场";
                progressText.text = "进度：1/3 - 第一个对话";
                break;
            case DialogueState.TalkToBlacksmith:
                titleText.text = "收集村民意见";
                descText.text = "接下来询问铁匠的意见";
                currentTargetText.text = "目标：铁匠老王";
                locationText.text = "位置：铁匠铺";
                progressText.text = "进度：2/3 - 第二个对话";
                break;
            case DialogueState.TalkToMayor:
                titleText.text = "收集村民意见";
                descText.text = "最后向村长汇报情况";
                currentTargetText.text = "目标：村长张大爷";
                locationText.text = "位置：村长家";
                progressText.text = "进度：3/3 - 最终对话";
                break;
            case DialogueState.Completed:
                titleText.text = "任务完成！";
                descText.text = "成功收集所有村民意见";
                currentTargetText.text = "目标：已完成";
                locationText.text = "位置：-";
                progressText.text = "进度：3/3 - 完成";
                break;
        }
    }

    // 测试用快捷键
    void HandleTestInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) StartDialogueQuest();
        if (Input.GetKeyDown(KeyCode.Alpha2)) CompleteVillagerDialogue();
        if (Input.GetKeyDown(KeyCode.Alpha3)) CompleteBlacksmithDialogue();
        if (Input.GetKeyDown(KeyCode.Alpha4)) CompleteMayorDialogue();
        if (Input.GetKeyDown(KeyCode.R)) ResetQuest();
    }

    public void StartDialogueQuest()
    {
        if (currentState != DialogueState.NotStarted) return;
        currentState = DialogueState.TalkToVillager;
        UpdateQuestDisplay();
    }

    public void CompleteVillagerDialogue()
    {
        if (currentState == DialogueState.TalkToVillager)
        {
            currentState = DialogueState.TalkToBlacksmith;
            UpdateQuestDisplay();
        }
    }

    public void CompleteBlacksmithDialogue()
    {
        if (currentState == DialogueState.TalkToBlacksmith)
        {
            currentState = DialogueState.TalkToMayor;
            UpdateQuestDisplay();
        }
    }

    public void CompleteMayorDialogue()
    {
        if (currentState == DialogueState.TalkToMayor)
        {
            currentState = DialogueState.Completed;
            UpdateQuestDisplay();
        }
    }

    public void ResetQuest()
    {
        currentState = DialogueState.NotStarted;
        UpdateQuestDisplay();
    }

    // ===== FIX: ADDED MISSING METHODS HERE =====

    /// <summary>
    /// Checks if the player can talk to a specific NPC based on the current quest state.
    /// </summary>
    /// <param name="npcType">The type of the NPC (e.g., "Villager").</param>
    /// <returns>True if it's the correct time to talk to this NPC, otherwise false.</returns>
    public bool CanTalkToNPC(string npcType)
    {
        switch (currentState)
        {
            case DialogueState.TalkToVillager:
                return npcType == "Villager";
            case DialogueState.TalkToBlacksmith:
                return npcType == "Blacksmith";
            case DialogueState.TalkToMayor:
                return npcType == "Mayor";
            default:
                return false;
        }
    }

    /// <summary>
    /// Checks if the quest has been completed.
    /// </summary>
    /// <returns>True if the quest state is 'Completed', otherwise false.</returns>
    public bool IsQuestCompleted()
    {
        return currentState == DialogueState.Completed;
    }
}