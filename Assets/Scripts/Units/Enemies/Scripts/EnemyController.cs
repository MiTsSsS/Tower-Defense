using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent m_agent;
    [SerializeField]
    private Transform m_destination;

    // Start is called before the first frame update
    void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();

        GameObject pointB = GameObject.Find("Point B");
        m_destination = pointB.transform;

        m_agent.SetDestination(m_destination.position);
    }

    public void setDestination(Transform destination) {
        m_destination = destination;
    }
}