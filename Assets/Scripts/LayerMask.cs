using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Unity내 LayerMask 정보를 받아옵니다.
/// </summary>
public static class GetLayerMasks
{
    public static readonly int Player = 1 << GetLayer.Player;
    public static readonly int Ground = 1 << GetLayer.Ground;
    public static readonly int Terrain = 1 << GetLayer.Terrain;
    public static readonly int Enemy = 1 << GetLayer.Enemy;
    public static readonly int EnemyDeath = 1 << GetLayer.EnemyDeath;
}


/// <summary>
/// Unity내 Layer 정보를 받아옵니다.
/// </summary>
public static class GetLayer
{
    public static readonly int Player = UnityEngine.LayerMask.NameToLayer("Player");
    public static readonly int Ground = UnityEngine.LayerMask.NameToLayer("Ground");
    public static readonly int Terrain = UnityEngine.LayerMask.NameToLayer("Terrain");
    public static readonly int Enemy = UnityEngine.LayerMask.NameToLayer("Enemy");
    public static readonly int EnemyDeath = UnityEngine.LayerMask.NameToLayer("EnemyDeath");
}