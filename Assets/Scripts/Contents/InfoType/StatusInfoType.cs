using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum StatusInfoType
{
    None = 0,
    HP,
    MaxHP,

    MP,
    MaxMP,

    MovementSpeed,
    AttackSpeed,

    BasicAttackPower,

    CriticalPercentage,
    CriticalDamage,

    Defense,
    MagicResistance,

    Experience,

    End
}