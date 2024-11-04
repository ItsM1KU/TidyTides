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
    [SerializeField] public int coinValue;

    [TextArea]
    [SerializeField] public string itemDescription;

    private bool playerisClose;
    private InventoryController inventoryController;

    private void Start()
    {
        inventoryController = GameObject.Find("InventoryCanvas").GetComponent<InventoryController>();   
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerisClose)
        {
            int leftOveritems = inventoryController.AddItem(itemName, amount, itemSprite, itemDescription, itemUsable, coinValue);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerisClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerisClose = false;
        }
    }
}
