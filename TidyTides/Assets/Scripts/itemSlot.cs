using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class itemSlot : MonoBehaviour, IPointerClickHandler
{
    //======Item Data======\\
    private string itemName;
    private int quantity;
    private Sprite itemSprite;
    private string itemDescription;
    public bool isFull;

    //======Item Slots======\\
    [SerializeField] Image itemImage;
    [SerializeField] TMP_Text itemText;
    [SerializeField] public GameObject SelectedPanel;
    public bool slotIsSelected;

    private InventoryController inventoryController;

    //======Item Description=====\\
    [SerializeField] Image itemDescImage;
    [SerializeField] TMP_Text itemDescTitle;
    [SerializeField] TMP_Text itemDesc;

    private void Start()
    {
        inventoryController = GameObject.Find("InventoryCanvas").GetComponent<InventoryController>();
    }

    public void Additem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        this.itemName = itemName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;
        this.itemDescription = itemDescription;
        isFull = true;

        itemText.text = quantity.ToString();
        itemText.enabled = true;
        itemImage.sprite = itemSprite;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            onLeftClick();
        }

        if(eventData.button == PointerEventData.InputButton.Right)
        {
            onRightClick();
        }
    }

    public void onLeftClick()
    {
        inventoryController.DeselectSlots();
        SelectedPanel.SetActive(true);
        slotIsSelected = true;

        itemDescImage.sprite = itemSprite;
        itemDescTitle.text = itemName;
        itemDesc.text = itemDescription;
    }

    public void onRightClick()
    {

    }
}
