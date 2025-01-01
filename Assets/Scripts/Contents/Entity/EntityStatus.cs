using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class EntityStatus : MonoBehaviour, IDamageable
{
    [SerializeField]
    protected StatusInfoData originalData;

    [SerializeField]
    protected StatusContainer currentStatus;
    public StatusContainer CurrentStatus
    {
        get { return currentStatus; }
    }

    public float CurrentStatusTypeValue(StatusInfoType statusInfoType)
    {
        return currentStatus.GetStatusTable[statusInfoType].Value;
    }

    protected bool isDead = false;
    public bool IsDead { get { return isDead; } }

    protected bool isHit = true;
    public bool IsHit { get { return isHit; } }

    public UnityEvent deathEvent;
    public UnityEvent hitEvent;
    public UnityEvent<uint> debuffEvent;

    public UnityAction<float> attackTargetDeathEvent;

    private void Reset()
    {
        IsStatusCopy();
    }

    private void Awake()
    {
        IsStatusCopy();
    }

    private void IsStatusCopy()
    {
        if (originalData != null)
            return;

        currentStatus.StatusCopy(originalData);
    }

    public virtual bool OnDamage(ref DamageInfo damageInfo)
    {
        if (isDead || !isHit)
            return false;

        float currentHP = currentStatus.GetStatusTable[StatusInfoType.HP].AddValue(-damageInfo.damage);

        //해당 이벤트는 이펙트 관련 및 피격시 무조건 동작 되어야 하는 기능 모음
        hitEvent?.Invoke();

        if (currentHP <= 0f)
        {
            damageInfo.targetDeath = true;
            damageInfo.attackOwner.GetComponent<EntityStatus>().attackTargetDeathEvent?.Invoke(currentStatus.GetStatusTable[StatusInfoType.Experience].Value);
            deathEvent?.Invoke();
        }
        else
        {
            if (damageInfo.isDebuff)
            {
                // 디버프 어케 할지
                // 현재 계획은 레이어를 통해 디버프 받을 것을 추가 하고, 현재 적용 된 디버프인 경우 시간 처음부터 다시 계산
                debuffEvent?.Invoke(damageInfo.debuffLayer);
            }

            if(damageInfo.isKnockback)
            {
                // 넉백 어케 할지 추가
            }
        }

        return true;
    }
}
