using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Data/PrefabsData", fileName = "PrefabsData")]
    public class PrefabsData : ScriptableObject
    {
        public GameObject playerPrefab;
        public GameObject bulletPrefab;
    }
}