using UnityEngine;
using UnityEngine.Events;

public class EnemyStatus : MonoBehaviour, IDamageable
{
    private SerializableDictionary<StatType, StatusValue> currentValues = new SerializableDictionary<StatType, StatusValue>();

    [SerializeField]
    private EnemyProfile enemyProfile;

    public bool IsDead { get; private set; } = false;


    public UnityEvent hitEvent;
    public UnityEvent deathEvent;
    public UnityEvent DeathEvent { get { return deathEvent; } }

    private void Awake()
    {
        foreach (var item in enemyProfile.EnemyStatusInfoData.StatusTable)
        {
            if (!currentValues.ContainsKey(item.Key))
            {
                StatusValue status = new StatusValue(item.Key);
                currentValues.Add(item.Key, status);
            }

            currentValues[item.Key].ValueCopy(item.Value);
        }
    }


    public bool OnDamage(ref DamageInfo inoutDamageInfo)
    {
        var damage = DamageCalculate(ref inoutDamageInfo);

        if (damage == 0f)
        {
            inoutDamageInfo.targetDeath = false;
            return false;
        }

        var currentHp = currentValues[StatType.HP].AddValue(-damage);
        hitEvent?.Invoke();

        if (currentHp <= 0)
        {
            IsDead = true;
            inoutDamageInfo.targetDeath = IsDead;
            deathEvent?.Invoke();
            Destroy(gameObject);
        }

        return true;
    }

    private float DamageCalculate(ref DamageInfo inoutDamageInfo)
    {
        float damage = inoutDamageInfo.damage - currentValues[StatType.Defense].Value;

        return (damage <= 0f ? 0f : damage);
    }

    public float GetStatValue(StatType statType)
    {
        return currentValues[statType].Value;
    }
}
