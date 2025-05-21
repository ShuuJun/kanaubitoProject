using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace RedstoneinventeGameStudio
{
    [CreateAssetMenu(fileName = "NPCDialogueSO", menuName = "Simple Dialogue System/NPC Dialogue")]
    public class NPCDialogueSO : ScriptableObject
    {
        public string title;
        public string lines;
        public bool choice;
        public string choice1;
        public string choice2;

        [Header ("Time Based Position")]
        public Vector3 MorningPosition;
    }
}