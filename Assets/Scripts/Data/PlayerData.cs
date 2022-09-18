﻿using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Data/PlayerData", fileName = "PlayerData")]
    public class PlayerData : ScriptableObject
    {
        public float moveSpeed;
        public float shootCooldown;
    }
}