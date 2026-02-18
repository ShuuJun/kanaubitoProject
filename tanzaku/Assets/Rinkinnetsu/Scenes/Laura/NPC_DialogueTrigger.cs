using UnityEngine;

public class NPC_DialogueTrigger : MonoBehaviour
{
    // Type of NPC.
    [Header("NPC Settings")]
    [Tooltip("Type must match 'Villager', 'Blacksmith', or 'Mayor'")]
    public string npcType = "Villager";

    [Header("Quest Unlock Settings")]
    [Tooltip("The mission that will unlock in the list on the right after speaking with this NPC. For example: 1")]
    public int questIndexToUnlock = 1;

    [Header("References")]
    public QuestSelectionManager uiManager;


    void Awake()
    {
        Debug.Log("UI Manager found: " + uiManager);
    }


    // Method called when the player interacts with the NPC
    public void Interact()
    {
        if (DialogueQuestSystem.Instance == null)
        {
            Debug.LogError("DialogueQuestSystem がシーンに存在しません。");
            return;
        }

        if (DialogueQuestSystem.Instance.CanTalkToNPC(npcType))
        {
            Debug.Log($"重要度の高い{npcType}との会話を開始します。");

            AdvanceQuestState();

            if (uiManager != null)
            {
                uiManager.UnlockQuest(questIndexToUnlock);
                Debug.Log($"クエスト {questIndexToUnlock} がリストに開放されました。");
            }
        }
        else if (DialogueQuestSystem.Instance.IsQuestCompleted())
        {
            Debug.Log($"Dialogue from {npcType}: '手伝ってくれてありがとう、すべて順調です。'");
        }
        else
        {
            Debug.Log($"Dialogue from {npcType}: 'こんにちは、いかがですか？'");
        }
    }


    // Advance the quest state
    private void AdvanceQuestState()
    {
        switch (npcType)
        {
            case "Villager":
                DialogueQuestSystem.Instance.CompleteVillagerDialogue();
                break;
            case "Blacksmith":
                DialogueQuestSystem.Instance.CompleteBlacksmithDialogue();
                break;
            case "Mayor":
                DialogueQuestSystem.Instance.CompleteMayorDialogue();
                break;
            default:
                Debug.LogError($"Unknown NPC type: {npcType}");
                break;
        }
    }

    // --- Proximity logic ---
    private bool isPlayerInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) isPlayerInRange = true;
        Debug.Log("Player entered NPC trigger!");
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) isPlayerInRange = false;
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }
}