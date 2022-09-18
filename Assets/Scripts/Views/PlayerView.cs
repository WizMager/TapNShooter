using UnityEngine;
using UnityEngine.AI;

namespace Views
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private Transform shootPosition;
        [SerializeField] private Transform playerTransform;
        [SerializeField] private Animator animator;
        [SerializeField] private Camera playerCamera;

        public NavMeshAgent GetNavMeshAgent => navMeshAgent;
        public Transform GetShootPosition => shootPosition;
        public Transform GetPlayerTransform => playerTransform;
        public Animator GetAnimator => animator;
        public Camera GetPlayerCamera => playerCamera;
    }
}