using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[CreateAssetMenu(fileName = "StatusInfo", menuName = "StatusInfo", order = 3)]
[System.Serializable]
public class StatusInfoData : ScriptableObject
{
    [SerializeField]
    protected SerializableDictionary<StatusInfoType, StatusValue> statusTable = new SerializableDictionary<StatusInfoType, StatusValue>();
    public SerializableDictionary<StatusInfoType, StatusValue> StatusTable { get { return statusTable; } }

}
