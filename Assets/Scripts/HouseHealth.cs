using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseHealth : MonoBehaviour {

    public int Health = 100;
    public Color DamageColor;
    public Color[] defaultTint;
    public int flashCount = 6;
    public float interval = 0.4f;

    public HealthBar hb;

    void Start()
    {
        hb.SetHealth(Health);
        /*
        defaultTint = new Color[gameObject.transform.GetChild(0).GetChild(0).GetComponents<Renderer>().Length + 1];

        var count = 0;
        foreach (Material mat in gameObject.GetComponent<Renderer>().materials)
        {
            defaultTint[count] = mat.color;
            count++;
        }
        */
    }
    public void TakeDamage(int val) {

        Health -= val;
        hb.SetHealth(Health);
        //StartCoroutine(Flash(flashCount));
    }

    public int GetHealth() {
        return this.Health;
    }
    /*
    IEnumerator Flash(int flashCount)
    {
        int flashCounter = 0;
        while (flashCounter < flashCount)
        {
                foreach (Material mat in gameObject.GetComponent<Renderer>().materials)
                {
                    mat.color = DamageColor;
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
    */
}
 