using System;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Data/AllData", fileName = "AllData", order = 0)]
    public class AllData: ScriptableObject
    {
        [SerializeField] private PrefabsData prefabsData;

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
    }
}