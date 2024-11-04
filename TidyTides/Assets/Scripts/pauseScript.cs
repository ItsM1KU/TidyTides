using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class pauseScript : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] public AudioSource bgAudio;
    [SerializeField] TMP_Text soundOnText;

    private bool isPlaying;
    private void Start()
    {
        isPlaying = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
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


    public void continueButton()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void mainmenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
