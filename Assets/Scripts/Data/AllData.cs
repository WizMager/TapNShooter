using System;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Data/AllData", fileName = "AllData", order = 0)]
    public class AllData: ScriptableObject
    {
        [SerializeField] private PlayerData playerData;
        [SerializeField] private WaypointData waypointData;
        [SerializeField] private PrefabsData prefabsData;

        public PlayerData GetPlayerData
        {
            get
            {
                if (playerData != null)
                {
                    return playerData;
                }
                throw new ArgumentNullException("PlayerData is null. Forget create or linked?");
            }
        }
        
        public WaypointData GetWaypointData
        {
            get
            {
                if (waypointData != null)
                {
                    return waypointData;
                }
                throw new ArgumentNullException("WaypointData is null. Forget create or linked?");
            }
        }
        
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