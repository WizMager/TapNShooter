using Data;

namespace Models
{
    public class PlayerModel
    {
        private float _moveSpeed;
        private float _shootCooldown;

        public PlayerModel(PlayerData playerData)
        {
            _moveSpeed = playerData.moveSpeed;
            _shootCooldown = playerData.shootCooldown;
        }
    }
}