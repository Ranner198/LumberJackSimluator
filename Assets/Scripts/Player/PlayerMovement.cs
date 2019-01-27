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
    public Vector3 temp;
    public GameObject centerPoint;

    private Animator anim;

    void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
	}

    void FixedUpdate()
    {
        Vector3 newPos = transform.position;

        //Movement input
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 offset = Quaternion.Euler(0, centerPoint.transform.eulerAngles.y - 45, 0) * movement;
        //Apply Force to player
        rb.velocity = offset.normalized * Time.deltaTime * speed * 100;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, lm))
        {
            if (hit.transform.tag == "World")
            {
                //Look at the mouse position
                Vector3 rot = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                transform.LookAt(rot);

                //Going in reverse
                if (newPos.magnitude - temp.magnitude < rot.magnitude)
                    anim.SetFloat("Direction", -1);
                else
                    anim.SetFloat("Direction", 1);
            }
        }

        if (movement.magnitude > 0.1f)
            anim.Play("Walk");
        else
            anim.Play("Idle");

        temp = newPos;
    }
}
