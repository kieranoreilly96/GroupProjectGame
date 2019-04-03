using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    public float horizontal, vertical;
    Vector2 customVelocity;
    PlayerData data;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        data = GetComponent<PlayerData>();
    }

    void Update()
    {
        //get input
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        //setup customVelocity
        customVelocity.x = horizontal * movementSpeed;
        customVelocity.y = body.velocity.y;

        //apply customVelocity
        body.velocity = customVelocity;

        //check for input jump, dash
        if(Input.GetKeyDown(KeyCode.Space) && isOnJumpingSurface)
        {
            Jump();//player is jumping
            data.State = PlayerState.Jumping;
        }

        if (Input.GetMouseButtonDown(1))
        {
            Dash(horizontal);//player is dashing
            data.State = PlayerState.Crouch;
        }

        if(horizontal != 0)
        {
            data.State = PlayerState.Walking;
        }

        if(!Input.anyKey)//if no key was pressed, player is idle
        {
            //idle state
            data.State = PlayerState.Idle;
        }
    }
}
