using System.Collections.Generic;
using System.Linq;
using Controllers;
using Data;
using UnityEngine;
using Object = UnityEngine.Object;

public class GameInitialization
{
        public GameInitialization(AllData data, MonoController monoController)
        {
            var prefabsData = data.GetPrefabsData;
            var waypointView = Object.FindObjectOfType<Waypoint>();
            var playerView = Object.Instantiate(prefabsData.playerPrefab, waypointView.GetWaypoints[0].position, waypointView.GetWaypoints[0].rotation).GetComponent<Player>();
            var cameraTransform = playerView.GetPlayerCamera.transform;
            var allEnemySpawnViews = Object.FindObjectsOfType<EnemySpawn>();
            
            var playerController = new PlayerController(playerView, waypointView.GetWaypoints, prefabsData.bulletPrefab, CreateEnemies(allEnemySpawnViews, prefabsData.enemyPrefab, cameraTransform));

            monoController.Add(playerController);
        }

        private List<GameObject> CreateEnemies(EnemySpawn[] enemySpawnViews, GameObject[] enemyPrefabs, Transform cameraTransform)
        {
            var enemyRoot = new GameObject("EnemyRoot");
            var enemiesGameObjects = new List<GameObject>();
            List<Transform> enemyTransforms;
            foreach (var enemySpawn in enemySpawnViews)
            {
                enemyTransforms = enemySpawn.GetSpawnPositions.ToList();
                foreach (var enemyTransform in enemyTransforms)
                {
                    enemiesGameObjects.Add(SpawnEnemy(enemyPrefabs[enemySpawn.GetEnemyType], enemyTransform, cameraTransform, enemyRoot.transform));
                }
            }
            return enemiesGameObjects;
        }

        private GameObject SpawnEnemy(GameObject enemyPrefab, Transform spawnPosition, Transform cameraTransform, Transform rootTransform)
        {
            var enemy = Object.Instantiate(enemyPrefab, spawnPosition.position, spawnPosition.rotation,
                rootTransform);
            enemy.GetComponent<Enemy>().Init(cameraTransform);
            return enemy;
        }
}