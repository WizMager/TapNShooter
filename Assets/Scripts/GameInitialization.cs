using System.Collections.Generic;
using System.Linq;
using Controllers;
using Data;
using UnityEngine;
using Views;

public class GameInitialization
{
        public GameInitialization(AllData data, MonoController monoController)
        {
            var prefabsData = data.GetPrefabsData;
            var waypointView = Object.FindObjectOfType<WaypointView>();
            var playerView = Object.Instantiate(prefabsData.playerPrefab, waypointView.GetWaypoints[0].position, waypointView.GetWaypoints[0].rotation).GetComponent<PlayerView>();
            var allEnemySpawnViews = Object.FindObjectsOfType<EnemySpawnView>();
            
            var playerController = new PlayerController(playerView, waypointView.GetWaypoints, prefabsData.bulletPrefab, SpawnEnemies(allEnemySpawnViews, prefabsData.enemyPrefab));

            monoController.Add(playerController);
        }

        private List<GameObject> SpawnEnemies(EnemySpawnView[] enemySpawnViews, GameObject enemyPrefab)
        {
            var allEnemyTransforms = enemySpawnViews.SelectMany(enemySpawnView => enemySpawnView.GetSpawnPositions).ToList();
            var enemyRoot = new GameObject("EnemyRoot");
            return allEnemyTransforms.Select(enemyTransform => Object.Instantiate(enemyPrefab, enemyTransform.position, enemyTransform.rotation, enemyRoot.transform)).ToList();
        }
}