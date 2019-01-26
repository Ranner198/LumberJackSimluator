using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour {

    public int wood;

	void Update () {
		
	}

    public void AddWood() {
        wood += 1;
    }

    public void AddWood(int val) {
        wood += val;
    }
}
