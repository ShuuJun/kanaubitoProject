using JetBrains.Annotations;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

namespace RedstoneinventeGameStudio
{
    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager instance;
        public InventoryManager inventoryManager;
        public DialogueSO checkNextDialogue;

        public TMP_Text title;
        public TMP_Text content;

        public float characterDelay = 0.1f;
        public float punctuationDelay = 0.5f;

        public int maxWords = 10;

        public bool moveNext;
        public GameObject moveNextButt;

        public Canvas dialogueCanvas;

        public GameObject choicePanel;
        private bool hasPlayerMadeChoice = false;
        public TMP_Text choiceText1;
        public TMP_Text choiceText2t;

        public Image ImageTarget;

        public bool lastButton = false;

        private TMP_Text NextButtontext;

        public static bool IsDialogueActive { get; private set; }

        [Header("Multi-Choice UI")]
        public GameObject multiChoicePanel;
        public TMP_Text multiChoicePrompt;
        public Button[] choiceButtons; // Assign in inspector

        public GameObject secondaryChoicePanel; // Assign in inspector
        public Button[] secondaryChoiceButtons; // Up to 10, assign in inspector
        public TMP_Text secondaryResultText;    // Result area for secondary dialogue

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(instance.gameObject); // Remove duplicate from previous scene
            }

            instance = this;

            NextButtontext = moveNextButt.GetComponentInChildren<TextMeshProUGUI>();
            NextButtontext.text = "ŽŸ";
        }


        private void Update()
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Space Pressed");
                moveNext = true;
            }
        }

        public void MoveNext()
        {
            moveNext = true;
        }

        public void ShowChoice(string choice1, string choice2)
        {
            choiceText1.text = choice1;
            choiceText2t.text = choice2;
            //choicePanel.SetActive(true);
        }

        

        public void ShowDialogue(NPCManager npcManager)
        {
            void ShowDialogueImage(int index)
            {
                ImageTarget.sprite = npcManager.dialogues[index].dialogueImage;
                var color = ImageTarget.color;
                color.a = 1f;
                ImageTarget.color = color;
            }

            IsDialogueActive = true;


            ShowDialogueImage(npcManager.currentDialogueIndex);

            // 1. Show secondary dialogue if present (no longer used)
            //if (npcManager.secondaryDialogue != null)
            //{
            //    StartCoroutine(ShowSecondaryDialogue(npcManager.secondaryDialogue));
            //    //return;
            //}

            // 2. Otherwise, check for multi-choice
            var dialogue = npcManager.dialogues[0];

            if ((npcManager.HasCompletedQuest == true) || npcManager.QuestObject.itemSO.playerHasItem == false && npcManager.HasGivenItem == true)
            {
                dialogue = npcManager.dialogues[2];
                ShowDialogueImage(2);
            }
            else if (((npcManager.givesItem == true && npcManager.HasGivenItem == true) || (npcManager.QuestObject.itemSO.playerHasItem == true && npcManager.TakesPlayerItem == true && npcManager.HasTakenItem == false)) && npcManager.HasCompletedQuest == false)
            {
                dialogue = npcManager.dialogues[1];
                ShowDialogueImage(1);
            }
            //else if (((npcManager.givesItem == true && npcManager.HasGivenItem == false) || (npcManager.QuestObject.itemSO.playerHasItem == false && npcManager.TakesPlayerItem == true && npcManager.HasTakenItem == false)) && npcManager.HasCompletedQuest == true)
            //{
            //    dialogue = npcManager.dialogues[0];
            //}
            else
            {
                dialogue = npcManager.dialogues[0];
                ShowDialogueImage(0);
            }

            if (dialogue.choices != null && dialogue.choices.Count > 0)
            {
                StartCoroutine(ShowMultiChoiceDialogue(dialogue, npcManager)); // Always call it
                return;
            }


            // 3. Otherwise, show standard dialogue
            StartCoroutine(ShowDialogueC(npcManager, dialogue));
        }

        private IEnumerator TypewriterEffect(string text, TMP_Text target, float charDelay, float punctDelay, int maxWords)
        {
            target.text = "";
            int wordCount = 0;

            foreach (char character in text)
            {
                target.text += character;

                // Update TMP's internal info to get accurate word count
                target.ForceMeshUpdate();
                wordCount = target.textInfo.wordCount;

                yield return new WaitForSeconds(IsPunctuation(character) ? punctDelay : charDelay);

                // If maxWords reached and at a word boundary, pause and wait for input
                if (maxWords > 0 && wordCount >= maxWords && (character == ' ' || IsPunctuation(character) || character == ','))
                {
                    moveNextButt.SetActive(true);
                    moveNext = false;
                    yield return new WaitUntil(() => moveNext);
                    moveNextButt.SetActive(false);
                    target.text = "";
                    wordCount = 0; // Reset for next "page"
                }
            }
        }


        private IEnumerator ShowDialogueC(NPCManager nPCManager, DialogueSO dialogue)
        {
            dialogueCanvas.enabled = true;
            title.text = dialogue.title;

            yield return StartCoroutine(TypewriterEffect(dialogue.lines, content, characterDelay, punctuationDelay, maxWords));



            // Wait for player input to continue
            bool isLastDialogue = (nPCManager.currentDialogueIndex == nPCManager.dialogues.Count - 1);

            //if (nPCManager.dialogues[0].choices[0].nextDialogue != null)
            //    NextButtontext.text = "Next";
            //else
            //    NextButtontext.text = "Next";

            moveNextButt.SetActive(true);
            moveNext = false;
            yield return new WaitUntil(() => moveNext);
            moveNextButt.SetActive(false);
            secondaryChoicePanel.SetActive(false);

            dialogueCanvas.enabled = false;
            nPCManager.MoveNext();
            IsDialogueActive = false;
        }




        bool IsPunctuation(char character)
        {
            return character == '.' || character == '?' || character == '!';
        }

        public bool playerMadeChoice()
        {
            return hasPlayerMadeChoice;
        }

        public void makeChoice()
        {
            hasPlayerMadeChoice = true;
        }

        private IEnumerator ShowMultiChoiceDialogue(DialogueSO dialogue, NPCManager npc)
        {

            dialogueCanvas.enabled = true;
            title.text = dialogue.title;
            moveNextButt.SetActive(false);

            yield return StartCoroutine(TypewriterEffect(dialogue.lines, content, characterDelay, punctuationDelay, maxWords));

            // Filter choices - only show ones with actual text
            var validChoices = dialogue.choices.FindAll(c => !string.IsNullOrWhiteSpace(c.choiceText));

            if (validChoices.Count == 0)
            {
                //NextButtontext.text = "Last";
                moveNextButt.SetActive(true);
                moveNext = false;
                yield return new WaitUntil(() => moveNext);  // Wait for Next press
                moveNextButt.SetActive(false);


                // THEN check for nextDialogue
                DialogueSO nextDialogue = null;
                foreach (var c in dialogue.choices)
                {
                    if (c.nextDialogue != null)
                    {
                        
                        nextDialogue = c.nextDialogue;
                        break;
                    }
                    
                        
                }

                if (nextDialogue != null)
                {
                    yield return StartCoroutine(ShowMultiChoiceDialogue(nextDialogue, npc));
                }
                else
                {
                    dialogueCanvas.enabled = false;  // Hide canvas ONLY if no nextDialogue
                    npc.MoveNext();
                    IsDialogueActive = false;
                    
                }
                yield break;
            }

            // NORMAL choice flow (unchanged, but use validChoices)
            multiChoicePanel.SetActive(true);
            bool choiceMade = false;
            int chosenIndex = 0;
            Color firstButtonColor = new Color(126/255f,160/255f,255/255f);

            for (int i = 0; i < choiceButtons.Length; i++)
            {
                
                if (i < validChoices.Count)
                {
                    
                    choiceButtons[i].gameObject.SetActive(true);
                    int index = i;
                    choiceButtons[i].GetComponentInChildren<TMP_Text>().text = validChoices[i].choiceText;
                    if (npc != null && validChoices[index].isQuestDialogue == true) {
                        choiceButtons[i].GetComponent<Image>().color = new Color(0,255,0);
                    }
                    else choiceButtons[i].GetComponent<Image>().color = new Color(firstButtonColor.r, firstButtonColor.g, firstButtonColor.b);

                    choiceButtons[i].onClick.RemoveAllListeners();
                    choiceButtons[i].onClick.AddListener(() =>
                    {
                        choiceMade = true;
                        chosenIndex = index;
                        
                    });
      
                }
                else
                {
                    choiceButtons[i].gameObject.SetActive(false);
                }
            }

            yield return new WaitUntil(() => choiceMade);
            choiceButtons[chosenIndex].GetComponent<Image>().color = new Color(firstButtonColor.r, firstButtonColor.g, firstButtonColor.b);
            multiChoicePanel.SetActive(false);  // Hide choice buttons

            var selectedChoice = validChoices[chosenIndex];

            if (npc != null && selectedChoice.givesItem) npc.GivePlayerItem();
            if (npc != null && selectedChoice.takesItem) npc.RemovePlayerItem();


            // 1. Show resultText IMMEDIATELY after choice click
            if (!string.IsNullOrEmpty(selectedChoice.resultText))
            {

                yield return StartCoroutine(TypewriterEffect(selectedChoice.resultText, content, characterDelay, punctuationDelay, maxWords));
                moveNextButt.SetActive(true);
                moveNext = false;
                yield return new WaitUntil(() => moveNext);
                moveNextButt.SetActive(false);
            }
            else { 
                moveNextButt.SetActive(false);
                moveNext = true;

            }

            // 2. Then show Next button to advance (exactly like normal flow)

            //bool isLastDialogue = npc.currentDialogueIndex == npc.dialogues.Count - 1;
            //NextButtontext.text = isLastDialogue ? "Next" : "Next";
            

            // Handle nextDialogue AFTER Next press
            if (selectedChoice.nextDialogue != null)
            {
                
                yield return StartCoroutine(ShowMultiChoiceDialogue(selectedChoice.nextDialogue, npc));
                yield break;
            }
            else
            {
                //moveNextButt.SetActive(true);
                //moveNext = false;
                //yield return new WaitUntil(() => moveNext);
                //moveNextButt.SetActive(false);
            }

            // Normal end

            
            yield return new WaitUntil(() => moveNext);
            
            dialogueCanvas.enabled = false;
            npc.MoveNext();
            IsDialogueActive = false;

        }

        


        private IEnumerator ShowSecondaryDialogue(DialogueSO dialogue)
        {
            secondaryChoicePanel.SetActive(true);
            secondaryResultText.text = "";

            // Setup up to 10 choices
            for (int i = 0; i < secondaryChoiceButtons.Length; i++)
            {
                if (i < dialogue.choices.Count)
                {
                    secondaryChoiceButtons[i].gameObject.SetActive(true);
                    int index = i;
                    secondaryChoiceButtons[i].GetComponentInChildren<TMP_Text>().text = dialogue.choices[i].choiceText;
                    secondaryChoiceButtons[i].onClick.RemoveAllListeners();
                    secondaryChoiceButtons[i].onClick.AddListener(() =>
                    {
                        secondaryResultText.text = dialogue.choices[index].resultText;
                    });
                }
                else
                {
                    secondaryChoiceButtons[i].gameObject.SetActive(false);
                }
            }

            // No need to wait for input or hide the panel
            yield break;
        }
    }
}