using UnityEngine;
using Utils;

namespace Data
{
    [CreateAssetMenu(menuName = "Data/EnemyData", fileName = "EnemyData")]
    public class EnemyData : ScriptableObject
    {
        public GameObject enemyPrefab;
        public EnemyType enemyType;
    }
}