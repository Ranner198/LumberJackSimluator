using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    public Color damageColor;
    public Color[] defaultTint;
    public int flashCount = 6;
    public float interval = 0.4f;

    private EnemyController Controller;

    void Start()
    {
        Controller = gameObject.GetComponent<EnemyController>();
        defaultTint = new Color[gameObject.GetComponent<Renderer>().materials.Length];
        var count = 0;        
        foreach (Material mat in gameObject.GetComponent<Renderer>().materials)
        {
            defaultTint[count] = mat.color;
            count++;
        }
    }

    void TakeDamage(int val)
    {
        Controller.enemy.TakeDamage(50);
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            TakeDamage(50);
            Controller.knockback = true;
            Controller.rb.AddForce((coll.gameObject.transform.position - transform.position).normalized * Controller.knockBackAmount, ForceMode.Impulse);

            StartCoroutine(Flash(flashCount));
        }
    }

    IEnumerator Flash(int flashCount)
    {
        int flashCounter = 0;
        while (flashCounter < flashCount)
        {
            foreach (Material mat in gameObject.GetComponent<Renderer>().materials)
            {
                mat.color = damageColor;
            }

            yield return new WaitForSeconds(interval);

            var count = 0;
            foreach (Material mat in gameObject.GetComponent<Renderer>().materials)
            {
                mat.color = defaultTint[count];
                count++;
            }

            yield return new WaitForSeconds(interval);

            flashCounter++;            
        }
    }

}
