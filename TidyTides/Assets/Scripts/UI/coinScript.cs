using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coinScript : MonoBehaviour
{
    [SerializeField] public TMP_Text coinText;
    [SerializeField] int MaxCoins;
    public int coins;
    
    private void Start()
    {
        //coinText.text = "";
        coinText.text = coins.ToString();
    }

    public void AddCoins(int amount)
    {
        
        if(coins > MaxCoins)
        {
            Debug.Log("You can have anymore coins");
        }
        else
        {
            coins += amount;
            coinText.text = coins.ToString();
        }
    }
}
