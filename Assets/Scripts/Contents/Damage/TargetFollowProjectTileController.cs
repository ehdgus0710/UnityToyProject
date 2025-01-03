using System.Net;
using Unity.VisualScripting;
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

    Vector3 endPoint;

    protected override void Update()
    {
        if(isTargetFollow)
        {
            if (targetTransform.IsDestroyed())
            {
                DisconnectAsTargetDestroy();
            }
            else
            {
                float distance = Vector3.Distance(targetTransform.position, rigidbody.position);

                if (distance < 5f)
                {
                    hitEvent?.Invoke();
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            if(5f >= Vector3.Distance(endPoint, rigidbody.position))
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

    public void TargetShooting(Transform target,UnityAction _hitEvent = null, UnityAction _destoryEvent = null)
    {
        targetTransform = target;

        int targetLayer = targetTransform.gameObject.layer;

        SetEvent(_hitEvent, _destoryEvent);
    }

    private void DisconnectAsTargetDestroy()
    {
        isTargetFollow = false;
        endPoint = targetTransform.position;
        moveDirection = Vector3.Normalize(endPoint - rigidbody.position);

        endMovementDistance = Vector3.Distance(targetTransform.position, rigidbody.position);

        

        if (moveSpeed <= 0f)
            moveSpeed = 10f;
    }
}
