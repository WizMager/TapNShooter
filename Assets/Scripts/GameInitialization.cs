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
            var waypoint = Object.FindObjectOfType<Waypoint>();
            var player = Object.Instantiate(prefabsData.playerPrefab, waypoint.GetWaypoints[0].position, waypoint.GetWaypoints[0].rotation).GetComponent<Player>();
            var cameraTransform = player.GetPlayerCamera.transform;
            var enemySpawns = Object.FindObjectsOfType<EnemySpawn>();
            var enemySpawnPositions = new int[enemySpawns.Length];
            for (int i = 0; i < enemySpawns.Length; i++)
            {
                enemySpawnPositions[i] = enemySpawns[i].GetSpawnPositions.Length;
            }
            
            var playerController = new PlayerController(player, waypoint.GetWaypoints, prefabsData.bulletPrefab, CreateEnemies(enemySpawns, prefabsData.enemyPrefab, cameraTransform), enemySpawnPositions);

            monoController.Add(playerController);
        }

        private List<GameObject> CreateEnemies(EnemySpawn[] enemySpawns, GameObject[] enemyPrefabs, Transform cameraTransform)
        {
            var enemyRoot = new GameObject("EnemyRoot");
            var enemiesGameObjects = new List<GameObject>();
            List<Transform> enemyTransforms;
            foreach (var enemySpawn in enemySpawns)
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