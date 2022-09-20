using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace State
{
    public class PlayerRunState : BaseState
    {
        private readonly NavMeshAgent _navMeshAgent;
        private readonly List<Transform> _wayPoints;
        private readonly Transform _playerTransform;
        private int _currentWaypoint;

        public PlayerRunState(Player player, IStateSwitcher stateSwitcher, InputActions inputActions, Transform[] waypoints) : base(player, stateSwitcher, inputActions)
        {
            _navMeshAgent = player.GetNavMeshAgent;
            _wayPoints = new List<Transform>(waypoints.Length);
            _playerTransform = player.GetPlayerTransform;
            foreach (var waypoint in waypoints)
            {
                _wayPoints.Add(waypoint);
            }
        }

        public override void Start()
        {
            _navMeshAgent.enabled = true;
            _navMeshAgent.SetDestination(_wayPoints[_currentWaypoint + 1].position);
            _animator.CrossFade("Run", 0.05f);
        }

        public override void Update()
        {
            if (_navMeshAgent.remainingDistance > 0.05f) return;
            _currentWaypoint++;
            _navMeshAgent.enabled = false;
            _playerTransform.rotation = _wayPoints[_currentWaypoint].rotation;
            _stateSwitcher.SwitchState<PlayerShootState>();
        }

        public override void Stop()
        {
            if (_currentWaypoint + 1 == _wayPoints.Count)
            {
                _currentWaypoint = 0;
            }
            _animator.CrossFade("Idle", 0.05f);
        }
    }
}