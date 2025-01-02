using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttackInfo", menuName = "AttackContainer/PlayerAttackContainer", order = 3)]
[Serializable]
public class PlayerAttackContainer : ScriptableObject
{
    [SerializeField]
    protected SerializableDictionary<string, GameObject> statusTable = new SerializableDictionary<string, GameObject>();
    public SerializableDictionary<string, GameObject> GetStatusTable { get { return statusTable; } }
}
