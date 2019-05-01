using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,//0
    Walking,//1
    Jumping,//2
    Attack//3
}

public class PlayerData : MonoBehaviour
{
    public PlayerState State = PlayerState.Idle;
    public PlayerState previousState;
    public bool Attack = false;
    AudioSource audio;
    public int enemiesToKill = 2;
    public int Gems = 0;
    Vector3 checkpointPosition;
    public int Deaths = 0;

    void Start()
    {
        checkpointPosition = transform.position;
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;

        if(Input.GetMouseButtonDown(0))
        {
            Attack = true;
        }
        if (tag == "Fists" && State ==PlayerState.Attack)
        {
            Destroy(collision.gameObject);
            enemiesToKill--;
        }

        if(tag== "Fists"&& State != PlayerState.Attack)
        {
            TeleportToCheckpoint();
            Deaths++;
        }


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
