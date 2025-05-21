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

        public bool lastButton = false;

        private TMP_Text NextButtontext;

        public static bool IsDialogueActive { get; private set; }

        private void Awake()
        {
            NextButtontext = moveNextButt.GetComponentInChildren<TextMeshProUGUI>();
            instance = this;
            //TMP_Text NextButtontext = GetComponentInChildren<TextMeshProUGUI>();
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

        public void ShowDialogue(NPCManager nPCManager, bool choice)
        {
            IsDialogueActive = true;
            NextButtontext.text = "Next";
            hasPlayerMadeChoice = false;
            StartCoroutine(ShowDialogueC(nPCManager, choice));
        }

        IEnumerator ShowDialogueC(NPCManager nPCManager, bool choice)
        {
            bool isLastDialogue = (nPCManager.currentDialogueIndex == nPCManager.dialogues.Count - 1);

            title.text = nPCManager.dialogues[nPCManager.currentDialogueIndex].title;
            content.text = "";

            dialogueCanvas.enabled = true;

            foreach (char character in nPCManager.dialogues[nPCManager.currentDialogueIndex].lines)
            {
                content.text += character;
                yield return new WaitForSeconds(IsPunctuation(character) ? punctuationDelay : characterDelay);

                if (content.textInfo.wordCount >= maxWords && (character == ' ' || IsPunctuation(character) || character == ','))
                {
                    moveNextButt.SetActive(true);
                    yield return new WaitUntil(() => moveNext);

                    content.text = "";
                    moveNextButt.SetActive(false);
                    moveNext = false;
                }
            }

            // Now handle end-of-dialogue logic
            if (isLastDialogue)
            {
                lastButton = true;
                if (choice)
                {
                    choicePanel.SetActive(true);
                    moveNextButt.SetActive(false);
                }
                else
                {
                    choicePanel.SetActive(false);
                    NextButtontext.text = "End";
                    moveNextButt.SetActive(true);
                }
            }
            else
            {
                lastButton = false;
                choicePanel.SetActive(false);
                NextButtontext.text = "Next";
                moveNextButt.SetActive(true);
            }

            // Wait for input
            if (choice)
            {
                yield return new WaitUntil(() => playerMadeChoice());
                //Debug.Log("Choice");
                choicePanel.SetActive(false);
            }
            else
            {
                yield return new WaitUntil(() => moveNext);
            }

            content.text = "";
            moveNextButt.SetActive(false);
            moveNext = false;

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
    }

}