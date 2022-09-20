using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform shootPosition;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Animator animator;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float moveSpeed;

    public NavMeshAgent GetNavMeshAgent => navMeshAgent;
    public Transform GetShootPosition => shootPosition;
    public Transform GetPlayerTransform => playerTransform;
    public Animator GetAnimator => animator;
    public Camera GetPlayerCamera => playerCamera;

    private void Awake()
    {
        navMeshAgent.speed = moveSpeed;
    }
}