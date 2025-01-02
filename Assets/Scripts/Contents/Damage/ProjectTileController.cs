using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class ProjectTileController : DamagedObject
{
    [SerializeField]
    protected bool isTargetPoint;

    [SerializeField]
    protected Vector3 moveDirection;

    [SerializeField]
    protected float endMovementDistance;

    [SerializeField]
    protected float moveSpeed;

    [SerializeField]
    protected AnimationCurve animationCurve;

    new protected Rigidbody rigidbody;

    protected Vector3 startPos;

    protected override void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    protected override void Update()
    {
        base.Update();

        if (endMovementDistance != 0f && OnTargetDistancePassed())
            Destroy(gameObject);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        
        rigidbody.MovePosition(rigidbody.position + moveDirection * Time.fixedDeltaTime * moveSpeed);
    }

    public virtual void Shooting(Vector3 moveDir, float maxMoveDistance = 0f, UnityAction _hitEvent = null, UnityAction _destoryEvent = null)
    {
        moveDirection = moveDir;

        endMovementDistance = maxMoveDistance;

        SetEvent(_hitEvent, _destoryEvent);
    }

    public virtual void Shooting(Vector3 moveDir, float _moveSpeed, float maxMoveDistance = 0f, UnityAction _hitEvent = null, UnityAction _destoryEvent = null)
    {
        moveDirection = moveDir;
        moveSpeed = _moveSpeed;

        endMovementDistance = maxMoveDistance;

        SetEvent(_hitEvent, _destoryEvent);
    }

    public void SetEvent(UnityAction _hitEvent = null, UnityAction _destoryEvent = null)
    {
        if (_hitEvent != null)
            hitEvent.AddListener(_hitEvent);
        if (_destoryEvent != null)
            destoryEvent.AddListener(_destoryEvent);
    }

    protected bool OnTargetDistancePassed()
    {
        return endMovementDistance <= Vector3.Distance(startPos, transform.position);
    }
}
