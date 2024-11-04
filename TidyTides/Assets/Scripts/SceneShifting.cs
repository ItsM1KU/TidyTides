using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneShifting : MonoBehaviour
{

    void Awake()
    {
        // Find all AudioListeners in the scene
        AudioListener[] listeners = FindObjectsOfType<AudioListener>();

        // If there are more than one, disable the extra ones
        if (listeners.Length > 1)
        {
            for (int i = 1; i < listeners.Length; i++)
            {
                Destroy(listeners[i]); // or listeners[i].enabled = false;
            }
        }
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Shark")
        {
            Destroy(collision.gameObject);

            PauseScene();
        }
    }

    void PauseScene()
    {
        Scene OceanScene = SceneManager.GetSceneByName("OceanScene");
        if (OceanScene.IsValid())
        {
            foreach (GameObject obj in OceanScene.GetRootGameObjects())
            {
                obj.SetActive(false);
            }
        }
        changeScene();
    }

    void changeScene()
    {
        SceneManager.LoadScene("BattleScene", LoadSceneMode.Additive);
    }
}
