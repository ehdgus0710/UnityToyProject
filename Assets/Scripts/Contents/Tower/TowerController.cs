using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField]
    private TowerGround ownerGround;

    [SerializeField]
    private TowerProfile towerProfile;
    public TowerProfile TowerProfile { get { return towerProfile; } }

    [SerializeField]
    private int targetSize = 10;

    [SerializeField]
    private Transform targetTransform;
    private IDamageable targetInfo;

    [SerializeField]
    private AttackInfoData attackInfoData;

    private Collider[] targetColliders;
    private Coroutine targetQuest = null;

    private float questRange = 0.2f;

    private float currentTime = 0f;
    private bool isAttackTarget = false;
    private bool isTarget = false;
    private bool isReload = false;

    private void Start()
    {
        targetColliders = new Collider[targetSize];

        targetQuest = StartCoroutine(CoFindTarget());
    }

    public void SetCreateInfo(TowerGround owner)
    {
        ownerGround = owner;
    }

    private bool OnFindTarget()
    {
        int count = Physics.OverlapSphereNonAlloc(transform.position, towerProfile.AttackRange, targetColliders
            , GetLayerMasks.Enemy | GetLayerMasks.GroundEnemy | GetLayerMasks.AerialEnemy);

        if (count == 0)
            return false;

        float currentDistance = float.MaxValue;

        for(int i = 0; i < count; ++i)
        {
            float targetDistance = Vector3.Distance(targetColliders[i].transform.position, transform.position);
            if (currentDistance > targetDistance)
            {
                if (targetColliders[i].transform.GetComponent<IDamageable>().IsDead)
                    continue;

                isTarget = true;
                targetTransform = targetColliders[i].transform;
                currentDistance = targetDistance;
            }
        }

        return isTarget;
    }

    protected virtual void CreateAttackObject()
    {
        var createObject = Instantiate(attackInfoData.AttackObjectPrefab);
        createObject.transform.position = transform.position + attackInfoData.CreateOffsetPos;

        var dagedObject = createObject.GetComponent<ProjectTile>();
        dagedObject.TargetShooting(transform, targetTransform, OnAttackTarget);

        // targetTransform.position;
    }

    private void OnAttackTarget()
    {
        //if(targetTransform.GetComponent<IDamageable>().IsDead)
        //{
        //    isTarget = false;
        //    targetTransform = null;
        //    targetQuest = StartCoroutine(CoFindTarget());
        //}
    }

    private void Update()
    {
        if (!isTarget)
        {
            if (targetQuest == null)
            {
                targetQuest = StartCoroutine(CoFindTarget());
            }
        }
        else
        {
            isTarget = CheckTargetStatus();
            AttackCheck();
        }
    }

    private bool CheckTargetStatus()
    {
        if(targetInfo.IsDead || towerProfile.AttackRange < Vector3.Distance(targetTransform.position, transform.position))
        {
            targetTransform = null;
            targetInfo = null;
            isTarget = false;
            return false;
        }

        return true;
    }

    private void AttackCheck()
    {
        if (isReload)
        {
            if (!isTarget)
                return;

            CreateAttackObject();
            isReload = false;
        }
        else
        {
            currentTime += GameTimeManager.Instance.DeltaTime;
            if (currentTime >= towerProfile.AttackSpeed)
            {
                currentTime = 0f;
                isReload = true;
            }
        }
    }

    private IEnumerator CoFindTarget()
    {
        bool isQuest = false;
        while (!isQuest)
        {
            yield return new WaitForSeconds(questRange * GameTimeManager.Instance.GameTimeScale);
            isQuest = OnFindTarget();
        }

        targetInfo = targetTransform.GetComponent<IDamageable>();
        targetQuest = null;
    }

}