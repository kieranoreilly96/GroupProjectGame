using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    PlayerData data;
    PlayerMovement movement;
    Animator animator;
    SpriteRenderer sprite;

    void Start()
    {
        data = GetComponent<PlayerData>();
        movement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //only update animation when the player state has changed
        if(data.State != data.previousState)
        {
            animator.SetInteger("State", (int)data.State);
            data.previousState = data.State;
        }

        if(movement.horizontal > 0)//right
        {
            sprite.flipX = false;
        }
        else if(movement.horizontal < 0)//left
        {
            sprite.flipX = true;
        }
    }
}
