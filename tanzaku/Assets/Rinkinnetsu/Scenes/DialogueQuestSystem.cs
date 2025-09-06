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
    // 对话任务状态
    private enum DialogueState { NotStarted, TalkToVillager, TalkToBlacksmith, TalkToMayor, Completed }
    private DialogueState currentState = DialogueState.NotStarted;
    // 单例模式，确保在所有场景中存在
    public static DialogueQuestSystem Instance;
    void Awake()
    {
        // 确保只有一个实例存在
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
        // 自动查找UI组件
        FindUIComponents();
        //SetupUIStyle();
        if (questPanel != null)
        {
            questPanel.SetActive(false);
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
    
    void SetTextStyle(Text textComponent, int fontSize, FontStyle style, Color color)
    {
        if (textComponent != null)
        {
            textComponent.fontSize = fontSize;
            textComponent.fontStyle = style;
            textComponent.color = color;
            textComponent.alignment = TextAnchor.MiddleCenter;
        }
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 重新查找UI组件
        FindUIComponents();
        //SetupUIStyle();
        UpdateQuestDisplay();
    }
    void Update()
    {
        // 按B键开关任务面板
        if (Input.GetKeyDown(KeyCode.B))
        {
            ToggleQuestPanel();
        }
        // 测试快捷键
        HandleTestInput();
    }
    void ToggleQuestPanel()
    {
        if (questPanel != null)
        {
            bool isActive = !questPanel.activeSelf;
            questPanel.SetActive(isActive);
            if (isActive)
            {
                UpdateQuestDisplay();
            }
        }
    }
    // 开始对话任务
    public void StartDialogueQuest()
    {
        if (currentState != DialogueState.NotStarted) return;
        currentState = DialogueState.TalkToVillager;
        Debug.Log("开始对话任务：收集村民意见");
        UpdateQuestDisplay();
    }
    // 完成与村民的对话
    public void CompleteVillagerDialogue()
    {
        if (currentState == DialogueState.TalkToVillager)
        {
            currentState = DialogueState.TalkToBlacksmith;
            Debug.Log("已完成：与村民对话");
            UpdateQuestDisplay();
        }
    }
    // 完成与铁匠的对话
    public void CompleteBlacksmithDialogue()
    {
        if (currentState == DialogueState.TalkToBlacksmith)
        {
            currentState = DialogueState.TalkToMayor;
            Debug.Log("已完成：与铁匠对话");
            UpdateQuestDisplay();
        }
    }
    // 完成与村长的对话
    public void CompleteMayorDialogue()
    {
        if (currentState == DialogueState.TalkToMayor)
        {
            currentState = DialogueState.Completed;
            Debug.Log("任务完成！所有对话已完成");
            UpdateQuestDisplay();
        }
    }
    // 更新UI显示
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
    // 获取当前对话目标信息
    public string GetCurrentDialogueTarget()
    {
        switch (currentState)
        {
            case DialogueState.TalkToVillager:
                return "村民小李（村庄广场）";
            case DialogueState.TalkToBlacksmith:
                return "铁匠老王（铁匠铺）";
            case DialogueState.TalkToMayor:
                return "村长张大爷（村长家）";
            case DialogueState.Completed:
                return "所有对话已完成";
            default:
                return "暂无对话任务";
        }
    }
    // 检查是否可以与某个NPC对话
    public bool CanTalkToNPC(string npcType)
    {
        switch (npcType)
        {
            case "Villager":
                return currentState == DialogueState.TalkToVillager;
            case "Blacksmith":
                return currentState == DialogueState.TalkToBlacksmith;
            case "Mayor":
                return currentState == DialogueState.TalkToMayor;
            default:
                return false;
        }
    }
    // 检查任务是否完成
    public bool IsQuestCompleted()
    {
        return currentState == DialogueState.Completed;
    }
    // 重置任务
    public void ResetQuest()
    {
        currentState = DialogueState.NotStarted;
        UpdateQuestDisplay();
        Debug.Log("对话任务已重置");
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
}