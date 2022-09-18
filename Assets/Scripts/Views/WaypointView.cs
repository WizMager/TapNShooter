using UnityEngine;

namespace Views
{
    public class WaypointView : MonoBehaviour
    {
        [SerializeField] private Transform[] waypoints;

        public Transform[] GetWaypoints => waypoints;
    }
}