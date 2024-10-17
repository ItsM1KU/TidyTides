using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class shopItem : MonoBehaviour
{
    [SerializeField] public string itemName;
    [SerializeField] public int amount;
    [SerializeField] public int shopQuant;
    [SerializeField] public Sprite itemSprite;
    [SerializeField] public bool itemUsable;
    [SerializeField] public int cost;

    [TextArea]
    [SerializeField] public string itemDescription;


    [SerializeField] GameObject itemButton;
    [SerializeField] GameObject cantBuyButton;
    private InventoryController inventoryController;
    private coinScript coinScript;

    [SerializeField] TMP_Text quantText;

    private void Start()
    {
        inventoryController = GameObject.Find("InventoryCanvas").GetComponent<InventoryController>();
        coinScript = GameObject.Find("CoinCanvas").GetComponent<coinScript>();
        quantText.text = shopQuant.ToString();
    }

    private void Update()
    {
        if (coinScript.coins < cost || shopQuant < 0)
        {
            itemButton.SetActive(false);
            cantBuyButton.SetActive(true);
        }

        else if (coinScript.coins >= cost && shopQuant > 0)
        {
                cantBuyButton.SetActive(false);
                itemButton.SetActive(true);
        }
    }

    public void buyItem()
    {
        if(coinScript.coins >= cost && shopQuant > 0)
        {

            coinScript.coins -= cost;
            coinScript.coinText.text = coinScript.coins.ToString();

            inventoryController.AddItem(itemName, amount, itemSprite, itemDescription, itemUsable);

            shopQuant--;
            quantText.text = shopQuant.ToString();
        }
    }
}
