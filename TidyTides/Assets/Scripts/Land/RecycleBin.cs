using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleBin : MonoBehaviour
{
    private List<GameObject> trash = new List<GameObject>();

    coinScript coinScript;

    private void Start()
    {
        coinScript = GameObject.Find("CoinCanvas").GetComponent<coinScript>();    
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Garbage")
        {
            Destroy(collision.gameObject);
            coinScript.AddCoins(5);
        }
    }
}
