using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;

    public AttributeToChange attributeToChange = new AttributeToChange();
    public int amountToChangeAttribute;

    public bool UseItem()
    {
        //if(statToChange == StatToChange.health)
        return false;
    }

    public enum StatToChange
    {
        none
    };
    public enum AttributeToChange
    {
        none
    };
}
