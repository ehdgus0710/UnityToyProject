using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    //DamageInfo OnDamage(DamageInfo damageInfo);
    bool OnDamage(ref DamageInfo inoutDamageInfo);
}
