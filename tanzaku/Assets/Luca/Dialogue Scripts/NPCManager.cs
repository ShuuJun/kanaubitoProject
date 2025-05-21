using System.Collections.Generic;
using UnityEngine;

namespace RedstoneinventeGameStudio
{
    public class NPCManager : MonoBehaviour
    {
        public List<NPCDialogueSO> dialogues;
        public int currentDialogueIndex = 0;

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
            var currentDialogue = dialogues[currentDialogueIndex];
            bool choice = currentDialogue.choice;
            if(choice)
            {
                DialogueManager.instance.ShowChoice(currentDialogue.choice1, currentDialogue.choice2);
            }
            DialogueManager.instance.ShowDialogue(this, choice);
        }
    }
}