using System;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Data/AllData", fileName = "AllData", order = 0)]
    public class AllData: ScriptableObject
    {
        [SerializeField] private PrefabsData prefabsData;
        [SerializeField] private EnemyData[] enemyData;

        public PrefabsData GetPrefabsData
        {
            get
            {
                if (prefabsData != null)
                {
                    return prefabsData;
                }
                throw new ArgumentNullException("PrefabsData is null. Forget create or linked?");
            }
        }
        
        public EnemyData[] GetEnemyData
        {
            get
            {
                if (enemyData != null)
                {
                    return enemyData;
                }
                throw new ArgumentNullException("EnemyData is null. Forget create or linked?");
            }
        }
    }
}