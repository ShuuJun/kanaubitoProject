using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestUIManager : MonoBehaviour
{
    public GameObject questPanel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI statusText;
    public Button completeButton;

    private void Start()
    {
        questPanel.SetActive(true);
        completeButton.onClick.AddListener(CompleteQuest);
    }

    public void ToggleQuestPanel()
    {
        questPanel.SetActive(!questPanel.activeSelf);
        UpdateQuestUI();
    }

    void CompleteQuest()
    {
        QuestManager.Instance.CompleteCurrentQuest();
        UpdateQuestUI();
    }

    void UpdateQuestUI()
    {
        Quest current = QuestManager.Instance.GetCurrentQuest();
        if (current != null)
        {
            titleText.text = current.title;
            descriptionText.text = current.description;
            statusText.text = current.isCompleted ? "已完成" : "进行中";
            completeButton.interactable = !current.isCompleted;
        }
        else
        {
            titleText.text = "任务完成";
            descriptionText.text = "所有任务已完成！";
            statusText.text = "";
            completeButton.interactable = false;
        }
    }
}