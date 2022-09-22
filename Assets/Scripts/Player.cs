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
    [SerializeField] private float waitBeforeInputOn;
    [SerializeField] private float waitAfterShoot;

    public NavMeshAgent GetNavMeshAgent => navMeshAgent;
    public Transform GetShootPosition => shootPosition;
    public Transform GetPlayerTransform => playerTransform;
    public Animator GetAnimator => animator;
    public Camera GetPlayerCamera => playerCamera;
    public float GetTimeWaitBeforeInputOn => waitBeforeInputOn;
    public float GetTimeWaitAfterShoot => waitAfterShoot;
    

    private void Awake()
    {
        navMeshAgent.speed = moveSpeed;
    }
}