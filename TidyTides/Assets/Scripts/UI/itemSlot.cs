using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class itemSlot : MonoBehaviour, IPointerClickHandler
{
    //======Item Data======\\
    public string itemName;
    public int quantity;
    private Sprite itemSprite;
    private string itemDescription;
    private bool itemUsable;
    public bool isFull;
    [SerializeField] private int maxItems;

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


    [SerializeField] Sprite emptySprite;
    private void Start()
    {
        inventoryController = GameObject.Find("InventoryCanvas").GetComponent<InventoryController>();
    }

    public int Additem(string itemName, int quantity, Sprite itemSprite, string itemDescription, bool itemUsable)
    {
        if (isFull)
        {
            return quantity;
        }

        this.itemName = itemName;
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;
        this.itemDescription = itemDescription;
        this.itemUsable = itemUsable;



        this.quantity += quantity;
        if (this.quantity >= maxItems)
        {
            itemText.text = maxItems.ToString();
            itemText.enabled = true;
            isFull = true;

            int extraItems = this.quantity - maxItems;
            this.quantity = maxItems;
            return extraItems;
        }

        itemText.text = this.quantity.ToString();
        itemText.enabled = true;
        return 0;
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
        if (slotIsSelected && this.itemUsable)
        {
            inventoryController.useItem(itemName);
            this.quantity -= 1;
            itemText.text = this.quantity.ToString();
            isFull = false;
            if (this.quantity <= 0)
            {
                emptySlot();
            }
        }
        else
        {
            inventoryController.DeselectSlots();
            SelectedPanel.SetActive(true);
            slotIsSelected = true;

            itemDescImage.sprite = itemSprite;
            itemDescTitle.text = itemName;
            itemDesc.text = itemDescription;
        }
    }

    private void emptySlot()
    {
        itemText.enabled = false;
        itemImage.sprite = emptySprite;
        itemDescription = "";
        itemName = "";
        itemDescImage.sprite = emptySprite;
        itemDescTitle.text = itemName;
        itemDesc.text = itemDescription;
    }

    public void onRightClick()
    {
        GameObject itemToDrop = new GameObject(itemName);
        Item newItem = itemToDrop.AddComponent<Item>();
        floatingObjects floatingobjects = itemToDrop.AddComponent<floatingObjects>();
        newItem.itemName = itemName;
        newItem.amount = 1;
        newItem.itemSprite = itemSprite;
        newItem.itemUsable = itemUsable;
        newItem.itemDescription = itemDescription;

        SpriteRenderer sr = itemToDrop.AddComponent<SpriteRenderer>();
        sr.sprite = itemSprite;
        sr.sortingLayerName = "Props";

        BoxCollider2D bc = itemToDrop.AddComponent<BoxCollider2D>();
        bc.isTrigger = true;
        Rigidbody2D rb = itemToDrop.AddComponent <Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;

        itemToDrop.transform.position = GameObject.Find("Player").transform.position + new Vector3(1, 0, 0);
        itemToDrop.transform.localScale = new Vector3(1f, 1f, 1f);

        this.quantity -= 1;
        itemText.text = this.quantity.ToString();
        isFull = false;
        if (this.quantity <= 0)
        {
            emptySlot();
        }
    }
}
