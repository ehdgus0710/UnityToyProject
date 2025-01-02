using UnityEngine;

[CreateAssetMenu(fileName = "TowerProfile", menuName = "Profile/TowerProfile", order = 3)]
[System.Serializable]
public class TowerProfile : ScriptableObject
{
    [SerializeField]
    private TowerAttackType attackType;
    public TowerAttackType AttackType { get { return attackType; } }

    [SerializeField]
    private float attackpower;
    public float Attackpower { get { return attackpower; } }
    [SerializeField]
    private float masicAttackpower;
    public float MasicAttackpowerv { get { return masicAttackpower; } }

    [SerializeField]
    private float attackRange;
    public float AttackRange { get { return attackRange; } }

    [SerializeField]
    private float attackSpeed;
    public float AttackSpeed { get { return attackSpeed; } }

    [SerializeField]
    private float price;
    public float Price { get { return price; } }

}
