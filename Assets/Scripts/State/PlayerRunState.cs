﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Views;

namespace State
{
    public class PlayerRunState : BaseState
    {
        private readonly NavMeshAgent _navMeshAgent;
        private readonly List<Transform> _wayPoints;
        private readonly Transform _playerTransform;
        private int _currentWaypoint;

        public PlayerRunState(PlayerView playerView, IStateSwitcher stateSwitcher, InputActions inputActions, Transform[] waypoints) : base(playerView, stateSwitcher, inputActions)
        {
            _navMeshAgent = playerView.GetNavMeshAgent;
            _wayPoints = new List<Transform>(waypoints.Length);
            _playerTransform = playerView.GetPlayerTransform;
            foreach (var waypoint in waypoints)
            {
                _wayPoints.Add(waypoint);
            }
        }

        public override void Start()
        {
            Debug.Log("Start run");
            _navMeshAgent.enabled = true;
            _navMeshAgent.SetDestination(_wayPoints[_currentWaypoint + 1].position);

            //TODO: start run animation
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
            Debug.Log("Stop run");
            if (_currentWaypoint + 1 == _wayPoints.Count)
            {
                _currentWaypoint = 0;
            }
            //TODO: stop run animation
        }
    }
}