using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Timer timer;

    [SerializeField] GameObject mobSpawner;
    void Start()
    {
        timer = GameObject.Find("Canvas").GetComponent<Timer>();
        //timer = GetComponent<Timer>();
        StartCoroutine(checkTime());
    }

    IEnumerator checkTime()
    {
        yield return new WaitUntil( () => timer.timerOver);

        StartCoroutine(EnemySpawner());
    }

    IEnumerator EnemySpawner()
    {
        while(timer.timerOver == true)
        {
            Debug.Log("It works");
            Instantiate(mobSpawner, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(30);
        }
    }

}
