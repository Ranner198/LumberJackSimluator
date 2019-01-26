using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerResources : MonoBehaviour {

    public int wood;

    public Text woodText;

	void Update () {
        woodText.text = "Wood: " + wood.ToString();
	}

    public void AddWood() {
        wood += 1;
    }

    public void AddWood(int val) {
        wood += val;
    }
}
