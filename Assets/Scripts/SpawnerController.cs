using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {

    public int spawnNum = 1;
    public float coolDownSpawn = 1f;
    public GameObject enemyPrefab;

    private int children;
    private float spawnPositionParamaters = 39;
    private int index;

	void Start () {
        InvokeRepeating("Checker", 2, 3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Checker() {

        children = gameObject.transform.childCount;

        if (children <= 0)
        {
            index = 0;
            spawnNum++;
            StartCoroutine("Spawn");
        }
    }

    IEnumerator Spawn() {

        while (index < spawnNum)
        {
            yield return new WaitForSeconds(coolDownSpawn);
            index++;
            GameObject temp = Instantiate(enemyPrefab, new Vector3(spawnPositionParamaters * Randomizer(), 2, spawnPositionParamaters * Randomizer()), Quaternion.identity);
            temp.name = "Enemy: " + index;
            temp.transform.parent = gameObject.transform;
        }
        if (index >= spawnNum)
            StopCoroutine("Spawn");
    }

    int Randomizer() {
        float temp = Random.Range(0, 100);
        if (temp >= 50)
            return -1;
        else
            return 1;
    }
}
