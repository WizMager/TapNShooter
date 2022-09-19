using UnityEngine;
using Utils;

namespace Views
{
    public class EnemySpawnView : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPositions;
        [SerializeField] private EnemyType enemyType;

        public Transform[] GetSpawnPositions => spawnPositions;
        public EnemyType GetEnemyType => enemyType;
    }
}