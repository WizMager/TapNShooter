using Controllers;
using Data;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private AllData data;
    private MonoController _monoController;

    private void Awake()
    {
        _monoController = new MonoController();
        new GameInitialization(data, _monoController);
        _monoController.Awake();
    }

    private void OnEnable()
    {
        _monoController.OnEnable();
    }

    private void Start()
    {
        _monoController.Start();
    }

    private void Update()
    {
        _monoController.Update();
    }

    private void FixedUpdate()
    {
        _monoController.FixedUpdate();
    }

    private void OnDisable()
    {
        _monoController.OnDisable();
    }

    private void OnDestroy()
    {
        _monoController.OnDestroy();
    }
}