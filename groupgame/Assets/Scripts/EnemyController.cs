using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5;

	// Use this for initialization
	void Start ()
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();

        //vector2(x,y)
        //x=horizontal axis, y = vertical axis
        body.velocity = new Vector2(0, speed) * -1;
	}
    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Kill")
        {
            //destroy ourselves
            Destroy(gameObject);
        }
    }
}
