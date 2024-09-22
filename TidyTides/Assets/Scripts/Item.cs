using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour 
{
    [SerializeField] public string itemName;
    [SerializeField] public int amount;
    [SerializeField] public Sprite itemSprite;
    [SerializeField] public bool itemUsable;

    [TextArea]
    [SerializeField] public string itemDescription;

    private InventoryController inventoryController;

    private void Start()
    {
        inventoryController = GameObject.Find("InventoryCanvas").GetComponent<InventoryController>();   
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            int leftOveritems = inventoryController.AddItem(itemName, amount, itemSprite, itemDescription, itemUsable);
            if (leftOveritems <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                amount = leftOveritems;
            }

        }
    }
}
