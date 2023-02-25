using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        if (CharacterMovement.isMoving)
        {
            transform.position = new Vector3(transform.position.x, player.position.y + 7f, player.position.z + 1f);
        }
    }
}
