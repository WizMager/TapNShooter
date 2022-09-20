using System;
using System.Collections.Generic;
using System.Linq;
using Controllers;
using Data;
using UnityEngine;
using Utils;
using Views;
using Object = UnityEngine.Object;

public class GameInitialization
{
        public GameInitialization(AllData data, MonoController monoController)
        {
            var prefabsData = data.GetPrefabsData;
            var waypointView = Object.FindObjectOfType<WaypointView>();
            var playerView = Object.Instantiate(prefabsData.playerPrefab, waypointView.GetWaypoints[0].position, waypointView.GetWaypoints[0].rotation).GetComponent<PlayerView>();
            var cameraTransform = playerView.GetPlayerCamera.transform;
            var allEnemySpawnViews = Object.FindObjectsOfType<EnemySpawnView>();
            
            var playerController = new PlayerController(playerView, waypointView.GetWaypoints, prefabsData.bulletPrefab, CreateEnemies(allEnemySpawnViews, prefabsData.enemyPrefab, cameraTransform));

            monoController.Add(playerController);
        }

        private List<GameObject> CreateEnemies(EnemySpawnView[] enemySpawnViews, GameObject[] enemyPrefabs, Transform cameraTransform)
        {
            var enemyRoot = new GameObject("EnemyRoot");
            var enemiesGameObjects = new List<GameObject>();
            List<Transform> enemyTransforms;
            foreach (var enemySpawnView in enemySpawnViews)
            {
                switch (enemySpawnView.GetEnemyType)
                {
                    case EnemyType.FirstEnemyType:
                        enemyTransforms = enemySpawnView.GetSpawnPositions.ToList();
                        foreach (var enemyTransform in enemyTransforms)
                        {
                            enemiesGameObjects.Add(SpawnEnemy(enemyPrefabs[(int)EnemyType.FirstEnemyType], enemyTransform, cameraTransform, enemyRoot.transform));
                        }
                        break;
                    case EnemyType.SecondEnemyType:
                        enemyTransforms = enemySpawnView.GetSpawnPositions.ToList();
                        foreach (var enemyTransform in enemyTransforms)
                        {
                            enemiesGameObjects.Add(SpawnEnemy(enemyPrefabs[(int)EnemyType.SecondEnemyType], enemyTransform, cameraTransform, enemyRoot.transform));
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return enemiesGameObjects;
        }

        private GameObject SpawnEnemy(GameObject enemyPrefab, Transform spawnPosition, Transform cameraTransform, Transform rootTransform)
        {
            var enemy = Object.Instantiate(enemyPrefab, spawnPosition.position, spawnPosition.rotation,
                rootTransform);
            enemy.GetComponent<EnemyView>();
            return enemy;
        }
}