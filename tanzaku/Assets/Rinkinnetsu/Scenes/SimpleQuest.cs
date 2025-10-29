using UnityEngine;
using UnityEngine.UI;
public class SimpleQuest : MonoBehaviour
{
    private GameObject panel;
    private Text title;
    private Text desc;
    private Text step;
    private int progress = 0;
    void Start()
    {
        // 查找UI组件
        panel = GameObject.Find("QuestPanel");
        title = GameObject.Find("TitleText")?.GetComponent<Text>();
        desc = GameObject.Find("DescText")?.GetComponent<Text>();
        step = GameObject.Find("StepText")?.GetComponent<Text>();
        if (panel != null) panel.SetActive(false);
        Debug.Log("按B开关任务，按T推进任务");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && panel != null)
        {
            panel.SetActive(!panel.activeSelf);
            UpdateText();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            progress++;
            if (progress > 3) progress = 3;
            UpdateText();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            progress = 0;
            UpdateText();
        }
    }
    void UpdateText()
    {
        if (title == null || desc == null || step == null) return;
        title.text = "寻找宝剑";
        desc.text = "帮助铁匠任务";
        switch (progress)
        {
            case 0: step.text = "按T开始任务"; break;
            case 1: step.text = "1. 与铁匠对话"; break;
            case 2: step.text = "2. 寻找宝剑"; break;
            case 3: step.text = "3. 任务完成!"; break;
        }
    }
}