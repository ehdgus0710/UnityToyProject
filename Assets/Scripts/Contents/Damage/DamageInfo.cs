using UnityEngine;

[System.Serializable]
public struct DamageInfo
{
    public GameObject       attackOwner;
    public Vector3          hitPoint;
    public Vector3          hitNormal;
    public Vector3          hitDirection;

    public float            damage;
    public bool             targetDeath;

    public bool             isDebuff;
    public uint             debuffLayer;
    public float            debuffTime;

    public bool             isKnockback;
    public Vector3          knockbackDirection;
    public float            knockbackPower;
    public float            knockbackTime;
    public AnimationCurve   knockbackCurve;

    public void SetAttackInfo(AttackInfoData attackInfoData)
    {
        knockbackDirection= attackInfoData.KnockbackDirection;
        knockbackPower    = attackInfoData.KnockbackPower;
        knockbackTime     = attackInfoData.KnockbackTime;
        knockbackCurve    = attackInfoData.KnockbackCurve;

        if (!isKnockback)
            return;
        knockbackPower = attackInfoData.KnockbackPower;
    }
}
