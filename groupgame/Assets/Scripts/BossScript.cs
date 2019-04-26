using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    Idle,
    HandSmash
}
public class BossScript : MonoBehaviour
{
    public Vector2 direction = new Vector2(1, 0);
    public float speed = 3;

    Rigidbody2D body;

    public BossState State = BossState.Idle;
    Animator animator;
	// Use this for initialization
	void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        Invoke("SwitchState", 5);
	}
	
	// Update is called once per frame
	void Update ()
    {
        body.velocity = direction * speed;

        animator.SetInteger("State", (int)State);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Bounce")
        {
            direction *= -1;
        }
    }

    public void SwitchState()
    {
        int numberOfStates= Enum.GetValues(typeof(BossState)).Length;
        int currentState = (int)State;
        currentState++;

        if(currentState>=numberOfStates)
        {
            currentState = 0;
        }

        State = (BossState)currentState;
        Invoke("SwitchState", 5);
    }
    public void TakeDamage(int damage)
    {
        //health -= damage;
        Debug.Log("damage TAKEN !");
    }
}
