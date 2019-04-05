using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject PlayerToFollow;
    private Vector3 tempPosition;
    public Vector3 Offset;

    void Update()
    {
        tempPosition.x = PlayerToFollow.transform.position.x;
        tempPosition.y = transform.position.y;
        tempPosition.z = PlayerToFollow.transform.position.z;

        transform.position = tempPosition + Offset;
    }
}
