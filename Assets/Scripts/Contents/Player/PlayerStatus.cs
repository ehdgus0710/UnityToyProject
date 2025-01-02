using UnityEngine;
using UnityEngine.Events;

public class PlayerStatus : EntityStatus
{
    private float currentExperience = 0f;
    public float CurrentExperience { get { return currentExperience; } }

    [SerializeField]
    private StatusInfoData abilityIncreasePerLevelData;


    public UnityEvent levelUpEvent;

    private uint currentLevel = 1;


    private void Reset()
    {
        OnStatusLoad();
    }

    private void Start()
    {
        OnStatusLoad();
    }

    // ���� �ε� �ý����� ���� ������ �߰� ���� ����
    public void OnStatusLoad()
    {

    }


    public void OnLevelUp()
    {
        ++currentLevel;
        levelUpEvent?.Invoke();

        var abilityStatusTable = abilityIncreasePerLevelData.StatusTable;
        foreach (var item in abilityStatusTable)
        {
            currentStatus.GetStatusTable[item.Key].OnValueincrease(item.Value);
        }
    }
     

}
