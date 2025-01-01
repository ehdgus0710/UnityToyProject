using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttackInfo", menuName = "AttackContainer/PlayerAttackContainer", order = 3)]
[Serializable]
public class PlayerAttackContainer : ScriptableObject
{
    [SerializeField]
    protected SerializableDictionary<String, GameObject> statusTable = new SerializableDictionary<String, GameObject>();
    public SerializableDictionary<String, GameObject> GetStatusTable { get { return statusTable; } }
}
