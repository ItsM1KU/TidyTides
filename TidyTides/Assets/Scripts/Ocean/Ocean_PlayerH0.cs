using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Ocean_PlayerH0 : MonoBehaviour
{
    [SerializeField] List<GameObject> healthSprites = new List<GameObject>();
    [SerializeField] List<GameObject> oxySprites = new List<GameObject>();

    [SerializeField] GameObject oxyprefab;



    private void Start()
    {
        StartCoroutine(Oxycoroutine());
    }

    IEnumerator Oxycoroutine()
    {
        while (oxySprites.Count > 0)
        {
            Destroy(oxySprites[oxySprites.Count - 1].gameObject);
            oxySprites.RemoveAt(oxySprites.Count - 1);
            yield return new WaitForSeconds(10f);
        }
        StartCoroutine(healthRoutine());
    }

    IEnumerator healthRoutine()
    {
        while (healthSprites.Count > 0)
        {
            Destroy(healthSprites[healthSprites.Count - 1].gameObject);
            healthSprites.RemoveAt(healthSprites.Count - 1);
            yield return new WaitForSeconds(5f);
        }
        Debug.Log("Player dies!!");
    }

    public void oxyTank()
    {
        if (oxySprites.Count < 10)
        {

            GameObject newoxySprite = Instantiate(oxyprefab);

            newoxySprite.transform.SetParent(oxySprites[0].gameObject.transform.parent);
            newoxySprite.transform.localScale = new Vector3(0.808f, 0.808f, 0.808f);
            newoxySprite.SetActive(true);

            if (oxySprites.Count > 0)
            {
                RectTransform lastbubbleRect = oxySprites[oxySprites.Count - 1].GetComponent<RectTransform>();
                RectTransform newbubbleRect = newoxySprite.GetComponent<RectTransform>();

                Vector3 newposition = lastbubbleRect.localPosition;
                newposition.x += lastbubbleRect.rect.width + 2f;
                newbubbleRect.localPosition = newposition;
            }

            oxySprites.Add(newoxySprite);
        }
        
    }
}
