using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackPatternContainer
{
    public SerializableDictionary<EnemyAttackType, List<AttackPattern>> attackPatterns = new SerializableDictionary<EnemyAttackType, List<AttackPattern>>();
}
