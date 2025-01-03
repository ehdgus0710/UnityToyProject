using UnityEngine;
using UnityEngine.Events;

public class ProjectTile : MonoBehaviour
{
    [SerializeField]
    private Transform targetTransform;

    [SerializeField]
    protected Transform ownerTransform;

    [SerializeField]
    protected UnityEvent hitEvent;

    [SerializeField]
    protected UnityEvent startHitEvent;

    [SerializeField]
    protected UnityEvent destoryEvent;

    private Vector3 endPoint;

    [SerializeField]
    protected Vector3 moveDirection;

    [SerializeField]
    protected float endMovementDistance;

    [SerializeField]
    protected float moveSpeed;

    private bool isTargetDeath = false;

    public void TargetShooting(Transform owner, Transform target, UnityAction _hitEvent = null, UnityAction _destoryEvent = null)
    {
        ownerTransform = owner;
        targetTransform = target;
        targetTransform.GetComponent<IDamageable>().DeathEvent.AddListener(OnTargetDeath);

        if(_hitEvent != null)
            hitEvent.AddListener(_hitEvent);
        if (_destoryEvent != null)
            destoryEvent.AddListener(_destoryEvent);

        int targetLayer = targetTransform.gameObject.layer;
    }

    private void Update()
    {
        Move();
    }

    private void OnTargetDeath()
    {
        isTargetDeath = true;
        endPoint = targetTransform.position;
        targetTransform = null;
    }

    private void OnAttackTarget()
    {
        var ownerData = ownerTransform.GetComponent<TowerController>().TowerProfile;

        var targetDamageable = targetTransform.GetComponent<IDamageable>();

        DamageInfo damageInfo = new DamageInfo();
        damageInfo.attackOwner = ownerTransform.gameObject;
        damageInfo.hitDirection = moveDirection;
        damageInfo.hitNormal = transform.up;
        damageInfo.damage = ownerData.Attackpower;

        targetDamageable.OnDamage(ref damageInfo);
        targetDamageable.DeathEvent.RemoveListener(OnTargetDeath);

        hitEvent?.Invoke();
    }

    private void Move()
    {
        Vector3 targetPosition;

        if (!isTargetDeath)
        {
            moveDirection = Vector3.Normalize(targetTransform.position - transform.position);
            targetPosition = targetTransform.position;
        }
        else
        {
            moveDirection = Vector3.Normalize(endPoint - transform.position);
            targetPosition = endPoint;
        }

        transform.position += moveDirection * GameTimeManager.Instance.DeltaTime * moveSpeed;

        if (endMovementDistance >= Vector3.Distance(targetPosition, transform.position))
        {
            if(!isTargetDeath)
                OnAttackTarget();

            Destroy(gameObject);
        }
    }
}
