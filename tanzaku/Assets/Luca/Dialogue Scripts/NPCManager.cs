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


        public void StartDialogue()
        {
            if (DialogueManager.IsDialogueActive) return;
            DialogueManager.instance.ShowDialogue(this);
        }

        /*  //origibal method, now its by pressing e
        private void OnMouseUp()
        {
            if (DialogueManager.IsDialogueActive) return;
            DialogueManager.instance.ShowDialogue(this);
        }*/

    }
}
