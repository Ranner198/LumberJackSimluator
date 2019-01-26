using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody rb;
    private Vector3 mousePos;
    private Vector3 movement;

    public float topSpeed;
    public float speed = 6;
    public LayerMask lm;

    void Start () {
        rb = GetComponent<Rigidbody>();
	}

    void Update()
    {
        //Movement input
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //Apply Force to player
        rb.velocity = movement.normalized * Time.deltaTime * speed * 100;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, lm))
        {
            if (hit.transform.tag == "World")
            {
                //Look at the mouse position
                Vector3 rot = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                transform.LookAt(rot);
            }
        }
    }
}
