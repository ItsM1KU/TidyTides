using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ocean_PlayerH0 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI OxyText;
    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] float oxygenLevel = 20f;
    [SerializeField] float healthLevel = 1.0f;


    private void Start()
    {
        StartCoroutine(Oxycoroutine(oxygenLevel));
    }

    IEnumerator Oxycoroutine(float oxy)
    {
        //float oxyleft = 20;
        while (oxy > 0)
        {
            oxy -= 0.5f;
            oxygenLevel -= 0.5f;
            yield return new WaitForSeconds(4f);
            //Debug.Log(oxy + " Left");
            //Debug.Log(oxygenLevel);
            OxyText.text = ("Oxygen Level: " + oxy.ToString() + " / 20");
        }
        StartCoroutine(healthRoutine(healthLevel));
    }

    IEnumerator healthRoutine(float hp)
    {
        while (hp > 0)
        {
            hp -= 0.5f;
            //Debug.Log(hp + " left!!");
            hpText.text = ("Health: " + hp.ToString() + " / 5");
            yield return new WaitForSeconds(3f);
        }
        Debug.Log("Player dies!!");
    }


}
