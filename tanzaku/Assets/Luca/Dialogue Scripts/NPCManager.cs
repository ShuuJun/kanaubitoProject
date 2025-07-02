using System.Collections.Generic;
using UnityEngine;

namespace RedstoneinventeGameStudio
{
    public class NPCManager : MonoBehaviour
    {
        public List<DialogueSO> dialogues; // Use DialogueSO, not NPCDialogueSO
        public int currentDialogueIndex = 0;

        public DialogueSO secondaryDialogue;

        public void MoveNext()
        {
            currentDialogueIndex++;
            if (currentDialogueIndex >= dialogues.Count)
            {
                currentDialogueIndex = 0;
            }
        }

        private void OnMouseUp()
        {
            if (DialogueManager.IsDialogueActive) return;
            DialogueManager.instance.ShowDialogue(this);
        }

    }
}
