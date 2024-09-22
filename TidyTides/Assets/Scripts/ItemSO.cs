using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;

    public statToChange StatToChange = new statToChange();

    public void useItem()
    {
        if(StatToChange == statToChange.none)
        {
            Debug.Log("You cant use this item!!");
        }
    }


    public enum statToChange
    {
        none,
        health,
        oxygen
    };
}
