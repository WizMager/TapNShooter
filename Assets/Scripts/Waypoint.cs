using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;

    public Transform[] GetWaypoints => waypoints;
}