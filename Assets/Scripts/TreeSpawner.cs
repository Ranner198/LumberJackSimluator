using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour {

    public GameObject treePrefab;
    public float Timer;

    private Vector3[] spawnPoints;
    public GameObject[] trees;
    private int num;

    void Start()
    {
        num = transform.childCount;
        trees = new GameObject[num];
        spawnPoints = new Vector3[trees.Length];

        for (int i = 0; i < trees.Length; i++)
        {
            trees[i] = transform.GetChild(i).gameObject;
            spawnPoints[i] = trees[i].transform.position;
        }

        InvokeRepeating("TreeManager", Timer, Timer);
    }

    void TreeManager() {
        for (int i = 0; i < trees.Length; i++)
        {
            if (trees[i] == null)
            {
                StartCoroutine(Spawner(i));
            }
        }
    }

    IEnumerator Spawner(int index) {

        yield return new WaitForSeconds(Timer/2);
        trees[index] = Instantiate(treePrefab, spawnPoints[index], Quaternion.identity);
        
    }


}
