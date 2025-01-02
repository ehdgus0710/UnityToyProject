using UnityEngine; 

[CreateAssetMenu(fileName = "StatusInfo", menuName = "StatusInfo", order = 3)]
[System.Serializable]
public class StatusInfoData : ScriptableObject
{
    [SerializeField]
    protected SerializableDictionary<StatType, StatusValue> statusTable = new SerializableDictionary<StatType, StatusValue>();
    public SerializableDictionary<StatType, StatusValue> StatusTable { get { return statusTable; } }
}
