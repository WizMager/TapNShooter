using Controllers;
using Data;

public class GameInitialization
{
        public GameInitialization(AllData data, MonoController monoController)
        {
            var playerController = new PlayerController(data.GetPlayerData);

            monoController.Add(playerController);
        }
}