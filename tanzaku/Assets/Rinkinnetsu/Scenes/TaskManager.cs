using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class TaskManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject taskPanel;
    public Text titleText;
    public Text descText;
    public Text progressText;
    private int currentStep = 0;
    private bool isQuestActive = false;
    private bool isQuestCompleted = false;
    void Start()
    {
        if (taskPanel != null)
        {
            taskPanel.SetActive(false);
        }
    }
    void Update()
    {
        HandleInput();
    }
    void HandleInput()
    {
        // 开关任务面板
        if (Input.GetKeyDown(KeyCode.B) && taskPanel != null)
        {
            taskPanel.SetActive(!taskPanel.activeSelf);
            UpdateDisplay();
        }
        // 开始任务1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartQuest(1);
        }
        // 开始任务2
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartQuest(2);
        }
        // 推进任务进度
        if (Input.GetKeyDown(KeyCode.T))
        {
            AdvanceQuest();
        }
        // 重置任务
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetQuest();
        }
    }
    void StartQuest(int questType)
    {
        isQuestActive = true;
        isQuestCompleted = false;
        currentStep = 0;
        Debug.Log("开始新任务");
        UpdateDisplay();
    }
    void AdvanceQuest()
    {
        if (!isQuestActive || isQuestCompleted) return;
        currentStep++;
        if (currentStep >= 3)
        {
            isQuestCompleted = true;
            Debug.Log("任务完成！");
        }
        else
        {
            Debug.Log("进度更新: 步骤 " + currentStep);
        }
        UpdateDisplay();
    }
    void ResetQuest()
    {
        isQuestActive = false;
        isQuestCompleted = false;
        currentStep = 0;
        UpdateDisplay();
        Debug.Log("任务已重置");
    }
    void UpdateDisplay()
    {
        if (titleText == null || descText == null || progressText == null) return;
        if (isQuestActive)
        {
            titleText.text = "寻找失落的钥匙";
            descText.text = "帮助老人寻找重要的钥匙";
            if (!isQuestCompleted)
            {
                switch (currentStep)
                {
                    case 0:
                        progressText.text = "1. 与老人对话 (位置: 村庄广场)";
                        break;
                    case 1:
                        progressText.text = "2. 在花园寻找钥匙 (位置: 村东花园)";
                        break;
                    case 2:
                        progressText.text = "3. 返回交给老人 (位置: 村庄广场)";
                        break;
                    default:
                        progressText.text = "进行中...";
                        break;
                }
            }
            else
            {
                progressText.text = "任务已完成！";
            }
        }
        else
        {
            titleText.text = "暂无任务";
            descText.text = "按1开始寻找钥匙任务";
            progressText.text = "按2开始谜题任务";
        }
    }
    // 外部调用的方法
    public void CompleteStep(string targetName)
    {
        Debug.Log("完成步骤: " + targetName);
        AdvanceQuest();
    }
    public string GetCurrentTask()
    {
        if (!isQuestActive) return "没有进行中的任务";
        switch (currentStep)
        {
            case 0: return "与老人对话 - 位置: 村庄广场";
            case 1: return "寻找钥匙 - 位置: 村东花园";
            case 2: return "归还钥匙 - 位置: 村庄广场";
            default: return "任务进行中";
        }
    }
}