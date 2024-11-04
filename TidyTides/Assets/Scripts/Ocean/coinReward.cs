using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinReward : MonoBehaviour
{
    [SerializeField] public int rewardValue;

    [SerializeField] private coinScript coinScript;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            coinScript.AddCoins(rewardValue);
            Destroy(this.gameObject);
        }
    }
}
