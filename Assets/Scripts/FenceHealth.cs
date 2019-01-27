using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceHealth : MonoBehaviour
{

    public int Health = 100;
    public int flashCount = 6;
    public float interval = 0.4f;
    public Color DamageColor;
    public Color[] defaultTint;

    public HealthBar hb;

    public void TakeDamage(int val, GameObject tag)
    {

        Health -= val;
        hb.SetHealth(Health);

        if (Health <= 0)
        {
            Destroy(gameObject);
        }

        StartCoroutine(Flash(flashCount, tag));
    }

    public int GetHealth()
    {
        return this.Health;
    }

    void Start()
    {
        hb.SetHealth(Health);
        defaultTint = new Color[gameObject.transform.GetChild(0).GetComponent<Renderer>().materials.Length];
        var count = 0;
        foreach (Material mat in gameObject.transform.GetChild(0).GetComponent<Renderer>().materials)
        {
            defaultTint[count] = mat.color;
            count++;
        }
    }


    IEnumerator Flash(int flashCount, GameObject tag)
    {
        int flashCounter = 0;
        while (flashCounter < flashCount)
        {
            foreach (Material mat in gameObject.transform.GetChild(0).GetComponent<Renderer>().materials)
            {
                mat.color = DamageColor;
            }

            yield return new WaitForSeconds(interval);

            var count = 0;
            foreach (Material mat in gameObject.transform.GetChild(0).GetComponent<Renderer>().materials)
            {
                mat.color = defaultTint[count];
                count++;
            }

            yield return new WaitForSeconds(interval);
            flashCounter++;
        }
    }
}
