using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    public List<Quest> quests = new List<Quest>();
    private int currentQuestIndex = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        quests.Add(new Quest("Aさんと会話して", "Aさんを見つけて話す"));
        quests.Add(new Quest("Bさんと会話して", "Bさんを見つけて話す。"));
        quests.Add(new Quest("返回报告", "回去报告任务完成情况。"));
    }

    public Quest GetCurrentQuest()
    {
        if (currentQuestIndex < quests.Count)
            return quests[currentQuestIndex];
        return null;
    }

    public void CompleteCurrentQuest()
    {
        if (currentQuestIndex < quests.Count)
        {
            quests[currentQuestIndex].isCompleted = true;
            currentQuestIndex++;
        }
    }
}