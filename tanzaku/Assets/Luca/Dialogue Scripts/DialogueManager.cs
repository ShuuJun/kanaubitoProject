using JetBrains.Annotations;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

namespace RedstoneinventeGameStudio
{
    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager instance;

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
            NextButtontext.text = "Next";
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
            IsDialogueActive = true;

            if (npcManager.dialogues[npcManager.currentDialogueIndex].dialogueImage)
            {
                ImageTarget.sprite = npcManager.dialogues[npcManager.currentDialogueIndex].dialogueImage;
                var color = ImageTarget.color;
                color.a = 1f;
                ImageTarget.color = color;
            }
            else
            {
                ImageTarget.sprite = null;
                var color = ImageTarget.color;
                color.a = 0f;
                ImageTarget.color = color;
            }



            // 1. Show secondary dialogue if present
            if (npcManager.secondaryDialogue != null)
            {
                StartCoroutine(ShowSecondaryDialogue(npcManager.secondaryDialogue));
                //return;
            }

            // 2. Otherwise, check for multi-choice
            var dialogue = npcManager.dialogues[npcManager.currentDialogueIndex];
            if (dialogue.choices != null && dialogue.choices.Count > 0)
            {
                StartCoroutine(ShowMultiChoiceDialogue(dialogue, npcManager));
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

            if (isLastDialogue)
                NextButtontext.text = "End";
            else
                NextButtontext.text = "Next";

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

            yield return StartCoroutine(TypewriterEffect(dialogue.lines, content, characterDelay, punctuationDelay, maxWords));

            multiChoicePanel.SetActive(true);

            bool choiceMade = false;
            int chosenIndex = -1;

            // Setup choice buttons
            for (int i = 0; i < choiceButtons.Length; i++)
            {
                if (i < dialogue.choices.Count)
                {
                    choiceButtons[i].gameObject.SetActive(true);
                    int index = i;
                    choiceButtons[i].GetComponentInChildren<TMP_Text>().text = dialogue.choices[i].choiceText;
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

            multiChoicePanel.SetActive(false);

            var choice = dialogue.choices[chosenIndex];

            // GIVE PLAYER ITEM if flagged
            if (npc != null && choice.givesItem)
            {
                //Debug.Log("GiveItem");
                //Debug.Log("NPC passed: " + (npc == null ? "NULL" : npc.QuestObject.name));
                npc.GivePlayerItem();
            }
            //Debug.Log("after giveitem logic");

            // REMOVE PLAYER ITEM if flagged
            if (npc != null && choice.takesItem)
            {
                npc.RemovePlayerItem();
            }



            // 1. Show result text first, if you want
            if (!string.IsNullOrEmpty(choice.resultText))
            {
                yield return StartCoroutine(TypewriterEffect(choice.resultText, content, characterDelay, punctuationDelay, maxWords));
            }

            // 2. If the choice leads to another dialogue, start it!
            if (choice.nextDialogue != null)
            {
                yield return StartCoroutine(ShowMultiChoiceDialogue(choice.nextDialogue, npc));
                yield break;
            }

            // Otherwise, continue as before (end dialogue or advance)
            bool isLastDialogue = (npc.currentDialogueIndex == npc.dialogues.Count - 1);

            if (isLastDialogue)
                NextButtontext.text = "End";
            else
                NextButtontext.text = "Next";

            moveNextButt.SetActive(true);
            moveNext = false;
            yield return new WaitUntil(() => moveNext);
            moveNextButt.SetActive(false);
            secondaryChoicePanel.SetActive(false);

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