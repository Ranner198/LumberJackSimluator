using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutDownTree : PlayerResources {

    void OnTriggerStay(Collider coll)
    {
        if (coll.tag == "Tree")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                coll.gameObject.GetComponent<TreeHealth>().TakeDamage(25);
                AddWood();
            }
        }
    }

}
