using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopItem : MonoBehaviour
{
    [SerializeField] public string itemName;
    [SerializeField] public int amount;
    [SerializeField] public Sprite itemSprite;
    [SerializeField] public bool itemUsable;
    [SerializeField] public int cost;

    [TextArea]
    [SerializeField] public string itemDescription;


    [SerializeField] GameObject itemButton;
    private InventoryController inventoryController;
    private coinScript coinScript;

    private void Start()
    {
        inventoryController = GameObject.Find("InventoryCanvas").GetComponent<InventoryController>();
        coinScript = GameObject.Find("CoinCanvas").GetComponent<coinScript>();
    }

    public void buyItem()
    {
        if(coinScript.coins > cost)
        {
            coinScript.coins -= cost;
            coinScript.coinText.text = coinScript.coins.ToString();

            int leftOveritems = inventoryController.AddItem(itemName, amount, itemSprite, itemDescription, itemUsable);
            if (leftOveritems <= 0)
            {
                itemButton.SetActive(false);
            }
            else
            {
                amount = leftOveritems;
            }
        }
    }
}
