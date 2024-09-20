using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] GameObject InventoryUi;

    bool invActive;

    public itemSlot[] itemslot;

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

    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        for(int i = 0; i < itemslot.Length; i++)
        {
            if (!itemslot[i].isFull)
            {
                itemslot[i].Additem(itemName, quantity, itemSprite, itemDescription);
                return;
            }
        }
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
