using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    public float horizontal, vertical;
    Vector2 customVelocity;
    PlayerData data;

    public GameObject Boss;
    public float GrappleRange = 10;
    public float GrappleForce = 10;
    bool canGrapple = true;
    bool canMove = true;
    int frameCount = 0;
    public int blockForFrames = 20;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        data = GetComponent<PlayerData>();
    }

    void Update()
    {
        if(!canMove)
        {
            frameCount++;
            if (frameCount >= blockForFrames)
            {
                canMove = true;
                frameCount = 0;
            }
        }

        if (Input.GetMouseButton(1) && canGrapple)
        {
            if (Vector2.Distance(transform.position, Boss.transform.position) <= GrappleRange)
            {
                Vector3 direction = (Boss.transform.position - transform.position).normalized;
                body.AddForce(direction * GrappleForce, ForceMode2D.Impulse);

                canGrapple = false;
                Invoke("RestoreGrapple", 2);
                canMove = false;
            }
        }

        
        //get input
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (canMove)
        {
            //setup customVelocity
            customVelocity.x = horizontal * movementSpeed;
            customVelocity.y = body.velocity.y;

            //apply customVelocity
            body.velocity = customVelocity;
        }

        //check for input jump, dash
        if(Input.GetKeyDown(KeyCode.Space) && isOnJumpingSurface)
        {
            Jump();//player is jumping
            data.State = PlayerState.Jumping;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Dash(horizontal);//player is dashing
            data.State = PlayerState.Attack;
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

    void RestoreGrapple()
    {
        canGrapple = true;
    }
}
