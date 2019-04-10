using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ObjectToBeSpawned;//filled in through unity

    public float spawnTime = 2;//seconds to wait to spawn an object
    float elapsedTime = 0;//track time passed
    

    BoxCollider2D spawnArea;//box where we can spawn asteroids


	// Use this for initialization
	void Start ()
    {
        spawnArea = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //add 16ms seconds to elapsedTime
        elapsedTime += Time.deltaTime;

        if(elapsedTime>=spawnTime)
        {
            SpawnObject();
            elapsedTime = 0;
        }
        
	}
    //pick random position on the x axis of the spawn area
    Vector3 PickPosition()
    {
        float minX = spawnArea.bounds.min.x;
        float maxX = spawnArea.bounds.max.x;
        //pick random location between minX and MaxX
        float randomX = Random.Range(minX, maxX);
        //return random position
        //x=randomx, y = position of the spawner
        return new Vector3(randomX, transform.position.y);
    }
    void SpawnObject()
    {
        Instantiate(ObjectToBeSpawned, PickPosition(), Quaternion.identity);
    }
 
}
