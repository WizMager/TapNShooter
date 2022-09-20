using UnityEngine;
using Utils;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private EnemyType enemyType;

    public Transform[] GetSpawnPositions => spawnPositions;
    public EnemyType GetEnemyType => enemyType;
}