using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class boss_dies : MonoBehaviour
{

    // Number of enemies alive
    private static int aliveCounter = 0;

    void Start()
    {
        aliveCounter++;
    }

    void OnKilled()
    {
        aliveCounter--;

        if (aliveCounter == 0)
            UnityEngine.SceneManagement.SceneManager.LoadScene("The_End");
    }
}
