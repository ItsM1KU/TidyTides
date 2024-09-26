using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopManager : MonoBehaviour
{
    [SerializeField] GameObject shopMenu;
    bool playerisclose;

    private void Awake()
    {
        shopMenu.SetActive(false);
    }
    private void Update()
    {
        if (playerisclose && Input.GetKeyDown(KeyCode.F))
        {
            shopMenu.SetActive(true);
        }
        else if (!playerisclose)
        {
            shopMenu.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerisclose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerisclose = false;
        }
    }
}
