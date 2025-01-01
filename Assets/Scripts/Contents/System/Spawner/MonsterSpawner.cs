using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour, IMonsterSpawner
{
    public MonsterSpawnSystem monsterSpawnSystem;

    protected MonsterSpawnInfo monsterSpawnInfo;
    protected float spawnTime;
    protected float currentSpawnTime = 0f;

    protected bool isActive = false;
    protected bool isRepeat = true;

    protected virtual void Awake()
    {
        
    }

    protected virtual void Start()
    {
        if (monsterSpawnInfo == null)
            enabled = false;
    }

    protected virtual void Update()
    {
        if (!isActive)
            return;

        currentSpawnTime += GameTimeManager.Instance.DeltaTime;

        if (currentSpawnTime >= spawnTime)
        {
            currentSpawnTime = 0f;
            ISpawn();
        }
    }

    public virtual void StartSpawn()
    {
        isActive = true;
        enabled = true;
    }

    public virtual void SetMonsterSpawnInfo(MonsterSpawnInfo monsterSpawnInfo)
    {
        this.monsterSpawnInfo = monsterSpawnInfo;
        spawnTime = this.monsterSpawnInfo.SpawnTime;
    }

    public virtual void StartSpawn(bool isRepeat)
    {
        SetRepeat(isRepeat);
        StartSpawn();
    }
    public virtual void StopSpawn()
    {
        isActive = false;
        //enabled = false;
    }

    public virtual void SetSpwanTime(float time)
    {
        spawnTime = time;
    }

    public virtual void SetRepeat(bool _isRepeat)
    {
        this.isRepeat = _isRepeat;
    }

    public virtual void ISpawn()
    {
        GameObject monster = Instantiate(monsterSpawnInfo.MonsterPrefab);
        monster.transform.position = transform.position;

        if (!isRepeat)
            StopSpawn();
    }
}
