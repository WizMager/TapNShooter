using Controllers;
using Data;
using UnityEngine;
using UnityEngine.AI;

public class GameInitialization
{
        public GameInitialization(AllData data, MonoController monoController)
        {
            var player = Object.Instantiate(data.GetPrefabsData.playerPrefab);
            var playerNavMeshAgent = player.GetComponent<NavMeshAgent>();
            var playerTransform = player.GetComponent<Transform>();
            
            var playerController = new PlayerController(playerNavMeshAgent, data.GetWaypointData, playerTransform);

            monoController.Add(playerController);
        }
}