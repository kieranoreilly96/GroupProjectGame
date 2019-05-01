using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : MonoBehaviour {

    public int hits = 3;
    public bool IsDead = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        string tag = collision.gameObject.tag;

        if (tag == "Player")
            hits--;

        if (hits <= 0)
        {
            IsDead = true;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;

        if (tag == "Player")
            hits--;

        if (hits <= 0)
            IsDead = true;
    }
}
