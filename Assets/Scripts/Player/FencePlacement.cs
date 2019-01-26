using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FencePlacement : PlayerResources {

    public GameObject fence;
    public LayerMask lm;
    public static bool PlacementMode = false;

    private GameObject temp;
    private int angle;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
            PlacementMode = !PlacementMode;

        if (PlacementMode)
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, lm))
            {
                if (hit.transform.tag == "World")
                {
                    Vector3 holderPosition = hit.point;
                    holderPosition = new Vector3((int)holderPosition.x, 1, (int)holderPosition.z);

                    if (temp == null)
                        temp = Instantiate(fence, holderPosition, Quaternion.Euler(0, angle, 0));

                    temp.transform.position = holderPosition;

                    if (Input.GetMouseButtonDown(0))
                    {
                        print(GetWood());
                        if (GetWood() > 0)
                        {
                            Instantiate(fence, holderPosition, Quaternion.Euler(0, angle, 0));
                            PlacementMode = false;
                        }
                    }
                }
            }
        }
        else
            temp = null;
    }

}
