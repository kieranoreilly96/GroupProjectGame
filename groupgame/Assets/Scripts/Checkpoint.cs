using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Sprite ActiveSprite;
    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //if hit by the player, change the sprite
        if(collision.gameObject.tag == "Player")
        {
            sprite.sprite = ActiveSprite;
        }
    }
}
