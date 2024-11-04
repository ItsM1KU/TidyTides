using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] public float timeRemaining;
    [SerializeField] TMP_Text timerText;

    public bool timerOver;

    private void Start()
    {
        timerOver = false;    
    }


    private void Update()
    {
        if (!timerOver)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;

                int minutes = Mathf.FloorToInt(timeRemaining / 60);
                int seconds = Mathf.FloorToInt(timeRemaining % 60);

                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else
            {
                timerOver = true;
                timerText.text = "00:00";
                timerText.color = Color.red;
            }
        }
        
    }

    public void AddTime(float amount)
    {
        timeRemaining += amount;
        timerOver = false;
        timerText.color = Color.white;
    }
}
