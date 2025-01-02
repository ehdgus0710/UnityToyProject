using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Unity내 LayerMask 정보를 받아옵니다.
/// </summary>
public static class GetLayerMasks
{
    public static readonly int Tower = 1 << GetLayer.Tower;
    public static readonly int Ground = 1 << GetLayer.Ground;
    public static readonly int TowerGround = 1 << GetLayer.TowerGround;
    public static readonly int GroundEnemy = 1 << GetLayer.GroundEnemy;
    public static readonly int AerialEnemy = 1 << GetLayer.AerialEnemy;
    public static readonly int Enemy = 1 << GetLayer.Enemy;
}


/// <summary>
/// Unity내 Layer 정보를 받아옵니다.
/// </summary>
public static class GetLayer
{
    public static readonly int Tower = UnityEngine.LayerMask.NameToLayer("Tower");
    public static readonly int Ground = UnityEngine.LayerMask.NameToLayer("Ground");
    public static readonly int TowerGround = UnityEngine.LayerMask.NameToLayer("TowerGround");
    public static readonly int GroundEnemy = UnityEngine.LayerMask.NameToLayer("GroundEnemy");
    public static readonly int AerialEnemy = UnityEngine.LayerMask.NameToLayer("AerialEnemy");
    public static readonly int Enemy = UnityEngine.LayerMask.NameToLayer("Enemy");
}