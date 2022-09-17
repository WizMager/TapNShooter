using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Data/PlayerData", fileName = "Player")]
    public class PlayerData : ScriptableObject
    {
        public float moveSpeed;
        public float shootCooldown;
    }
}