using System;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Data/AllData", fileName = "AllData", order = 0)]
    public class AllData: ScriptableObject
    {
        [SerializeField] private PlayerData playerData;

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
    }
}