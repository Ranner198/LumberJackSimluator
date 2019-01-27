using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {

    public int spawnNum = 1;
    public int wave = 1;
    public float coolDownSpawn = 1f;
    public GameObject enemyPrefab;

    private int children;
    private float spawnPositionParamaters = 45;
    private int index;

	public void StartSpawn () {
        InvokeRepeating("Checker", 3, 3f);
        WaveText.ShowWave = true;
	}

    void Checker() {

        children = gameObject.transform.childCount;

        if (children <= 0)
        {
            wave++;
            WaveText.ShowWave = true;
            StartCoroutine(Spawn ());
        }
    } 

    IEnumerator Spawn() {        

        yield return new WaitForSeconds(1);

        for (index = 0; index < spawnNum; index++)
        { 
            index++;
            yield return new WaitForSeconds(coolDownSpawn);
            Vector3 spawnPosition = BuildSpawnPoint();

            GameObject temp = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            temp.name = "Enemy";
            temp.transform.SetParent(gameObject.transform);
            yield return new WaitForSeconds(coolDownSpawn);
        }
        if (index >= spawnNum)
        {
            StopCoroutine("Spawn");
            spawnNum++;
        }
    }

    Vector3 BuildSpawnPoint() {
        var x = Randomizer();
        var z = Randomizer();

        while (x == 0 && z == 0)
        {
            x = Randomizer();
            z = Randomizer();
        }

        return new Vector3(spawnPositionParamaters * x, 0, spawnPositionParamaters * z);
    }

    int Randomizer() {
        float temp = Random.Range(0, 100);

        if (temp < 33)
            return 0;
        else if (temp >= 33 && temp < 66)
            return -1;
        else
            return 1;
    }
}
