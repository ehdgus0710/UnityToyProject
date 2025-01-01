using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackInfo", menuName = "AttackInfo", order = 3)]
public class AttackInfoData : ScriptableObject
{
    [SerializeField]
    private GameObject attackObjectPrefab;
    public GameObject AttackObjectPrefab { get { return attackObjectPrefab; } }

    [SerializeField]
    private VfxContainerData vfxCantainer;
    public VfxContainerData VFXCantainer { get { return vfxCantainer; } }

    [SerializeField]
    private string vfxKey;
    public string VFXKey { get {  return vfxKey; } }

    [SerializeField]
    private string animationKey;
    public string AnimationKey { get { return animationKey; } } 

    [SerializeField]
    private Vector3 createOffsetPos;
    public Vector3 CreateOffsetPos { get { return createOffsetPos; } }  

    [SerializeField]
    private bool isKnockback;
    public bool IsKnockback { get { return isKnockback; } }

    [SerializeField]
    private Vector3 knockbackDirection;
    public Vector3 KnockbackDirection { get { return knockbackDirection; } }


    [SerializeField]
    private float knockbackPower;
    public float KnockbackPower { get { return knockbackPower; } }


    [SerializeField]
    private float knockbackTime;
    public float KnockbackTime { get { return knockbackTime; } }

    [SerializeField]
    private AnimationCurve knockbackCurve;
    public AnimationCurve KnockbackCurve { get { return knockbackCurve; } }
}
