using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField]
    private Transform destinationPoint;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        if(destinationPoint != null)
            agent.SetDestination(destinationPoint.position);
    }

    public void SetDestinationPoint(Transform destinationPoint)
    {
        this.destinationPoint = destinationPoint;
        // agent.SetDestination(destinationPoint.position);
    }
}
