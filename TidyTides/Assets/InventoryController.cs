using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] GameObject InventoryUi;

    bool invActive;

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

    public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        Debug.Log(itemName);
    }
}
