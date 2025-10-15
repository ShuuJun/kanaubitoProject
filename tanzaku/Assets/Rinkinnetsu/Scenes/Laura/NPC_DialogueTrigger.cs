using UnityEngine;

public class NPC_DialogueTrigger : MonoBehaviour
{
    // Type of NPC.
    [Tooltip("Type must match 'Villager', 'Blacksmith', or 'Mayor'")]
    public string npcType = "Villager";

    // Method called when the player interacts with the NPC
    public void Interact()
    {
        if (DialogueQuestSystem.Instance == null)
        {
            Debug.LogError("DialogueQuestSystem がシーンに存在しません。");
            return;
        }

        // 2. Current state of the quest
        if (DialogueQuestSystem.Instance.CanTalkToNPC(npcType))
        {

            Debug.Log($"重要度の高い{npcType}との会話を開始します。");

            AdvanceQuestState();

        }
        else if (DialogueQuestSystem.Instance.IsQuestCompleted())
        {
            // Quest completed, then a generic dialogue
            Debug.Log($"Dialogue from {npcType}: '手伝ってくれてありがとう、すべて順調です。'");
        }
        else
        {
            // Quest not started or wrong NPC
            Debug.Log($"Dialogue from {npcType}: 'こんにちは、いかがですか？' (現在の目標ではありません)");
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

    private bool isPlayerInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) isPlayerInRange = true;
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