using System.Collections;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour, IMonsterSpawner
{
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private Transform endMovePoint;

    public MonsterSpawnSystem monsterSpawnSystem;

    protected MonsterSpawnInfo monsterSpawnInfo;

    private Coroutine spawnCoroutine;

    protected float spawnTime;
    protected float currentSpawnTime = 0f;
    protected int currentSpawnCount = 0;

    protected bool isActive = false;
    protected bool isRepeat = true;

    public virtual void SetMonsterSpawnInfo(MonsterSpawnInfo monsterSpawnInfo)
    {
        this.monsterSpawnInfo = monsterSpawnInfo;
        spawnTime = this.monsterSpawnInfo.SpawnTime;
    }

    public virtual void StartSpawn()
    {
        if (monsterSpawnInfo.IsRepeat)
            spawnCoroutine = StartCoroutine(StartSpawnRepeatCoroutine());
        else
            spawnCoroutine = StartCoroutine(StartSpawnCoroutine());

        isActive = true;
        enabled = true;
    }

    public virtual void StartSpawn(bool isRepeat)
    {
        if(isRepeat)
            spawnCoroutine = StartCoroutine(StartSpawnRepeatCoroutine());
        else
            spawnCoroutine = StartCoroutine(StartSpawnCoroutine());

        isActive = true;
        enabled = true;
    }
    public virtual void StopSpawn()
    {
        currentSpawnCount = 0;
        isActive = false;
        //enabled = false;
        if(spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
    }

    public virtual void SetSpwanTime(float time)
    {
        spawnTime = time;
    }


    private IEnumerator StartSpawnCoroutine()
    {
        currentSpawnCount = 0; 
        ISpawn();

        while (currentSpawnCount < monsterSpawnInfo.SpawnCount)
        {
            currentSpawnTime += GameTimeManager.Instance.DeltaTime;

            if(currentSpawnTime >= spawnTime)
            {
                ISpawn();
                currentSpawnTime = 0f;
            }

            yield return null;
        }

        monsterSpawnSystem.EndSpawn();
    }
    private IEnumerator StartSpawnRepeatCoroutine()
    {
        ISpawn();

        while (true)
        {
            currentSpawnTime += GameTimeManager.Instance.DeltaTime;

            if (currentSpawnTime >= spawnTime)
            {
                ISpawn();
                currentSpawnTime = 0f;

                //if (monsterSpawnInfo.SpawnCount == currentSpawnCount)
                //{
                //    StopSpawn();
                //}
            }

            yield return null;
        }
    }

    public virtual void ISpawn()
    {
        GameObject monster = Instantiate(monsterSpawnInfo.MonsterPrefab);
        monster.transform.position = spawnPoint.transform.position;

        var enemyController = monster.GetComponent<EnemyController>();
        enemyController.SetDestinationPoint(endMovePoint);

        ++currentSpawnCount;
    }
}
