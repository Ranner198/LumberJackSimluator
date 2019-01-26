using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player;    
    public float distanceFromPlayer = 7f;
    public float speed = 0.3f;

    private Vector3 velocity;

    void LateUpdate () {
        Vector3 newPos = new Vector3(player.transform.position.x + distanceFromPlayer, distanceFromPlayer, player.transform.position.z - distanceFromPlayer);
        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, speed);
	}
}
