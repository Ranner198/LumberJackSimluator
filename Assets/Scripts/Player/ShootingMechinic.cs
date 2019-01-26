using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMechinic : MonoBehaviour {

    public GameObject bullet;

    public float timer;
    private float _timer;

	void Update () {

        if (_timer >= 0)
            _timer -= Time.deltaTime;
        else
        {
            if (Input.GetMouseButtonDown(0))
            {               
                GameObject Bullet = Instantiate(bullet, transform.position + transform.forward * 3, transform.rotation);
                Destroy(Bullet, 6f);
                _timer = timer;
            }
        }
	}
}
