using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private int enemyType;

    public Transform[] GetSpawnPositions => spawnPositions;
    public int GetEnemyType => enemyType;
}