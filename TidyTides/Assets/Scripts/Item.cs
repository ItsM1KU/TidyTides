using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour 
{
    [SerializeField] private string itemName;
    [SerializeField] private int amount;
    [SerializeField] Sprite itemSprite;

    private InventoryController inventoryController;

    private void Start()
    {
        inventoryController = GameObject.Find("InventoryCanvas").GetComponent<InventoryController>();   
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            inventoryController.AddItem(itemName, amount, itemSprite);
            Destroy(gameObject);
        }
    }
}
