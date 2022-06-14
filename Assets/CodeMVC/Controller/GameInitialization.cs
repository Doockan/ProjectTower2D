using CodeMVC.AssetManagement;
using CodeMVC.Player;
using CodeMVC.UserInput;
using UnityEngine;

namespace CodeMVC.Controller
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, DataBase.Data data)
        {
            Camera camera = Camera.main;
            
            var assetProvider = new AssetProvider();
            var gameFactory = new GameFactory(assetProvider);

            var inputInitialization = new InputInitialization(gameFactory);
            var playerInitialization = new PlayerInitialization(gameFactory);
            
            //var enemyFactory = new EnemyFactory(data.Enemy);
            //var enemyInitialization = new EnemyInitialization(enemyFactory);
            
           controllers.Add(inputInitialization);
           controllers.Add(playerInitialization);
           controllers.Add(new InputController(inputInitialization.GetInput()));
           
           controllers.Add(new PlayerController(inputInitialization.GetInput(), playerInitialization.GetPlayer(), playerInitialization.GetTrajectoryLine()));
           controllers.Add(new PlayerRotateController(inputInitialization.GetInput(), playerInitialization.GetPlayer()));
           controllers.Add(new PlayerAttackController(inputInitialization.GetInput(), playerInitialization.GetPlayer()));

           //controllers.Add(enemyInitialization);

           controllers.Add(new CameraInitialization(camera.transform, playerInitialization.GetPlayer().transform.position));
           controllers.Add(new CameraController(playerInitialization.GetPlayer(), camera.transform));

           //controllers.Add(new EnemyMoveController(enemyInitialization.GetMoveEnemies(), playerInitialization.GetPlayer()));
           //controllers.Add(new EndGameController(enemyInitialization.GetEnemies(), playerInitialization.GetPlayer().gameObject.GetInstanceID()));
        }
    }
}