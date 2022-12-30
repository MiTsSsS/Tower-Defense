using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    
    public Transform destination;

    // Start is called before the first frame update
    void Start()
    {
       agent.SetDestination(destination.position); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
