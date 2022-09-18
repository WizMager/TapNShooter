using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace State
{
    public class PlayerRunState : BaseState
    {
        private readonly NavMeshAgent _navMeshAgent;
        private readonly List<Transform> _wayPoints;
        private int _currentWaypoint = 3;

        public PlayerRunState(Animator animator, IStateSwitcher stateSwitcher, InputActions inputActions, NavMeshAgent playerAgent, Transform[] waypoints) : base(animator, stateSwitcher, inputActions)
        {
            _navMeshAgent = playerAgent;
            _wayPoints = new List<Transform>(waypoints.Length);
            foreach (var waypoint in waypoints)
            {
                _wayPoints.Add(waypoint);
            }
        }

        public override void Start()
        {
            Debug.Log("Start run");
            if (_currentWaypoint + 1 == _wayPoints.Count)
            {
                _currentWaypoint = 0;
                _stateSwitcher.SwitchState<PlayerIdleState>(); 
            }
            _navMeshAgent.SetDestination(_wayPoints[_currentWaypoint + 1].position);

            //TODO: start run animation
        }

        public override void Update()
        {
            if (_navMeshAgent.remainingDistance > 0) return;
            _currentWaypoint++;
            _stateSwitcher.SwitchState<PlayerShootState>();

        }

        public override void Stop()
        {
            Debug.Log("Stop run");
            //TODO: stop run animation
        }
    }
}