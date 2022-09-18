using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Data/WaypointData", fileName = "WaypointData")]
    public class WaypointData : ScriptableObject
    {
        public Transform[] waypoints;
    }
}