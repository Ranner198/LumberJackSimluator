using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public GameObject[] healthBarObjects;

    void Start()
    {
        InvokeRepeating("UpdateArray", 0.1f, 0.1f);
    }

    public void Update()
    {
        
    }

    void UpdateArray() {
        GameObject[] objects = FindObjectsOfType(typeof(HealthBarObject)) as GameObject;
    }
}
