using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPage : MonoBehaviour
{
    [SerializeField] private InventoryItem itemPrefab;

    [SerializeField] private GameObject inventoryUI;

     private List <InventoryItem> listofUiItems = new List<InventoryItem> ();
    private void InitializeInventory(int inventorySize)
    {
        for(int i = 0; i < inventorySize; i++)
        {

        }
    }


}
