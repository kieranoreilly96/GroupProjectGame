using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{

    public Slider healthSlider;
    public Text timeText;

    private Health healthComponent;
    private float timePassed;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        healthComponent = player.GetComponent<Health>();

        healthSlider.maxValue = healthComponent.maxHealth;
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        timeText.text = "Time Passed: " + (int)timePassed;

        healthSlider.value = healthComponent.currentHealth;
    }
}
