using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private Transform destinationPoint;
    [SerializeField]
    private EnemyStatus enemyStatus;

    public UnityEvent destinationEvent;
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        // agent.speed = enemyStatus.GetStatValue(StatType.MovementSpeed);

        if (destinationPoint != null)
            agent.SetDestination(destinationPoint.position);
    }

    public void SetDestinationPoint(Transform destinationPoint)
    {
        this.destinationPoint = destinationPoint;
        // agent.SetDestination(destinationPoint.position);
    }

    private void Update()
    {
        if (agent.isStopped)
        {
            destinationEvent?.Invoke();
            Destroy(gameObject);
        }
    }
}
