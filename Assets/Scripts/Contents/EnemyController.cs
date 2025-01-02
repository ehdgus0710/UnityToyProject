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
        agent.SetDestination(destinationPoint.position);
    }

    public void SetDestinationPoint(Transform destinationPoint)
    {
        this.destinationPoint = destinationPoint;
    }

    private void Update()
    {
        if (agent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            Destroy(gameObject);
        }
    }
}
