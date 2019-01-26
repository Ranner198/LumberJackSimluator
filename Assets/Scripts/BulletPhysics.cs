using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPhysics : MonoBehaviour {

    private Rigidbody rb;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update () {
        rb.velocity = transform.forward * Time.deltaTime * 60 * speed; 
	}

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);   
    }
}
