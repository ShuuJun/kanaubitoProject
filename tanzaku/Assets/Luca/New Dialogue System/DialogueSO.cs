using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[System.Serializable]
public class DialogueChoice
{
    public string choiceText;         // Text shown on the button
    public string resultText;         // Text to show after selection
    public UnityEvent onChoice;       // Assign functions in the inspector
}

[CreateAssetMenu(fileName = "DialogueSO", menuName = "Dialogue")]
public class DialogueSO : ScriptableObject
{
    public string title;
    public string lines;

    [Header("Choices (leave empty if none)")]
    public List<DialogueChoice> choices = new List<DialogueChoice>();

    [Header("Dialogue Image")]
    public Sprite dialogueImage;      // Assign in Inspector

    [Header("Time Based Position")]
    public Vector3 MorningPosition;
}
