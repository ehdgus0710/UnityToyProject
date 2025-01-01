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

        //�ش� �̺�Ʈ�� ����Ʈ ���� �� �ǰݽ� ������ ���� �Ǿ�� �ϴ� ��� ����
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
                // ����� ���� ����
                // ���� ��ȹ�� ���̾ ���� ����� ���� ���� �߰� �ϰ�, ���� ���� �� ������� ��� �ð� ó������ �ٽ� ���
                debuffEvent?.Invoke(damageInfo.debuffLayer);
            }

            if(damageInfo.isKnockback)
            {
                // �˹� ���� ���� �߰�
            }
        }

        return true;
    }
}
