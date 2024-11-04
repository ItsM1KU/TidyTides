using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] GameObject InventoryUi;

    bool invActive;

    public itemSlot[] itemslot;

    public ItemSO[] itemSOs;

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && invActive)
        {
            InventoryUi.SetActive(false);
            invActive = false;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && !invActive)
        {
            InventoryUi.SetActive(true);
            invActive = true;
        }
    }

    public void useItem(string itemName)
    {
        for (int i = 0; i < itemSOs.Length; i++)
        {
            if (itemSOs[i].itemName == itemName) 
            {
                itemSOs[i].useItem();
            }
        }
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription, bool itemUsable, int coinValue)
    {
        for(int i = 0; i < itemslot.Length; i++)
        {
            if (!itemslot[i].isFull && itemslot[i].itemName == itemName || itemslot[i].quantity == 0)
            {
                int itemLeftOvers = itemslot[i].Additem(itemName, quantity, itemSprite, itemDescription, itemUsable, coinValue);

                if (itemLeftOvers > 0)
                {
                    itemLeftOvers = AddItem(itemName, itemLeftOvers, itemSprite, itemDescription, itemUsable, coinValue);
                }

                return itemLeftOvers;
            }
        }
        return quantity;
    }

    public void DeselectSlots()
    {
        for (int i = 0;i < itemslot.Length;i++)
        {
            itemslot[i].SelectedPanel.SetActive(false);
            itemslot[i].slotIsSelected = false;
        }
    }
}
