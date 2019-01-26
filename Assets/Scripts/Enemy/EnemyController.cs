using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed = 2.5f;
    public int health = 100;
    public float raycastLength = 3;
    public float offsetRaycastHeight = 2;
    public float attackCoolDown = 3;
    public float knockBackAmount = 2;
    public float knockBackTime = 1.5f;    

    private GameObject house;
    private Vector3 SpawnPoint;
    private Rigidbody rb;
    private float attackTimer;

    private bool knockback = false;
    private float knockbackTimer;

    EnemyClass enemy;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        house = GameObject.FindGameObjectWithTag("House");
        enemy = new EnemyClass(health, SpawnPoint);
        attackTimer = attackCoolDown;
        knockbackTimer = knockBackTime;
    }

    void Update()
    {
        Vector3 raycastPostion = transform.position;
        raycastPostion.y = offsetRaycastHeight;

        RaycastHit hit;

        if (Physics.Raycast(raycastPostion, transform.forward, out hit, raycastLength))
        {
            if (hit.transform.tag == "House" || hit.transform.tag == "Tree")
            {
                //PlayAttack Animation
                if (attackTimer >= 0)
                    attackTimer -= Time.deltaTime;
                if (attackTimer < 0)
                {
                    StartAttacking(hit.transform.gameObject);
                    attackTimer = attackCoolDown;
                }

                //Look at the mouse position
                rb.velocity = Vector3.zero;
            }
            else if (hit.transform.tag == "Rock")
            {
            }
           //Draw the ray
        }
        else
        {
            //Fix look direction
            if (!knockback)
            {
                Vector3 tempHolder = house.transform.position;
                tempHolder.y = transform.position.y;
                transform.LookAt(tempHolder);
                rb.velocity = GetDirection(house.transform.position).normalized * Time.deltaTime * speed * 100;
            }
            else
            {
                if (knockbackTimer >= 0)
                    knockbackTimer -= Time.deltaTime;
                if (knockbackTimer < 0)
                {
                    knockback = false;
                    knockbackTimer = knockBackTime;
                }
            }
        }

        Debug.DrawRay(raycastPostion, transform.forward * raycastLength, Color.red);


        if (enemy.GetHealth() <= 0)
        {
            Destroy(gameObject);
        }
    }

    Vector3 GetDirection(Vector3 target)
    {
        Vector3 temp = target - transform.position;
        temp.y = transform.position.y;
        return temp;
    }

    void StartAttacking(GameObject target) {
        if (target.tag == "House")
            target.GetComponent<HouseHealth>().TakeDamage(5);
        if (target.tag == "Tree")
            target.GetComponent<TreeHealth>().TakeDamage(25);
    }

    void TakeDamage(int val) {
        enemy.TakeDamage(50);        
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            TakeDamage(50);
            knockback = true;
            rb.AddForce((coll.gameObject.transform.position - transform.position).normalized * knockBackAmount, ForceMode.Impulse);
        }
    }
}
