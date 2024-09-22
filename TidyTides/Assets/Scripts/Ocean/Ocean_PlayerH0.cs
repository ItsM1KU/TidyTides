using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Ocean_PlayerH0 : MonoBehaviour
{
    [SerializeField] List<GameObject> healthSprites = new List<GameObject>();
    [SerializeField] List<GameObject> oxySprites = new List<GameObject>();

    private int i = 0;
    private int j = 0;
    private int healthCount = 5;
    private int oxyCount = 8;
    private void Start()
    {
        StartCoroutine(Oxycoroutine(oxyCount));
    }

    IEnumerator Oxycoroutine(int oxyCount)
    {
        while (oxyCount > 0)
        {            
            oxySprites[j].gameObject.SetActive(false);
            oxyCount--;
            j++;
            yield return new WaitForSeconds(10f);
        }
        StartCoroutine(healthRoutine(healthCount));
    }

    IEnumerator healthRoutine(int healthcount)
    {
        while (healthcount > 0)
        {
            healthSprites[i].gameObject.SetActive(false);
            healthcount--;
            i++;
            yield return new WaitForSeconds(5f);
        }
        Debug.Log("Player dies!!");
    }
}
