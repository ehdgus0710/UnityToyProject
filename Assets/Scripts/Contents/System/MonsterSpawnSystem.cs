using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnSystem : MonoBehaviour
{
    [SerializeField]
    public List<MonsterSpawner> monsterSpawnerList;

    [SerializeField]
    public List<MonsterSpawnInfo> spawnDataByLevelList;

    private int currentLevel = 0;
    private float currentPlayTime = 0f;
    private bool isActive = false;

    private void Start()
    {
        isActive = true;
        currentPlayTime = 0f;
        StartSpawn();
    }

    // 코루틴을 사용하여 시간증가에 따른 몬스터 스폰 레벨 변경 코드 작성하기

    private void Update()
    {
        if (!isActive)
            return;

        currentPlayTime += GameTimeManager.Instance.DeltaTime;
    }

    public void StartSpawn()
    {
        foreach (var spawner in monsterSpawnerList)
        {
            spawner.SetMonsterSpawnInfo(spawnDataByLevelList[currentLevel]);
            spawner.StartSpawn(true);
        }
    }

    public void StopSpawn()
    {
        foreach (var spawner in monsterSpawnerList)
        {
            spawner.StopSpawn();
        }
    }
}
