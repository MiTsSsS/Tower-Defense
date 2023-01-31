using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBlueprint : MonoBehaviour
{
    RaycastHit hit;
    Vector3 placePoint;
    public GameObject towerPreview;
    public GameObject selectedTower;
    public LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 500000.0f, mask) && towerPreview != null) {
            transform.position = hit.point;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, mask, QueryTriggerInteraction.Ignore)
            && towerPreview != null) {
            Debug.DrawLine(ray.origin, hit.point, Color.red);

            if (!hit.transform.tag.Equals("Building")) {
                placePoint = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                towerPreview.transform.position = hit.point;
            }
        }

        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, mask, QueryTriggerInteraction.Ignore)
               && selectedTower != null) {
                BuildingController bc = selectedTower.GetComponentInChildren<BuildingController>();

                if (GameManager.instance.validateBuildingCost(bc.cost)) { 
                    placePoint = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                    Instantiate(selectedTower, placePoint, transform.rotation);

                    bc.OnBuildingPlaced();
                
                    Destroy(towerPreview);
                    selectedTower = null;
                }
            }
        }
    }

    public void setSelectedTower(GameObject st) {
        selectedTower = st;
    }
}