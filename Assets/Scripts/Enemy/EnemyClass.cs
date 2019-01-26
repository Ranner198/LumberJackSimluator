using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass {

    private int Health;
    private Vector3 SpawnPoint;
     

    public EnemyClass() { }

    public EnemyClass(int health, Vector3 SpawnPoint) {
        this.Health = health;
        this.SpawnPoint = SpawnPoint;
    }

    public void TakeDamage(int val) {
        this.Health -= val;
    }

    public int GetHealth() {
        return this.Health;
    }
}
