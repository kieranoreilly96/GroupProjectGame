using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    public GameObject pauseScreen;
    public void Pause()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void UnPause()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Exit()
    {
        Application.Quit();
    }
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.P))
        {
            Pause();
        }
    }
}
