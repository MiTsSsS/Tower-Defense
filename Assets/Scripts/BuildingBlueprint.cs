using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBlueprint : MonoBehaviour
{
    RaycastHit hit;
    Vector3 placePoint;
    public GameObject prefab;
    public LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f, mask)) {
            transform.position = hit.point;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, mask)) {
            Debug.DrawRay(Camera.main.transform.position, Input.mousePosition * 10, Color.yellow);
            Debug.DrawLine(ray.origin, hit.point);
            if (!hit.transform.tag.Equals("Building")) {
                placePoint = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                transform.position = placePoint;
            }
        }

        if (Input.GetMouseButtonDown(0)) {              
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {
                placePoint = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                Instantiate(prefab, placePoint, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}