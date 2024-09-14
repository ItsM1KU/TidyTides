using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    [SerializeField] GameObject dialogPanel;
    [SerializeField] TextMeshProUGUI dialogText;
    [SerializeField] float textSpeed = 0.08f;
    [SerializeField] string[] dialogues;
    private bool playerisClose;
    private int index = 0;

    private void Start()
    {
        dialogText.text = "";
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerisClose)
        {
            if (!dialogPanel.activeInHierarchy)
            {
                dialogPanel.SetActive(true);
                StartCoroutine(typing());
            }
            else if(dialogText.text == dialogues[index])
            {
                nextline();
            }
            
        }

        if(Input.GetKeyDown(KeyCode.Q) && dialogPanel.activeInHierarchy)
        {
            closeDialog();
        }
    }

    private void nextline()
    {
        if(index < dialogues.Length - 1)
        {
            index++;
            dialogText.text = "";
            StartCoroutine(typing());
        }
        else
        {
            closeDialog();
        }
    }

    private void closeDialog()
    {
        dialogText.text = "";
        dialogPanel.SetActive(false);
        index = 0;
    }

    IEnumerator typing()
    {
        foreach(char letter in dialogues[index].ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerisClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            closeDialog();
            playerisClose = false;  
        }
    }
}
