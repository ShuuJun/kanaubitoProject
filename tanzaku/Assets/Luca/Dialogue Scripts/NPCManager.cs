using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace RedstoneinventeGameStudio
{
    public class NPCManager : MonoBehaviour
    {
        public List<DialogueSO> dialogues; // Use DialogueSO, not NPCDialogueSO
        public int currentDialogueIndex = 0;

        //public ItemSO QuestItem;
        public bool givesItem;
        public Item QuestObject;
        public bool HasGivenItem;
        public InventoryManager inventoryManager;

        public bool TakesPlayerItem;
        public bool HasTakenItem;

        public DialogueSO secondaryDialogue;

        private void Start()
        {
            HasGivenItem = false;
            HasTakenItem = false;
    }

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

        public void GivePlayerItem()
        {

            //Debug.Log(">>> Inside GivePlayerItem");

            if (!HasGivenItem && QuestObject)
            {
                inventoryManager.AddItem(QuestObject.itemName, QuestObject.quantity, QuestObject.sprite, QuestObject.itemDescription);
                HasGivenItem = true;
            }
            //Debug.Log(">>> Given GivePlayerItem");
        }

        public void RemovePlayerItem()
        {
            if(!HasTakenItem)
            {
                inventoryManager.RemoveItem(QuestObject);
                HasTakenItem = true;
            }
        }

    }
}
