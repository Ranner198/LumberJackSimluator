using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHealth : MonoBehaviour {

    public int Health = 100;

    public void TakeDamage(int val) {

        Health -= val;

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int GetHealth()
    {
        return this.Health;
    }
}
