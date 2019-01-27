using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FencePlacement : MonoBehaviour {

    public GameObject fence;
    public LayerMask lm;
    public static bool PlacementMode = false;

    private GameObject temp;
    private int angle;


    private int wood;

    public Text woodText;

    public void AddWood()
    {
        wood += 1;
    }

    public void AddWood(int val)
    {
        wood += val;
    }

    public int GetWood()
    {
        return wood;
    }

    public void SubtractWood()
    {
        wood -= 1;
    }

    void Update()
    {
        woodText.text = "Wood: " + wood.ToString();

        if (Input.GetMouseButtonDown(1))
            PlacementMode = !PlacementMode;

        if (PlacementMode)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                angle += 90;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                angle -= 90;
            }

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, lm))
            {
                if (hit.transform.tag == "World")
                {
                    Vector3 holderPosition = hit.point;
                    holderPosition = new Vector3((int)holderPosition.x, 2.2f, (int)holderPosition.z);

                    if (temp == null)
                        temp = Instantiate(fence, holderPosition, Quaternion.Euler(0, angle, 0));

                    temp.transform.rotation = Quaternion.Euler(0, angle, 0);

                    temp.transform.position = holderPosition;

                    if (Input.GetMouseButtonDown(0))
                    {
                        print(GetWood());
                        if (GetWood() > 0)
                        {
                            Instantiate(fence, holderPosition, Quaternion.Euler(0, angle, 0));
                            PlacementMode = false;
                            SubtractWood();
                        }
                    }
                }                
            }
        }
        else
        {
            Destroy(temp);
        }
    }

    void OnTriggerStay(Collider coll)
    {
        if (coll.tag == "Tree")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                coll.gameObject.GetComponent<TreeHealth>().TakeDamage(25, gameObject);
                if (coll.gameObject.GetComponent<TreeHealth>().GetHealth() <= 0)
                {
                    AddWood();
                }
            }
        }
    }
}
