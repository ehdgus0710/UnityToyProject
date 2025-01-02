using UnityEngine;
using UnityEngine.Events;

public class TargetFollowProjectTileController : ProjectTileController
{
    [SerializeField]
    private bool isTargetFollow;

    [SerializeField]
    private bool isOnlyTargetHit;

    [SerializeField]
    private Transform targetTransform;

    protected override void Update()
    {
        base.Update();

        if(!isTargetFollow)
        {
            if (OnTargetDistancePassed())
                Destroy(gameObject);
        }
    }

    protected override void FixedUpdate()
    {
        if (isTargetFollow)
            rigidbody.MovePosition(Vector3.Normalize(targetTransform.position - rigidbody.position) * Time.fixedDeltaTime* moveSpeed);
        else
            rigidbody.MovePosition(rigidbody.position + moveDirection * Time.fixedDeltaTime * moveSpeed);
    }

    public void TargetShooting(Transform target, UnityAction _hitEvent = null, UnityAction _destoryEvent = null)
    {
        targetTransform = target;

        int targetLayer = targetTransform.gameObject.layer;

        //if (targetLayer == GetLayer.Player)
        //    targetTransform.GetComponent<PlayerFSM>().DestroyEvent.AddListener(DisconnectAsTargetDestroy);
        //else if (targetLayer == GetLayer.Enemy)
        //    targetTransform.GetComponent<EnemyFSM>().DestroyEvent.AddListener(DisconnectAsTargetDestroy);

        SetEvent(_hitEvent, _destoryEvent);
    }

    private void DisconnectAsTargetDestroy()
    {
        isTargetFollow = false;
        moveDirection = Vector3.Normalize(targetTransform.position - rigidbody.position);

        endMovementDistance = Vector3.Distance(targetTransform.position, rigidbody.position);

        if (moveSpeed <= 0f)
            moveSpeed = 10f;
    }
}
