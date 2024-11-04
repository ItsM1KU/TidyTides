using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuscript : MonoBehaviour
{
    [SerializeField] public AudioSource bgAudio;
    [SerializeField] TMP_Text soundOnText;
    //[SerializeField] TMP_Text soundOffText;

    private bool isPlaying;

    private void Start()
    {
        isPlaying = true;
    }

    public void Mute()
    {
        if (isPlaying)
        {
            bgAudio.Stop();
            soundOnText.text = "SOUND: ON";
            isPlaying = false;
        }
        else
        {
            bgAudio.Play();
            soundOnText.text = "SOUND: OFF";
            isPlaying = true;
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene("LandScene");
    }

    public void leaveGame()
    {
        Application.Quit();
        Debug.Log("Quitting...");
    }
}
