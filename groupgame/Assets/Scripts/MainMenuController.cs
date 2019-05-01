using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour {

    public void LoadScene(string levelName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Kierans_Scene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
