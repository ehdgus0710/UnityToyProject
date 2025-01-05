using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private EnemyStatus enemyStatus;

    public UnityEvent destinationEvent;
    [SerializeField]
    private Vector3 movePoint;
    private Vector3 moveDirection;

    private MonsterSpawner monsterSpawner;

    private float moveSpeed;
    private int moveIndex = 0;
    private bool isMove = false;
    private bool isDestination = false;

    private void Start()
    {
        moveSpeed = enemyStatus.GetStatValue(StatType.MovementSpeed);
    }

    public void SetDestinationPoint(MonsterSpawner owner, Vector3 destinationPoint)
    {
        monsterSpawner = owner;
        movePoint = destinationPoint;
        moveDirection = (movePoint - transform.position).normalized;
        isMove = true;
    }

    private void Update()
    {
        if(isMove)
        {
            transform.position += moveDirection * (moveSpeed * GameTimeManager.Instance.DeltaTime);

            if (Vector3.Distance(transform.position,movePoint) < 1f)
            {
                ++moveIndex;
                isMove = monsterSpawner.GetMovePoint(ref movePoint, moveIndex);
                moveDirection = (movePoint - transform.position).normalized;
            }

            if(!isMove && !isDestination)
            {
                isDestination = true;
                GameController.Instance.LifeDown();
                destinationEvent?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
