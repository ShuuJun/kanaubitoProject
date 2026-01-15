using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestDataSO", menuName = "QuestDataSO")]
public class questData : ScriptableObject
{
    public string questName;
    public string questRequester;
    public string questDestination;
    public string questDetails;
    public bool questCompleteChecksum = false;
}