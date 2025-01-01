using System.Collections;
using System.Collections.Generic;
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

    // 현재 로드 시스템이 없기 때문에 추가 하지 않음
    public void OnStatusLoad()
    {

    }


    public void AddExperience(float experience)
    {
        currentExperience += experience;

        if (currentExperience >= currentStatus.GetStatusTable[StatusInfoType.Experience].Value)
            OnLevelUp();
    }

    public void OnLevelUp()
    {
        currentExperience -= currentStatus.GetStatusTable[StatusInfoType.Experience].Value;
        ++currentLevel;
        levelUpEvent?.Invoke();

        var abilityStatusTable = abilityIncreasePerLevelData.StatusTable;
        foreach (var item in abilityStatusTable)
        {
            currentStatus.GetStatusTable[item.Key].OnValueincrease(item.Value);
        }

        if (currentExperience >= currentStatus.GetStatusTable[StatusInfoType.Experience].Value)
            OnLevelUp();
    }
     

}
