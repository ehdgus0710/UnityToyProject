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

    // �ڷ�ƾ�� ����Ͽ� �ð������� ���� ���� ���� ���� ���� �ڵ� �ۼ��ϱ�

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
