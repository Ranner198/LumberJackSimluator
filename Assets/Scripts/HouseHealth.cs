using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseHealth : MonoBehaviour {

    public int Health = 100;

    public void TakeDamage(int val) {
        Health -= val;
    }

    public int GetHealth() {
        return this.Health;
    }
}
