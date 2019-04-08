using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,//0
    Walking,//1
    Jumping,//2
    Crouch//3
}

public class PlayerData : MonoBehaviour
{
    public PlayerState State = PlayerState.Idle;
    public PlayerState previousState;
    AudioSource audio;
    public int Gems = 0;
    Vector3 checkpointPosition;

    void Start()
    {
        checkpointPosition = transform.position;
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;

        if(tag == "Gem")
        {
            Gems++;
            Destroy(collision.gameObject);
        }
        else if(tag == "Checkpoint")
        {
            checkpointPosition = collision.gameObject.transform.position;
        }
        else if(tag=="bossTrigger")
        {
            if(!audio.isPlaying)
            {
                audio.Play();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        if(tag == "Kill")
        {
            TeleportToCheckpoint();
        }
    }

    public void TeleportToCheckpoint()
    {
        transform.position = checkpointPosition;
    }
}
