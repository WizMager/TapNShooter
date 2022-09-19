using UnityEngine;

namespace Views
{
    public class EnemySpawnView : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPositions;

        public Transform[] GetSpawnPositions => spawnPositions;
    }
}