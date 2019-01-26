using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotate : MonoBehaviour {

    public float angle;

	void Update () {

        if (!FencePlacement.PlacementMode)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                angle += 90;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                angle -= 90;
            }

            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
	}
}
