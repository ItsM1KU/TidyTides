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

        if(coins + amount > MaxCoins)
        {
            coins = MaxCoins; // Cap the coins to MaxCoins
            Debug.Log("Max coins reached");
        }
        else
        {
            coins += amount; // Add the coins
        }

        // Update the coin text UI after coins are added or capped
        coinText.text = coins.ToString();
    }
}
