using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyProfile", menuName = "Profile/EnemyProfile", order = 3)]
[Serializable]
public class EnemyProfile : ScriptableObject
{
    [SerializeField]
    private float IdleDetectionDistancem;
    public float IdleDetectionDistance { get { return IdleDetectionDistancem; } }

}
