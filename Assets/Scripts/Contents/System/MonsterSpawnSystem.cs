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
    private bool isActive = false;

    [SerializeField]
    private bool useAutoStart = false;

    private void Start()
    {
        if(useAutoStart)
        {
            isActive = true;
            StartSpawn();
        }
    }

    public void StartSpawn()
    {
        foreach (var spawner in monsterSpawnerList)
        {
            spawner.SetMonsterSpawnInfo(spawnDataByLevelList[currentLevel]);
            spawner.StartSpawn();
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
