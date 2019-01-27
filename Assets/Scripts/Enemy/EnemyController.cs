using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {


    public float speed = 8;
    public int health = 100;
    public float raycastLength = 6;
    public float offsetRaycastHeight = 4.5f;
    public float attackCoolDown = 3;
    public float knockBackAmount = 4;
    public float knockBackTime = 4;

    private GameObject house;
    private Vector3 SpawnPoint;
    [HideInInspector]
    public Rigidbody rb;
    private float attackTimer;
    [HideInInspector]
    public bool knockback = false;
    private float knockbackTimer;

    private Animator anim;

    public EnemyClass enemy;

    void Awake()
    {
        enemy = new EnemyClass(health, SpawnPoint);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        house = GameObject.FindGameObjectWithTag("House");        
        attackTimer = attackCoolDown;
        knockbackTimer = knockBackTime;
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        transform.LookAt(house.transform.position);

        Vector3 raycastPostion = transform.position;
        raycastPostion.y = offsetRaycastHeight;

        RaycastHit hit;

        if (Physics.Raycast(raycastPostion, transform.forward, out hit, raycastLength))
        {
            if (hit.transform.tag == "House" || hit.transform.tag == "Tree" || hit.transform.tag == "Fence")
            {
                //PlayAttack Animation
                if (attackTimer >= 0)
                    attackTimer -= Time.deltaTime;
                if (attackTimer < 0)
                {
                    StartAttacking(hit.transform.gameObject);
                    attackTimer = attackCoolDown;
                }

                anim.Play("AttackAnimation");

                //Look at the mouse position
                rb.velocity = Vector3.zero;
            }
            else
                anim.Play("IdleAnim");
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

            if (rb.velocity.magnitude > 2)
                anim.Play("Walk");
            else
                anim.Play("Idle");
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
            target.GetComponent<TreeHealth>().TakeDamage(25, gameObject);
        if (target.tag == "Fence")
            target.GetComponent<FenceHealth>().TakeDamage(17, gameObject);
    }
}
