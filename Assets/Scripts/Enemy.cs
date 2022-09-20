using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int startHealth;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Animator animator;
    [SerializeField] private CapsuleCollider rootCollider;
    [SerializeField] private Rigidbody[] rigidbodies;
    [SerializeField] private float deactivateTime;
    [SerializeField] private Transform hips;
    private int _health;
    private Transform _cameraTransform;
    private Vector3 _startHipsPosition;

    public void Init(Transform cameraTransform)
    {
        _cameraTransform = cameraTransform;
    }

    private void Awake()
    {
        _startHipsPosition = hips.position;
    }

    private void OnEnable()
    {
        RigidbodyActivation(false);
        hips.position = _startHipsPosition;
        rootCollider.enabled = true;
        healthSlider.gameObject.SetActive(true);
        _health = startHealth;
        healthSlider.maxValue = startHealth;
        healthSlider.value = _health;
        animator.enabled = true;
    }

    private void FixedUpdate()
    {
        healthSlider.transform.LookAt(_cameraTransform);
    }

    private void OnDisable()
    {
        StopCoroutine(DeactivationEnemy()); 
    }

    public bool TakeDamage()
    {
        _health--;
        healthSlider.value = _health;
        if (_health > 0) return false;
        animator.enabled = false;
        StartCoroutine(DeactivationEnemy());
        return true;
    }

    private IEnumerator DeactivationEnemy()
    {
        healthSlider.gameObject.SetActive(false);
        rootCollider.enabled = false;
        RigidbodyActivation(true);
        yield return new WaitForSeconds(deactivateTime);
        gameObject.SetActive(false);
    }

    private void RigidbodyActivation(bool activate)
    {
        foreach (var rb in rigidbodies)
        {
            rb.isKinematic = !activate;
        }
    }
}