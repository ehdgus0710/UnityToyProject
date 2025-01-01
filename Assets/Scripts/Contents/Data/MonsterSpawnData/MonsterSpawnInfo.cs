using UnityEngine;

[CreateAssetMenu(fileName = "MonsterSpawnInfo", menuName = "MonsterSpawnData/MonsterSpawnInfo", order = 3)]
[System.Serializable]
public class MonsterSpawnInfo : ScriptableObject
{
    [SerializeField]
    private GameObject monsterPrefab;
    public GameObject MonsterPrefab { get { return monsterPrefab; } }

    [SerializeField]
    private float spawnTime;
    public float SpawnTime { get { return spawnTime; } }


}
