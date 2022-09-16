using Data;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private AllData data;
    private Controllers.Controllers _controllers;

    private void Awake()
    {
        _controllers = new Controllers.Controllers();
        new GameInitialization(data, _controllers);
        _controllers.Awake();
    }

    private void OnEnable()
    {
        _controllers.OnEnable();
    }

    private void Start()
    {
        _controllers.Start();
    }

    private void Update()
    {
        _controllers.Update();
    }

    private void FixedUpdate()
    {
        _controllers.FixedUpdate();
    }

    private void OnDisable()
    {
        _controllers.OnDisable();
    }

    private void OnDestroy()
    {
        _controllers.OnDestroy();
    }
}