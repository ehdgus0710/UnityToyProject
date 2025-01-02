public class StatusContainer
{    
    protected SerializableDictionary<StatType, StatusValue> statusTable = new SerializableDictionary<StatType, StatusValue>();
    public SerializableDictionary<StatType, StatusValue> GetStatusTable { get { return statusTable; } }

    public void CopyStatus(StatusInfoData statusInfoData)
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
            if (!(item.Key == StatType.HP || item.Key == StatType.MP))
                continue;

            item.Value.ValueCopy(statusTable[(StatType)((int)item.Key)]);
        }
    }

    public StatusValue GetStat(StatType statType)
    {
        return statusTable[statType];
    }
}
