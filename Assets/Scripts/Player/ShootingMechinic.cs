using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMechinic : MonoBehaviour {

    public GameObject bullet;

	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject Bullet = Instantiate(bullet, transform.position + transform.forward, transform.rotation);
            Destroy(Bullet, 6f);
        }     
	}
}
