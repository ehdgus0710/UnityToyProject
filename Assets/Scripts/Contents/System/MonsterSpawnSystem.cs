using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnSystem : MonoBehaviour
{
    [SerializeField]
    public List<MonsterSpawner> monsterSpawnerList;

    [SerializeField]
    public List<MonsterSpawnInfo> spawnDataByLevelList;

    private int currentWaveLevel = 0;
    private bool isActive = false;

    [SerializeField]
    private bool useAutoStart = false;

    private int activeSpawnerCount;

    private void Start()
    {
        GameController.Instance.SetCurrentWave(currentWaveLevel);

        if (useAutoStart)
        {
            isActive = true;
            StartSpawn();
        }
    }

    public void StartSpawn()
    {
        if (isActive)
            return;

        isActive = true;
        activeSpawnerCount = 0;
        foreach (var spawner in monsterSpawnerList)
        {
            spawner.SetMonsterSpawnInfo(spawnDataByLevelList[currentWaveLevel]);
            spawner.StartSpawn();
            ++activeSpawnerCount;
        }

        currentWaveLevel = Unity.Mathematics.math.min(currentWaveLevel + 1, spawnDataByLevelList.Count - 1);
        GameController.Instance.SetCurrentWave(currentWaveLevel + 1);
    }

    public void StopSpawn()
    {
        foreach (var spawner in monsterSpawnerList)
        {
            spawner.StopSpawn();
        }
    }

    public void EndSpawn()
    {
        --activeSpawnerCount;

        if(activeSpawnerCount == 0)
        {
            isActive = false;
        }
    }
}
