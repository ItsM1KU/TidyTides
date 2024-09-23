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
        if(StatToChange == statToChange.oxygen)
        {
            Ocean_PlayerH0 playerHO = GameObject.Find("Canvas").GetComponent<Ocean_PlayerH0>();
            playerHO.oxyTank();
        }
    }


    public enum statToChange
    {
        none,
        health,
        oxygen
    };
}
