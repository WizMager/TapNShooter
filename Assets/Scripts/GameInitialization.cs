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
            var waypointView = Object.FindObjectOfType<WaypointView>();
            var playerView = Object.Instantiate(data.GetPrefabsData.playerPrefab).GetComponent<PlayerView>();
            var allEnemyViews = Object.FindObjectsOfType<EnemyView>();
            var allEnemy = new List<GameObject>(allEnemyViews.Length);
            allEnemy.AddRange(allEnemyViews.Select(enemy => enemy.gameObject));

            var playerController = new PlayerController(playerView, waypointView.GetWaypoints, data.GetPrefabsData, allEnemy);

            monoController.Add(playerController);
        }
}