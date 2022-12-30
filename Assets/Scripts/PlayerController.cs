using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Camera mainCam;

    public NavMeshAgent agent;

    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit)) {
                agent.SetDestination(hit.point);
            }
        }
    }
}