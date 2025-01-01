using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusContainer
{
    [SerializeField]
    protected SerializableDictionary<StatusInfoType, StatusValue> statusTable = new SerializableDictionary<StatusInfoType, StatusValue>();
    public SerializableDictionary<StatusInfoType, StatusValue> GetStatusTable { get { return statusTable; } }

    public void StatusCopy(StatusInfoData statusInfoData)
    { 
        statusTable.Clear();

        foreach (var item in statusInfoData.StatusTable)
        {
            if (!statusTable.ContainsKey(item.Key))
            {
                StatusValue status = new StatusValue(item.Key);
                statusTable.Add(item.Key, status);
            }

            statusTable[item.Key].ValueCopy(item.Value);
        }
        StatusInitialize();
    }

    private void StatusInitialize()
    {
        foreach (var item in statusTable)
        {
            if(!(item.Key == StatusInfoType.HP || item.Key == StatusInfoType.MP))
                continue;

            item.Value.ValueCopy(statusTable[(StatusInfoType)((int)item.Key + 1)]);
        }
    }
}
