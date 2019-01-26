using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player;

    public float distanceFromPlayer = 7f;

	void LateUpdate () {
        transform.position = new Vector3(player.transform.position.x + distanceFromPlayer, distanceFromPlayer, player.transform.position.z - distanceFromPlayer);
	}
}
